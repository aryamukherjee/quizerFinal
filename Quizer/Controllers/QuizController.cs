using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizer.Models;
using Quizer.Models.ViewModels;

namespace Quizer.Controllers
{
    public class QuizController : Controller
    {
        private IQuizRepo repository;
        private IQuestionRepo questionRepo;
        private ApplicationDbContext _context;
        public int PageSize = 4;

        public QuizController(IQuizRepo repo, IQuestionRepo qRepo, ApplicationDbContext ctx)
        {
            repository = repo;
            questionRepo = qRepo;
            _context = ctx;
        }
        public ViewResult List(int quizPage = 1) =>
            View(new QuizesListViewModel
            { Quizes = repository.Quizes.OrderBy(p => p.QuizID)
                .Skip((quizPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                { CurrentPage = quizPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Quizes.Count()
                }
            });
        public ViewResult TakeQuiz(int QuizID) =>
            View(new TakeQuizViewModel
            {
                Quiz = repository.Quizes.FirstOrDefault(p => p.QuizID == QuizID),
                Questions = questionRepo.Questions.Where(q => q.QuizID == QuizID)
            });

        [HttpPost]
        public IActionResult TakeQuiz(CompletedQuiz[] completedQuizes)
        {
            var quizId = completedQuizes[0].QuizID;
            var totalInitialScore = 0;

            foreach(var q in completedQuizes)
            {
                if(q.QType == "MCQ" && q.CorrectMCQAns == q.MCQAnswer)
                {
                    totalInitialScore = totalInitialScore + q.Points;
                }
                _context.CompletedQuizes.Add(q);
            }
            _context.Grades.Add(new Grade(quizId, totalInitialScore, 0));
            
            //mark the quiz to be completed.
            var query = from q in _context.Quizes
                        where q.QuizID == quizId
                        select q;
            foreach(Quiz q in query)
            {
                q.Completed = 1;
            }
            _context.SaveChanges();

            return Ok();
        }

        public ViewResult Grades()
        {
            IEnumerable<GradesViewModel> vm = (IEnumerable<GradesViewModel>)(from q in _context.Quizes
                                            join g in _context.Grades
                                            on q.QuizID equals g.QuizID
                                            select new GradesViewModel
                                            {
                                               Title =  q.Title,
                                               InitialGrade = g.InitialGrade,
                                               FinalGrade = g.FinalGrade
                                            });

            return View(vm);
        }
            
    }
}
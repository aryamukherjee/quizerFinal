using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quizer.Models;
using Quizer.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Quizer.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IQuizRepo repository;
        private IQuestionRepo questionRepo;
        private ApplicationDbContext _context;
        public int PageSize = 4;

        public AdminController(IQuizRepo repo, IQuestionRepo qRepo, ApplicationDbContext ctx)
        {
            repository = repo;
            questionRepo = qRepo;
            _context = ctx;
        }
        public ViewResult List(int quizPage = 1)
        {
            TempData["user"] = "Admin";
            return View(new AdminListViewModel
            {
                Quizes = repository.Quizes.OrderBy(p => p.QuizID)
                .Skip((quizPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = quizPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Quizes.Count()
                }
            });
        }
        public ViewResult Edit(int quizId)
        {
            TempData["user"] = "Admin";
            return View(new AdminEditListViewModel
            {
                Quiz = repository.Quizes.FirstOrDefault(p => p.QuizID == quizId),
                Questions = questionRepo.Questions.Where(q => q.QuizID == quizId)
            });
        }

        public ViewResult Create()
        {
            TempData["user"] = "Admin";
            return View();
        }

        [HttpPost]
        public IActionResult SaveQuiz(Quiz quiz, Question[] questions)
        {
            TempData["user"] = "Admin";
            _context.Quizes.Add(quiz);
            foreach(var q in questions)
            {
                q.QuizID = quiz.QuizID;
                _context.Questions.Add(q);
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int QuizID)
        {
            //remove completed quiz reference
            var cq = _context.CompletedQuizes.Where(x => x.QuizID == QuizID);
            foreach(var item in cq)
            {
                _context.CompletedQuizes.Remove(item);
            }
            //remove grades reference
            var grd = _context.Grades.Where(x => x.QuizID == QuizID);
            foreach (var item in grd)
            {
                _context.Grades.Remove(item);
            }
            //finally remove quiz
            _context.Quizes.Remove(_context.Quizes.Find(QuizID));
            _context.SaveChanges();
            TempData["message"] = $"Quiz has been deleted";
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult UpdateQuiz(Quiz quiz, Question[] questions)
        {
            _context.Quizes.Update(quiz);
            foreach (var q in questions)
            {
                q.QuizID = quiz.QuizID;
                _context.Questions.Add(q);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
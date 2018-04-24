using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models
{
    public class CompletedQuiz
    {
        public int ID { get; set; }
        public int? QuestionID { get; set; }
        public int? QuizID { get; set; }
        public Question Question { get; set; }
        public Quiz Quiz { get; set; }
        public int? MCQAnswer { get; set; }
        public string TextAnswer { get; set; }
        public int Points { get; set; }
        public string QType { get; set; }
        public int CorrectMCQAns { get; set; }
    }
}

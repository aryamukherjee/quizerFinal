using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionType { get; set; }
        public string QuestionText { get; set; }
        public string MCQAnswer1 { get; set; }
        public string MCQAnswer2 { get; set; }
        public string MCQAnswer3 { get; set; }
        public string MCQAnswer4 { get; set; }
        public string TextAnswer { get; set; }
        public int CorrectAnswer { get; set; }
        public int SelectedAnswer { get; set; }
        public int Points { get; set; }
        public int QuizID { get; set; }
        public Quiz Quiz { get; set; }
    }
}

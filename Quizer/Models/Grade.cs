using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models
{
    public class Grade
    {
        public int ID { get; set; }
        public int? QuizID { get; set; }
        public Quiz Quiz { get; set; }
        public int? InitialGrade { get; set; }
        public int? FinalGrade { get; set; }

        public Grade(){}

        public Grade(int? quizId, int initialGrade, int finalGrade)
        {
            QuizID = quizId;
            InitialGrade = initialGrade;
            FinalGrade = finalGrade;

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public string Title { get; set; }
        public int TotalPoints { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public int? Completed { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models.ViewModels
{
    public class GradesViewModel
    {
        public string Title { get; set; }
        public int? InitialGrade { get; set; }
        public int? FinalGrade { get; set; }
    }
}

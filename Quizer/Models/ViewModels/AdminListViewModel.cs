using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models.ViewModels
{
    public class AdminListViewModel
    {
        public IEnumerable<Quiz> Quizes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}

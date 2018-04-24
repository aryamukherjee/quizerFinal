using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models
{
    public class EFQuizRepository : IQuizRepo {
        private ApplicationDbContext context;
        public EFQuizRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Quiz> Quizes => context.Quizes;
    }
}

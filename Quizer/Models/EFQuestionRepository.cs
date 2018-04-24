using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models
{
    public class EFQuestionRepository : IQuestionRepo
    {
        private ApplicationDbContext context;
        public EFQuestionRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Question> Questions => context.Questions;
    }
}

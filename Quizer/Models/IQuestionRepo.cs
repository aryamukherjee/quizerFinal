using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models
{
    public interface IQuestionRepo
    {
        IQueryable<Question> Questions { get; }
    }
}

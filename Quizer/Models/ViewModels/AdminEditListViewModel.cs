﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizer.Models.ViewModels
{
    public class AdminEditListViewModel
    {
        public Quiz Quiz { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}

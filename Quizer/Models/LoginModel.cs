using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quizer.Models
{
    public class LoginModel
    {
        [Required]
        [UIHint("username")]
        public string Name { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}

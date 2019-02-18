using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sysmap.Portal.Sanity.Models
{
    public class Login
    {
        [Required(ErrorMessage ="O campo Email é obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatorio")]
        public string Password { get; set; }
    }
}

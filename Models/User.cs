using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sysmap.Portal.Sanity.Models
{
    public class User : Login
    {
        public int idUser { get; set; }

        [Required]
        [Display(Name ="Tipo Conta")]
        public string TypeUser { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Data Cadastro")]
        public DateTime DateCreate { get; set; }
    }
}

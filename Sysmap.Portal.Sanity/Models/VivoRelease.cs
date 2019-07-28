using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sysmap.Portal.Sanity.Models
{
    public class VivoRelease
    {
        public int IdRelease { get; set; }

        [Required(ErrorMessage = "Informe o código da CRQ")]
        public string CodRelease { get; set; }

        public int Status { get; set; }

        public DateTime DataCriacao { get; set; }

        [Required(ErrorMessage = "Informe a data da release")]
        public DateTime DataRelease { get; set; }
    }
}

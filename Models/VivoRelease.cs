using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sysmap.Portal.Sanity.Models
{
    public class VivoRelease
    {
        public int IdRelease { get; set; }

        public int CodRelease { get; set; }

        public int Status { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataRelease { get; set; }
    }
}

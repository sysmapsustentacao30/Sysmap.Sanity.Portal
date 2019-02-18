using System;
using System.ComponentModel.DataAnnotations;

namespace Sysmap.Portal.Sanity.Models
{
    public class NaturaRelease
    {
        public int id_release { get; set; }

        public string cod_release { get; set; }

        [Required(ErrorMessage = "Campo Quantidade de testes é obrigatório!")]
        [Display(Name = "Quantidade de testes: ")]
        public int qtdTestes { get; set; }

        [Required(ErrorMessage = "Campo sistema é obrigatório!")]
        [Display(Name = "Sistema: ")]
        public string sistema { get; set; }

        public int status { get; set; }

        [Required(ErrorMessage = "Data de inicio dos testes é obrigatorio!")]
        [Display(Name = "Data incial: ")]
        public DateTime data_inicial{ get; set; }

        [Required(ErrorMessage = "Data final dos testes é obrigatorio!")]
        [Display(Name = "Data final: ")]
        public DateTime data_final { get; set; }
    }
}

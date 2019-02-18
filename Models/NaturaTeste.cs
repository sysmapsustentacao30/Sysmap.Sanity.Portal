using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sysmap.Portal.Sanity.Models
{
    public class NaturaTeste
    {
        public int id_natura_teste { get; set; }

        public string cod_release { get; set; }

        [Display(Name = "Numero do Teste")]
        public int numero_teste { get; set; }

        [Display(Name = "Executor")]
        public string executor { get; set; }

        [Display(Name = "Status da Execução")]
        public int execucao_status { get; set; }

        [Display(Name = "Status do chamado")]
        public int chamado_status { get; set; }

        [Display(Name = "Sistema")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string sistema { get; set; }

        [Display(Name = "Cenario")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string cenario { get; set; }

        [Display(Name = "Pré condição")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string pre_condicao { get; set; }

        [Display(Name = "Passos")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string passos { get; set; }

        [Display(Name = "Resultado esperado")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string result_esperado { get; set; }

        [Display(Name = "Pós condição")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string pos_condicao { get; set; }

        [Display(Name = "Observação")]
        public string observacao { get; set; }

        [Display(Name = "Data de execução")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public DateTime? data_execucao { get; set; }

        [Display(Name = "Data que executou")]
        public DateTime data_executado { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string funcionalidade { get; set; }

        public string massa { get; set; }

        [Display(Name = "Documentação: ")]
        public string url_doc { get; set; }
    }
}

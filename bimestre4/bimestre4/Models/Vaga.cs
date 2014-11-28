using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bimestre4.Models
{
    public class Vaga
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome da Vaga")]
        public string NomeVaga { get; set; }

        [Display(Name = "Descrição da vaga")]
        public string DescVaga { get; set; }

        public virtual ICollection<TecnologiaVaga> TecnologiaVaga { get; set; }

    }
}
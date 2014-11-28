using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bimestre4.Models
{
    public class Tecnologia
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome da tecnologia")]
        public string NomeTecnologia { get; set; }

        [Display(Name = "Descrição da tecnologia")]
        public string DescTecnologia { get; set; }

        public virtual ICollection<TecnologiaVaga> TecnologiaVaga { get; set; }
        public virtual ICollection<CandidatoTecnologia> CandidatoTecnologia { get; set; }

    }
}
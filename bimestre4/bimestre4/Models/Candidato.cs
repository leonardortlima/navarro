using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bimestre4.Models
{
    public class Candidato
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome do candidato")]
        public string NomeCandidato { get; set; }

        [Display(Name = "Telefone do candidato")]
        public string Telefone { get; set; }

        [NotMapped]
        public int Pontuacao { get; set; }

        public virtual ICollection<CandidatoTecnologia> CandidatoTecnologia { get; set; }
    }
}
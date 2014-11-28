using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bimestre4.Models
{
    public class CandidatoTecnologia
    {
        public int TecnologiaID { get; set; }
        public int CandidatoID { get; set; }

        public virtual Tecnologia Tecnologia { get; set; }
        public virtual Candidato Candidato { get; set; }
    }
}
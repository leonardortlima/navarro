using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bimestre4.Models
{
    public class RankModel
    {
        public Vaga vaga { get; set; }
        public List<Candidato> candidatos { get; set; }
    }
}
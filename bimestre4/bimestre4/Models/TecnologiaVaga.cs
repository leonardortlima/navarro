using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bimestre4.Models
{
    public class TecnologiaVaga
    {
        public int TecnologiaID { get; set; }
        public int VagaID { get; set; }
        public int Peso { get; set; }

        public virtual Tecnologia Tecnologia { get; set; }
        public virtual Vaga Vaga { get; set; }
    }
}
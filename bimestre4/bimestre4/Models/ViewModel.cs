using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bimestre4.Models
{
    public class ViewModel<X,Y,Z>
    {
        public X genericModel { get; set; }
        public List<Y> List { get; set; }
        public List<Z> FullList { get; set; }
    }
}
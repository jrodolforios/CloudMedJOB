using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Parametro
{
    public class SegmentoModel : IModel
    {
        public int IdSegmento { get; set; }
        public string NomeSegmento { get; set; }

        public string toString()
        {
            return NomeSegmento;
        }

        public void validar()
        {
            //void
        }
    }
}
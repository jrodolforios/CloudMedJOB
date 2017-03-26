using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Parametro 
{
    public class ElaboradorPPRAModel : IModel
    {
        public int IdElaboradorPPRA { get; set; }
        public string NomeElaboradorDoPPRA { get; set; }

        public string toString()
        {
            return NomeElaboradorDoPPRA;
        }

        public void validar()
        {
            //void
        }
    }
}
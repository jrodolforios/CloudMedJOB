using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class ContadorModel : IModel
    {
        public int IdContador { get; set; }
        public string NomeContador { get; set; }

        public string toString()
        {
            return NomeContador;
        }

        public void validar()
        {
            //void
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Parametro
{
    public class ElaboradorPCMSOModel : IModel
    {
        public int IdElaboradorPCMSO { get; set; }
        public string NomeElaboradorPCMSO { get; set; }

        public string toString()
        {
            return this.NomeElaboradorPCMSO;
        }

        public void validar()
        {
            //void
        }
    }
}
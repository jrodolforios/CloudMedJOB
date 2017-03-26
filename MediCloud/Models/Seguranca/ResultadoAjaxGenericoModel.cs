using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Seguranca
{
    public class ResultadoAjaxGenericoModel : IModel
    {
        public bool acaoBemSucedida { get; set; }
        public string mensagem { get; set; }

        public string toString()
        {
            return mensagem;
        }

        public void validar()
        {
            if (!acaoBemSucedida)
                throw new InvalidOperationException(mensagem);
        }
    }
}
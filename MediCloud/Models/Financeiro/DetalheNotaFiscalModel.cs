using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class DetalheNotaFiscalModel : IModel
    {
        public int? Quantidade { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? Total { get; set; }
        public int IdNotaFiscal { get; set; }
        public string SubGrupo { get; set; }

        public string toString()
        {
            throw new NotImplementedException();
        }

        public void validar()
        {
            // void
        }
    }
}
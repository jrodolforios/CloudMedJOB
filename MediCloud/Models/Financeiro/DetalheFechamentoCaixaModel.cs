using MediCloud.Code.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class DetalheFechamentoCaixaModel : IModel
    {
        public int? Quantidade { get; set; }
        public decimal? Valor { get; set; }
        public int IdFechamentoCaixa { get; set; }
        public string Usuario { get; set; }
        public EnumFinanceiro.TipoPagamento TipoPagamento {get;set;}

        public string toString()
        {
            return $"{Valor} - {Quantidade} ({Usuario})";
        }

        public void validar()
        {
            //void
        }
    }
}
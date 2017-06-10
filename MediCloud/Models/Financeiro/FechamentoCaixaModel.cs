using MediCloud.Code.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class FechamentoCaixaModel : IModel
    {
        public int IdFechamentoCaixa { get; set; }

        public DateTime? Data { get; set; }
        public string Usuario { get; set; }

        public string Observacoes { get; set; }
        public DateTime? DataFechamento { get; set; }

        public EnumFinanceiro.PeriodoFechamentoCaixa Periodo { get; set; }
        public decimal? Valor { get; set; }

        public int? Quantidade { get; set; }

        public List<DetalheFechamentoCaixaModel> detalhesFechamentoCaixa { get; set; }

        public string toString()
        {
            return $"{Usuario} - {Data?.ToShortDateString()} ({Periodo.ToString()})";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (!Data.HasValue)
                erros.Add("O campo \"Data\" é de preenchimento obrigratório");

            if (erros.Any())
            {
                errosTratados = tratarListaDeErros(erros);

                throw new InvalidOperationException(errosTratados);
            }
        }

        private string tratarListaDeErros(List<string> erros)
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine("Verifique os seguintes itens antes de salvar:");

            erros.ForEach(x =>
            {
                strBuilder.AppendLine("- " + x);
            });

            return strBuilder.ToString();
        }
    }
}
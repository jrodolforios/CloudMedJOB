using MediCloud.Code.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class FormaPagamentoModel : IModel
    {
        public int IdFormaPagamento { get; set; }
        public string NomeFormaPagamento { get; set; }
        public EnumFinanceiro.TipoPagamento TipoPagamento { get; set; }

        public string toString()
        {
            return $"{NomeFormaPagamento} - {TipoPagamento}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeFormaPagamento))
                erros.Add("O campo \"Nome\" é de preenchimento obrigratório");

            if (TipoPagamento == EnumFinanceiro.TipoPagamento.Vazio)
                erros.Add("O campo \"Tipo do pagamento\" é de preenchimento obrigratório");


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
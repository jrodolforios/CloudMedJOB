using MediCloud.Code.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Parametro.GrupoProcedimento
{
    public class TabelaPrecoModel : IModel
    {
        public int IdTabela { get; set; }
        public string NomeTabela { get; set; }
        public bool Status { get; set; }
        public EnumFinanceiro.TipoPagamento TipoPagamento { get; set; }

        public string toString()
        {
            return NomeTabela;
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeTabela))
                erros.Add("O campo \"Nome da tabela\" é de preenchimento obrigratório");


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
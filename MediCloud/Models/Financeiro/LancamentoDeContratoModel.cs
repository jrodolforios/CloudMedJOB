using MediCloud.Code.Enum;
using MediCloud.Models.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class LancamentoDeContratoModel : IModel
    {
        public int IdLancamentoContrato { get; set; }
        public string Usuario { get; set; }

        public int? Quantidade { get; set; }

        public DateTime? Data { get; set; }
        public int? DiaDeFechamento { get; set; }
        public EnumFinanceiro.SituacaoContrato SituacaoContrato { get; set; }

        public FornecedorModel FornecedorContrato { get; set; }
        public decimal? Total { get; set; }

        public List<DetalheContratoModel> DetalhesContrato { get; set; }

        public string toString()
        {
            return $"{FornecedorContrato.toString()} - {DiaDeFechamento}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (FornecedorContrato == null || FornecedorContrato.IdFornecedor <= 0)
                erros.Add("O campo \"Fornecedor\" é de preenchimento obrigratório");

            if (!DiaDeFechamento.HasValue)
                erros.Add("O campo \"Dia de fechamento\" é de preenchimento obrigratório");


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
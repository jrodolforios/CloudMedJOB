using MediCloud.Models.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Parametro.GrupoProcedimento
{
    public class TabelaFornecedorModel : IModel
    {

        public FornecedorModel Fornecedor { get; set; }
        public ProcedimentoModel Procedimento { get; set; }

        public TabelaPrecoModel Tabela { get; set; }

        public decimal? Faturamento { get; set; }

        public string toString()
        {
            return $"{Fornecedor.RazaoSocial} - {Procedimento.Nome} - {Tabela.NomeTabela} - {Faturamento}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (!Faturamento.HasValue)
                erros.Add("O campo \"Faturamento\" é de preenchimento obrigatório");

            if (Fornecedor == null || Fornecedor.IdFornecedor <= 0)
                erros.Add("O campo \"Tabela\" é de preenchimento obrigatório");

            if (Procedimento == null || Procedimento.IdProcedimento <= 0)
                erros.Add("O campo \"Procedimento\" é de preenchimento obrigatório");

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
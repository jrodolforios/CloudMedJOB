using MediCloud.Models.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Parametro.GrupoProcedimento
{
    public class ValorTabelaDePrecoModel : IModel
    {
        public TabelaPrecoModel Tabela { get; set; }
        public FornecedorModel Fornecedor { get; set; }
        public ProcedimentoModel Procedimento { get; set; }
        public Decimal Valor { get; set; }

        public string toString()
        {
            return $"{Tabela.NomeTabela} - {Fornecedor.RazaoSocial} - {Procedimento.Nome}";
        }

        public int GetId()
        {
            string idString = Tabela.IdTabela.ToString() + Fornecedor.IdFornecedor.ToString() + Procedimento.IdProcedimento.ToString();

            return Convert.ToInt32(idString);
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (Tabela == null || Tabela.IdTabela <= 0)
                erros.Add("O campo \"Tabela\" é de preenchimento obrigratório");

            if (Procedimento == null || Procedimento.IdProcedimento <= 0)
                erros.Add("O campo \"Procedimento\" é de preenchimento obrigratório");

            if (Fornecedor == null || Fornecedor.IdFornecedor <= 0)
                erros.Add("O campo \"Fornecedor\" é de preenchimento obrigratório");

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
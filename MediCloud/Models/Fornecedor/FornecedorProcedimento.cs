using MediCloud.Models.Parametro.GrupoProcedimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Fornecedor
{
    public class FornecedorProcedimento : IModel
    {
        public FornecedorModel Fornecedor { get; set; }
        public ProcedimentoModel Procedimento { get; set; }

        public decimal? Valor { get; set; }

        public string toString()
        {
            return $"{Fornecedor.NomeFantasia} - {Procedimento.Nome} - {Valor.ToString()}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (Procedimento == null || Procedimento.IdProcedimento == 0)
                erros.Add("O campo \"Procedimento\" é de preenchimento obrigratório");

            if (!Valor.HasValue)
                erros.Add("O campo \"Valor\" é de preenchimento obrigatório");

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
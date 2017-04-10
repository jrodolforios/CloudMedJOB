using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using static MediCloud.Code.Enum.EnumFornecedor;

namespace MediCloud.Models.Fornecedor
{
    public class FornecedorModel : IModel
    {
        public int IdFornecedor { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

        public string CodigoBanco { get; set; }
        public string CodigoAgencia { get; set; }
        public string ContaCorrente { get; set; }
        public TipoContaFornecedor TipoConta { get; set; }

        public bool? FornecedorDeProcedimentos { get; set; }

        public List<ContatoFornecedorModel> ContatosFornecedor { get; set; }

        public string toString()
        {
            return $"{NomeFantasia} - {CNPJ}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(RazaoSocial))
                erros.Add("O campo \"Razão Social\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(NomeFantasia))
                erros.Add("O campo \"Nome Fantasia\" é de preenchimento obrigatório");

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
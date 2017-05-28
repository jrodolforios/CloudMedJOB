using MediCloud.Models.Financeiro;
using MediCloud.Models.Fornecedor;
using MediCloud.Models.Parametro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using static MediCloud.Code.Enum.EnumCliente;

namespace MediCloud.Models.Cliente
{
    public class ClienteModel : IModel
    {
        public int IdCliente { get; set; }

        #region Dados
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public tipoEmpresa TipoEmpresa { get; set; }
        public string CNPJ { get; set; }
        #endregion

        #region Endereco
        public string EnderecoCompleto { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string UF {get; set;}
        #endregion

        #region InformacoesAdicionais
        public int? NumeroDeFuncionarios { get; set; }
        public ContadorModel Contador { get; set; }
        public ElaboradorPCMSOModel ElaboradorDoPCMSO { get; set; }
        public ElaboradorPPRAModel ElaboradorDoPPRA { get; set; }
        public SegmentoModel Segmento { get; set; }
        public string Observacoes { get; set; }
        #endregion

        #region contatos
        public List<ContatoModel>  Contatos { get; set; }
        public List<EmpresaModel> Empresas { get; set; }
        #endregion

        #region Funcoes
        public string toString()
        {
            return $"{NomeFantasia} | {CNPJ}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(RazaoSocial))
                erros.Add("O campo \"Razão social\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(NomeFantasia))
                erros.Add("O campo \"Nome fantasia\" é de preenchimento obrigatório");


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
        #endregion
    }
}
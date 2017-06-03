using MediCloud.Code.Enum;
using MediCloud.Models.Parametro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class GrupoDeClientesModel : IModel
    {
        public int IdGrupoCliente { get; set; }

        public string NomeGrupo { get; set; }
        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }
        public EnumCliente.tipoEmpresa TipoEmpresa { get; set; }

        public string Endereco { get; set; }
        public string Bairro { get; set; }

        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }

        public string codigoBB { get; set; }

        public FechamentoModel Fechamento { get; set; }
        public RotaDeEntregaModel RotaDeEntrega { get; set; }
        public SegmentoModel Segmento { get; set; }
        public FormaPagamentoModel FormaPagamento { get; set; }
        public CidadeModel CidadeEntrega { get; set; }

        public EnumFinanceiro.ImprimeNotaFiscal ImprimeNotaFiscal { get; set; }
        public EnumFinanceiro.ModoDeEntrega ModoDeEntrega { get; set; }

        public string Observacoes { get; set; }
        public string ObservacoesNotaFiscal { get; set; }

        public List<CrediarioClienteModel> CrediariosCliente { get; set; }

        public string toString()
        {
            return NomeGrupo;
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeGrupo))
                erros.Add("O campo \"Nome do grupo\" é de preenchimento obrigratório");



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
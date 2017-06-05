using MediCloud.Code.Enum;
using MediCloud.Models.Cliente;
using MediCloud.Models.Parametro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class NotaFiscalModel : IModel
    {
        public int IdNotaFiscal { get; set; }

        public string NumeroNotaFiscal { get; set; }
        public string RazaoSocial { get; set; }

        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string CNPJ { get; set; }

        public DateTime? DataEmissao { get; set; }

        public FaturamentoModel Faturamento { get; set; }
        public bool Imprime { get; set; }

        public decimal? ValorTotal { get; set; }

        public decimal? ValorISS { get; set; }
        public decimal? ValorIRRF { get; set; }
        public decimal? ValorPISCONFINS { get; set; }

        public GrupoDeClientesModel GrupoDeCliente { get; set; }
        public ClienteModel Cliente { get; set; }

        public decimal? ValorDescontoPorPrazo { get; set; }

        public string IdBB { get; set; }

        public DateTime? DataVencimento { get; set; }

        public string ObservacaoNF { get; set; }

        public EnumFinanceiro.ModoDeEntrega ModoEntrega { get; set; }
        public EnumFinanceiro.ImprimeNotaFiscal ImprimeNotaFiscal { get; set; }

        public FormaPagamentoModel FormaDePagamento { get; set; }
        public CidadeModel CidadeCobranca { get; set; }

        public List<DetalheNotaFiscalModel> DetalhesNotaFiscal { get; set; }

        public string toString()
        {
            return $"{RazaoSocial} - {DataEmissao?.ToShortDateString()}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(RazaoSocial))
                erros.Add("O campo \"Razão Social\" é de preenchimento obrigratório");



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
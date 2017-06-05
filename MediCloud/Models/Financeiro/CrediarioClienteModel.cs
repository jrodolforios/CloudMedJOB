using MediCloud.Code.Enum;
using MediCloud.Models.Cliente;
using MediCloud.Models.Parametro;
using MediCloud.Models.Parametro.GrupoProcedimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class CrediarioClienteModel : IModel
    {
        public int IdCrediarioCliente { get; set; }

        public ClienteModel Cliente { get; set; }
        public TabelaPrecoModel Tabela { get; set; }
        public FechamentoModel Fechamento { get; set; }
        public GrupoDeClientesModel GrupoDeClientes { get; set; }
        public CidadeModel CidadeEntrega { get; set; }
        public FormaPagamentoModel FormaPagamento { get; set; }

        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public bool? Imprime { get; set; }
        public bool? Bloqueado { get; set; }

        public string Usuario { get; set; }

        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string CNPJ { get; set; }

        public string IdBB { get; set; }

        public EnumCliente.tipoEmpresa TipoEmpresa { get; set; }

        public string EmpresaSacado {get;set;}
        public string Observacao { get; set; }

        public EnumFinanceiro.ImprimeNotaFiscal ImprimeNotaFiscal { get; set; }
        public EnumFinanceiro.ModoDeEntrega ModoDeDeEntrega { get; set; }

        public string toString()
        {
            return $"{Cliente?.RazaoSocial} - {CNPJ}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (Cliente == null || Cliente.IdCliente <= 0)
                erros.Add("O campo \"Cliente\" é de preenchimento obrigratório");

            if (Tabela == null || Tabela.IdTabela <= 0)
                erros.Add("O campo \"Tabela\" é de preenchimento obrigratório");

            if (Fechamento == null || Fechamento.IdFechamento <= 0)
                erros.Add("O campo \"Fechamento\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(Endereco))
                erros.Add("O campo \"Endereço\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(Bairro))
                erros.Add("O campo \"Bairro\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(Cidade))
                erros.Add("O campo \"Cidade\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(Estado))
                erros.Add("O campo \"Estado\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(CEP))
                erros.Add("O campo \"CEP\" é de preenchimento obrigratório");

            if (!Imprime.HasValue)
                erros.Add("O campo \"Imprime nota fiscal\" é de preenchimento obrigratório");

            if (!Bloqueado.HasValue)
                erros.Add("O campo \"Bloqueado\" é de preenchimento obrigratório");


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
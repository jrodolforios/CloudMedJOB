using MediCloud.Models.Financeiro;
using MediCloud.Models.Funcionario;
using MediCloud.Models.Parametro;
using MediCloud.Models.Recomendacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace MediCloud.Models.Cliente
{
    public class ASOModel : IModel
    {
        public int IdASO { get; set; }

        public DateTime? Data { get; set; }
        public ReferenteModel Referente { get; set; }

        public ClienteModel Cliente { get; set; }
        public TabelaPrecoModel Tabela { get; set; }
        public FuncionarioModel Funcionario { get; set; }
        public CargoModel Cargo { get; set; }
        public SetorModel Setor { get; set; }
        public FormaPagamentoModel FormaPagamento { get; set; }
        public string Observacao { get; set; }
        public string Status { get; set; }
        
        public List<object> ProcedimentosMovimento { get; set; } //TODO: Implementar Procedimentos do Movimento ASO

        public string toString()
        {
            return $"{Cliente.NomeFantasia} - {Funcionario.NomeCompleto}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (Cliente == null || Cliente.IdCliente <= 0)
                erros.Add("O campo \"Cliente\" é de preenchimento obrigratório");

            if (Funcionario == null || Funcionario.IdFuncionario <= 0)
                erros.Add("O campo \"Funcionário\" é de preenchimento obrigratório");

            if (Tabela == null || Tabela.IdTabela <= 0)
                erros.Add("O campo \"Tabela de preço\" é de preenchimento obrigratório");

            if (!Data.HasValue)
                erros.Add("O campo \"Data\" é de preenchimento obrigratório");

            if (Cargo == null || Cargo.IdCargo <= 0)
                erros.Add("O campo \"Cargo\" é de preenchimento obrigratório");

            if (FormaPagamento == null || FormaPagamento.IdFormaPagamento <= 0)
                erros.Add("O campo \"Forma de pagamento\" é de preenchimento obrigratório");

            if (Setor == null || Setor.IdSetor <= 0)
                erros.Add("O campo \"Setor\" é de preenchimento obrigratório");


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
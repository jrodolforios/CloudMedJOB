using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using static MediCloud.Code.Enum.EnumContato;

namespace MediCloud.Models.Fornecedor
{
    public class ContatoFornecedorModel : IModel
    {
        public int IdContatoFornecedor { get; set; }

        public FornecedorModel Fornecedor { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public tipoDepartamento Departamento { get; set; }
        public string Funcao { get; set; }
        public string TelFixo { get; set; }
        public string TelMovel { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }

        public string toString()
        {
            return $"{Nome} - {Departamento}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo \"Nome\" é de preenchimento obrigratório");

            if (Departamento == tipoDepartamento.Vazio)
                erros.Add("O campo \"Departamento\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(Funcao))
                erros.Add("O campo \"Função\" é de preenchimento obrigratório");


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
using MediCloud.Code.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using static MediCloud.Code.Enum.EnumContato;

namespace MediCloud.Models.Fornecedor
{
    public class ContatoModel : IModel
    {
        public int IdContato { get; set; }
        public int IdCliente { get; set; }
        public string NomeContato { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Funcao { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelfoneMovel { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        public tipoDepartamento Departamento { get; set; }
        public string siglaDepartamento
        {
            get
            {
                return CadastroDeContato.GetDepartamento(Departamento);
            }
        }


        public string toString()
        {
            return $"{NomeContato} - {Funcao}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeContato))
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
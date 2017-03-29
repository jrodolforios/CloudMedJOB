using MediCloud.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Funcionario
{
    public class FuncionarioModel : IModel
    {
        public int IdFuncionario { get; set; }
        public bool? Inativo { get; set; }

        public ClienteModel Empresa { get; set; }

        public string NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }

        public string RG { get; set; }
        public string CTPS { get; set; }

        public string Matricula { get; set; }
        public string CodigoNexo { get; set; }

        public DateTime? UltimoMovimento { get; set; }

        public string TelFixo { get; set; }
        public string TelMovel { get; set; }

        public string Endereco { get; set; }

        public string toString()
        {
            return $"{NomeCompleto} - {Empresa.NomeFantasia}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (Empresa == null)
                erros.Add("O campo \"Empresa\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(NomeCompleto))
                erros.Add("O campo \"Nome completo\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(TelFixo))
                erros.Add("O campo \"Telefone fixo\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(TelMovel))
                erros.Add("O campo \"Telefone móvel\" é de preenchimento obrigatório");

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
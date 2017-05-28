using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Cliente
{
    public class EmpresaModel : IModel
    {
        public int IdEmpresa { get; set; }

        public string NomeEmpresa { get; set; }
        public string Telefone { get; set; }
        public string NomeResponsavel { get; set; }
        public string Email { get; set; }

        public ClienteModel Cliente { get; set; }

        public string toString()
        {
            return NomeEmpresa;
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeEmpresa))
                erros.Add("O campo \"Nome da empresa\" é de preenchimento obrigratório");

            if (Cliente == null || Cliente.IdCliente <= 0)
                erros.Add("A empresa deve estar associada a um cliente.");


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
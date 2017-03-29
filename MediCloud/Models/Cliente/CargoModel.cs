using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Cliente
{
    public class CargoModel : IModel
    {
        public int IdCargo { get; set; }
        public bool Ativo { get; set; }
        public string NomeCargo { get; set; }
        public string Abreviatura { get; set; }
        public string CodigoNexo { get; set; }

        public string toString()
        {
            return $"{Abreviatura} - {NomeCargo}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeCargo))
                erros.Add("O campo \"Nome do cargo\" é de preenchimento obrigratório");


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
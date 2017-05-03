using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using static MediCloud.Code.Enum.EnumParametro;

namespace MediCloud.Models.Parametro
{
    public class CidadeModel : IModel
    {
        public int IdCidade { get; set; }

        public string NomeCidade { get; set; }

        public EstadoEnum Estado { get; set; }

        public int? IdentificacaoNF { get; set; }

        public string toString()
        {
            return $"{NomeCidade} ({Estado})";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeCidade))
                erros.Add("O campo \"Nome\" é de preenchimento obrigratório");

            if (Estado == EstadoEnum.Vazio)
                erros.Add("O campo \"Estado\" é de preenchimento obrigratório");


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
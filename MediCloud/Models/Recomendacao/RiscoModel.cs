using MediCloud.Code.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Recomendacao
{
    public class RiscoModel : IModel
    {
        public int IdRisco { get; set; }

        public string NomeRisco { set; get; }

        public EnumRecomendacao.eventualidadeEnum Eventualidade { get; set; }
        public NaturezaModel Natureza { get; set; }

        public string toString()
        {
            return NomeRisco;
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeRisco))
                erros.Add("O campo \"Nome do risco\" é de preenchimento obrigratório");

            if (Eventualidade == EnumRecomendacao.eventualidadeEnum.vazio)
                erros.Add("O campo \"Eventualidade\" é de preenchimento obrigratório");


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
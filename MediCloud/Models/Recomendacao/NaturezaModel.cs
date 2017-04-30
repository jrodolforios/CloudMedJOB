using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Recomendacao
{
    public class NaturezaModel : IModel
    {
        public int IdNatureza { get; set; }
        public string NomeNatureza { get; set; }

        public List<RiscoModel> Riscos { get; set; }

        public string toString()
        {
            throw new NotImplementedException();
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeNatureza))
                erros.Add("O campo \"Nome da natureza\" é de preenchimento obrigratório");


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
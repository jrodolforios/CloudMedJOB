using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Parametro
{
    public class FechamentoModel : IModel
    {
        public int IdFechamento { get; set; }
        public int? DiaFechamento { get; set; }

        public string PeriodoApuracao { get; set; }
        public int? DiasPrazoBoleto { get; set; }

        public string toString()
        {
            return $"Dia do fechamento:{DiaFechamento} - {PeriodoApuracao}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (!DiaFechamento.HasValue)
                erros.Add("O campo \"Dia\" é de preenchimento obrigratório");


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
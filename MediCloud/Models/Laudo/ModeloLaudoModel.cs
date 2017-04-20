using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Laudo
{
    public class ModeloLaudoModel : IModel
    {
        public int IdModeloLaudo { get; set; }
        public string NomeModelo { get; set; }
        public string CorpoModelo { get; set; }
        public string Conclusao { get; set; }
        public string Rodape { get; set; }

        public string toString()
        {
            return NomeModelo;
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeModelo))
                erros.Add("O campo \"Nome\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(CorpoModelo))
                erros.Add("O campo \"Laudo\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(Conclusao))
                erros.Add("O campo \"Conclusão\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(Rodape))
                erros.Add("O campo \"Rodapé\" é de preenchimento obrigratório");


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
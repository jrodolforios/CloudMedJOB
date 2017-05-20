using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class RotaDeEntregaModel : IModel
    {
        public int IdRotaDeEntrega { get; set; }

        public string NomeRotaDeEntrega { get; set; }
        public string Observacao { get; set; }

        public string toString()
        {
            return NomeRotaDeEntrega;
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(NomeRotaDeEntrega))
                erros.Add("O campo \"Nome da rota de entrega\" é de preenchimento obrigratório");



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
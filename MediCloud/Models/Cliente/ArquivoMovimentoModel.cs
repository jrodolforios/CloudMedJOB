using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Cliente
{
    public class ArquivoMovimentoModel :IModel
    {
        public int IdArquivo { get; set; }
        public byte[] Arquivo { get; set; }
        public ASOModel Movimento {get;set;}
        public DateTime DataEnvio { get; set; }
        public string NomeArquivo { get; set; }

        public string toString()
        {
            return NomeArquivo;
        }


        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (Arquivo == null || Arquivo.Length <= 0)
                erros.Add("Você deve inserir um arquivo válido para enviar.");

            if (Movimento == null || Movimento.IdASO <= 0)
                erros.Add("O campo \"Movimento\" é de preenchimento obrigratório");

            if (DataEnvio <= DateTime.MinValue)
                erros.Add("O campo \"Data de envio\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(NomeArquivo))
                erros.Add("O campo \"Nome do arquivo\" é de preenchimento obrigratório");


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
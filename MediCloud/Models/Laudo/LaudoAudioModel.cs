using MediCloud.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Laudo
{
    public class LaudoAudioModel : IModel
    {
        public int IdLaudoAudio { get; set; }

        public DateTime? DataProxAvaliacao { get; set; }

        public ProcedimentoMovimentoModel ProcedimentoMovimento { get; set; }

        public int? OD250 { get; set; }
        public int? OD500 { get; set; }
        public int? OD1K { get; set; }
        public int? OD2K { get; set; }
        public int? OD3K { get; set; }
        public int? OD4K { get; set; }
        public int? OD6K { get; set; }
        public int? OD8K { get; set; }

        public int? ODO250 { get; set; }
        public int? ODO500 { get; set; }
        public int? ODO1K { get; set; }
        public int? ODO2K { get; set; }
        public int? ODO3K { get; set; }
        public int? ODO4K { get; set; }
        public int? ODO6K { get; set; }
        public int? ODO8K { get; set; }

        public int? OE250 { get; set; }
        public int? OE500 { get; set; }
        public int? OE1K { get; set; }
        public int? OE2K { get; set; }
        public int? OE3K { get; set; }
        public int? OE4K { get; set; }
        public int? OE6K { get; set; }
        public int? OE8K { get; set; }

        public int? OEO250 { get; set; }
        public int? OEO500 { get; set; }
        public int? OEO1K { get; set; }
        public int? OEO2K { get; set; }
        public int? OEO3K { get; set; }
        public int? OEO4K { get; set; }
        public int? OEO6K { get; set; }
        public int? OEO8K { get; set; }

        public string Observavao { get; set; }

        public string toString()
        {
            return $"{ProcedimentoMovimento.Procedimento?.Nome} - {IdLaudoAudio}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (ProcedimentoMovimento == null || ProcedimentoMovimento.IdMovimentoProcedimento <= 0)
                erros.Add("O campo \"Nome\" é de preenchimento obrigratório");

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
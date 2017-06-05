using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Financeiro
{
    public class FaturamentoModel : IModel
    {
        public int IdFaturamento { get; set; }

        public string Mes { get; set; }
        public int Ano { get; set; }

        public string Usuario { get; set; }
        public DateTime? Data { get; set; }

        public decimal? Valor { get; set; }

        public int Dia { get; set; }
        
        //Os parâmetros abaixo ("IdClienteInicio" e "IdClienteFim") estão sempre sendo persistidos
        //com os valores 1 e 999999 respectivamente.
        public int IdClienteInicio { get { return 1; } }
        public int IdClienteFim { get { return 999999; } }

        public DateTime? DataLimite { get; set; }

        public List<NotaFiscalModel> NotasFiscais { get; set; }

        public string toString()
        {
            return $"{Mes}/{Ano} - {Valor}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(Mes))
                erros.Add("O campo \"Mês\" é de preenchimento obrigratório");

            if (Ano <= 0)
                erros.Add("O campo \"Ano\" é de preenchimento obrigratório");

            if (Dia <= 0)
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
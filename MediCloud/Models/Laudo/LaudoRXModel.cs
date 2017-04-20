using MediCloud.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using static MediCloud.Code.Enum.EnumLaudo;

namespace MediCloud.Models.Laudo
{
    public class LaudoRXModel : IModel
    {
        public ProcedimentoMovimentoModel ProcedimentoMovimento { get; set; }
        public string Medico { get; set; }
        public string Paciente { get; set; }
        public StatusLiberadoLaudo Status { get; set; }
        public DateTime Data { get; set; }
        public int Idade { get; set; }
        public ModeloLaudoModel ModeloLaudo { get; set; }

        public string LaudoNegrito { get; set; }
        public string CorpoLaudo { get; set; }
        public string Conclusao { get; set; }
        public string Rodape { get; set; }

        public string toString()
        {
            return $"{Medico} - {Paciente} ({Data.ToShortDateString()})";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (ProcedimentoMovimento == null || ProcedimentoMovimento.IdMovimentoProcedimento <= 0)
                erros.Add("O campo \"Procedimento de movimento\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(Medico))
                erros.Add("O campo \"Médico\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(Paciente))
                erros.Add("O campo \"Paciente\" é de preenchimento obrigatório");

            if (Data == DateTime.MinValue || Data == DateTime.MaxValue)
                erros.Add("O campo \"Data\" é de preenchimento obrigatório");

            if (Idade <= 0)
                erros.Add("O campo \"Idade\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(CorpoLaudo))
                erros.Add("O campo \"Laudo\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(Conclusao))
                erros.Add("O campo \"Conclusão\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(Rodape))
                erros.Add("O campo \"Rodapé\" é de preenchimento obrigatório");

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
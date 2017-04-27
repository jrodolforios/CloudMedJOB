using MediCloud.Models.Cliente;
using MediCloud.Models.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using static MediCloud.Code.Enum.DefaultEnum;
using static MediCloud.Code.Enum.EnumLaudo;

namespace MediCloud.Models.Laudo
{
    public class LaudoVisaoModel : IModel
    {
        public int IdLaudo { get; set; }

        public DateTime? DataLaudo { get; set; }

        public ClienteModel Cliente { get; set; }
        public FuncionarioModel Funcionario { get; set; }
        public CargoModel Cargo { get; set; }

        public CorrecaoAcuidadeVisual Correcao { get; set; }
        public string OD { get; set; }
        public string OE { get; set; }

        public string COD { get; set; }
        public string COE { get; set; }

        public EnumSimNao Estrabismo { get; set; }
        public EnumVisaoCromatica VisaoCromatica { get; set; }
        public string Conclusao { get; set; }


        public string toString()
        {
            return $"[{IdLaudo}] - {DataLaudo.Value.ToShortDateString()}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (!DataLaudo.HasValue)
                erros.Add("O campo \"Data do laudo\" é de preenchimento obrigatório");

            if (Correcao == CorrecaoAcuidadeVisual.vazio)
                erros.Add("O campo \"Correção\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(OD))
                erros.Add("O campo \"O.D.\" é de preenchimento obrigatório");

            if (string.IsNullOrEmpty(OE))
                erros.Add("O campo \"O.E.\" é de preenchimento obrigatório");

            if (Estrabismo == EnumSimNao.vazio)
                erros.Add("O campo \"Estrabismo\" é de preenchimento obrigatório");

            if (VisaoCromatica == EnumVisaoCromatica.vazio)
                erros.Add("O campo \"Visão Cromática\" é de preenchimento obrigatório");

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
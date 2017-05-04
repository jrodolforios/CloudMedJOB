using MediCloud.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using static MediCloud.Code.Enum.EnumParametro;

namespace MediCloud.Models.Parametro
{
    public class DadosOcupacionaisModel : IModel
    {
        public ClienteModel Cliente { get; set; }

        public bool NaoDeseja { get; set; }
        public string CodigoNexo { get; set; }
        public DateTime? Emissao { get; set; }
        public DateTime? Vencimento { get; set; }

        public string Observacao { get; set; }

        public ElaboradorPCMSOModel ElaboradorPCMSO { get; set; }
        public ElaboradorPPRAModel ElaboradorPPRA { get; set; }

        public StatusPCMSO StatusPCMSOSel { get; set; }

        public string toString()
        {
            return $"{Cliente.RazaoSocial} - {StatusPCMSOSel}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (StatusPCMSOSel == StatusPCMSO.Vazio)
                erros.Add("O campo \"Status do PCMSO\" é de preenchimento obrigratório");

            if (Cliente == null || Cliente.IdCliente <= 0)
                erros.Add("O campo \"Cliente\" é de preenchimento obrigratório");


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
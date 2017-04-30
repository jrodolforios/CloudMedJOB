using MediCloud.Models.Cliente;
using MediCloud.Models.Parametro.GrupoProcedimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Recomendacao
{
    public class RecomendacaoModel : IModel
    {
        public int IdRecomendacao { get; set; }

        public CargoModel Cargo { get; set; }
        public ClienteModel Cliente { get; set; }
        public SetorModel Setor { get; set; }

        public List<RiscoModel> Riscos { get; set; }
        public Dictionary<ReferenteModel, List<ProcedimentoModel>> ReferenciasProcedimentos { get; set; }

        public string toString()
        {
            return $"{Cliente.RazaoSocial}_{Cargo.NomeCargo} - {Setor.NomeSetor}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (Cargo == null || Cargo.IdCargo <= 0)
                erros.Add("O campo \"Cargo\" é de preenchimento obrigratório");

            if (Setor == null || Setor.IdSetor <= 0)
                erros.Add("O campo \"Setor\" é de preenchimento obrigratório");

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
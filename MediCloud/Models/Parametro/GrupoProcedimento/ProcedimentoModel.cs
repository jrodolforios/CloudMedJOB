using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediCloud.Models.Parametro.GrupoProcedimento
{
    public class ProcedimentoModel: IModel
    {
        public int IdProcedimento { get; set; }

        public string Nome { get; set; }
        public string Complemento { get; set; }
        public string Sigla { get; set; }
        public string CODNEXO { get; set; }

        public SubGrupoModel SubGrupo { get; set; }

        public bool? ZeraAutomaticamente { get; set; }
        public bool? confirmaAutomaticamente { get; set; }

        public ProfissionalModel Profissional { get; set; }

        public string toString()
        {
            return $"({Sigla}){Nome} - {Complemento}";
        }

        public void validar()
        {
            List<string> erros = new List<string>();
            string errosTratados = string.Empty;

            if (string.IsNullOrEmpty(Sigla))
                erros.Add("O campo \"Sigla\" é de preenchimento obrigratório");

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo \"Nome\" é de preenchimento obrigatório");

            if (SubGrupo == null && SubGrupo.IdSubGrupo <= 0)
                erros.Add("O campo \"Subgrupo\" é de preenchimento obrigatório");

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
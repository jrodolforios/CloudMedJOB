using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Parametro.GrupoProcedimento;

namespace MediCloud.Code.Parametro.GrupoProcedimento
{
    public class CadastroDeSubGrupo
    {
        internal static SubGrupoModel GetSubGrupoPorID(int IdSubGrupo)
        {
            if (IdSubGrupo > 0)
            {
                PROCEDIMENTO_GRUPO_SUBGRUP usuarioencontrado = ControleDeSubGrupo.recuperarSubGrupoPorID(IdSubGrupo);
                return injetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        public static SubGrupoModel injetarEmUsuarioModel(PROCEDIMENTO_GRUPO_SUBGRUP x)
        {
            if (x == null)
                return null;
            else
                return new SubGrupoModel()
                {
                    IdSubGrupo = (int)x.IDSUBGRUPRO,
                    Nome = x.SUBGRUPO,
                    Grupo = CadastroDeGrupo.getGrupoPorID((int)(x.IDGRUPRO.HasValue ? x.IDGRUPRO.Value : 0))
                };
        }
    }
}
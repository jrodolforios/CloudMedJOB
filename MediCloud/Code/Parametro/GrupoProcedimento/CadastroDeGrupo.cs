using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Parametro.GrupoProcedimento;

namespace MediCloud.Code.Parametro.GrupoProcedimento
{
    public class CadastroDeGrupo
    {
        internal static GrupoModel getGrupoPorID(int v)
        {
            if (v > 0)
            {
                PROCEDIMENTO_GRUPO usuarioencontrado = ControleDeGrupo.recuperarSubGrupoPorID(v);
                return injetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        public static GrupoModel injetarEmUsuarioModel(PROCEDIMENTO_GRUPO x)
        {
            if (x == null)
                return null;
            else
                return new GrupoModel()
                {
                    IdGrupo = (int)x.IDGRUPRO,
                    Nome = x.GRUPOPROCEDIMENTO
                };
        }
    }
}
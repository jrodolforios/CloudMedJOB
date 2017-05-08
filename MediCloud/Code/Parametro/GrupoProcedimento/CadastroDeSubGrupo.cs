using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Parametro.GrupoProcedimento;
using System.Web.Mvc;
using MediCloud.Controllers;

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

        public static SubGrupoModel injetarEmUsuarioModel(FormCollection x)
        {
            return new SubGrupoModel()
            {
                IdSubGrupo = string.IsNullOrEmpty(x["codigoSubGrupo"]) ? 0 : Convert.ToInt32(x["codigoSubGrupo"]),
                Nome = string.IsNullOrEmpty(x["nomeSubGrupo"]) ? null : x["nomeSubGrupo"],
                Grupo = CadastroDeGrupo.getGrupoPorID(string.IsNullOrEmpty(x["idGrupo"]) ? 0 : Convert.ToInt32(x["idGrupo"]))
            };
        }

        internal static List<SubGrupoModel> RecuperarSubGrupoPorTermo(FormCollection form)
        {
            string termo = form["keywords"];
            List<SubGrupoModel> listaDeModels = new List<SubGrupoModel>();

            List<PROCEDIMENTO_GRUPO_SUBGRUP> usuarioDoBanco = ControleDeSubGrupo.RecuperarSubGrupoPorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static List<SubGrupoModel> RecuperarSubGrupoPorTermo(string prefix)
        {
            List<SubGrupoModel> listaDeModels = new List<SubGrupoModel>();

            List<PROCEDIMENTO_GRUPO_SUBGRUP> usuarioDoBanco = ControleDeSubGrupo.RecuperarSubGrupoPorTermo(prefix);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static SubGrupoModel SalvarSubGrupo(FormCollection form)
        {
            SubGrupoModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            PROCEDIMENTO_GRUPO_SUBGRUP subGrupoDAO = injetarEmUsuarioDAO(usuarioModel);
            subGrupoDAO = ControleDeSubGrupo.SalvarSubGrupo(subGrupoDAO);

            usuarioModel = injetarEmUsuarioModel(subGrupoDAO);

            return usuarioModel;
        }

        private static PROCEDIMENTO_GRUPO_SUBGRUP injetarEmUsuarioDAO(SubGrupoModel x)
        {
            if (x == null)
                return null;
            else
                return new PROCEDIMENTO_GRUPO_SUBGRUP()
                {
                    IDGRUPRO = x.Grupo?.IdGrupo,
                    IDSUBGRUPRO = x.IdSubGrupo,
                    SUBGRUPO = x.Nome
                };
        }

        internal static void DeletarSubGrupo(SubGrupoController subGrupoController, int codigoDoSubGrupo)
        {
            ControleDeSubGrupo.DeletarSubGrupo(codigoDoSubGrupo);
        }
    }
}
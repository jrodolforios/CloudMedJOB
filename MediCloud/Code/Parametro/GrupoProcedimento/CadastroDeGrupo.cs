using MediCloud.BusinessProcess.Parametro.GrupoProcedimento;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro.GrupoProcedimento;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Parametro.GrupoProcedimento
{
    public class CadastroDeGrupo
    {
        #region Public Methods

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

        public static GrupoModel injetarEmUsuarioModel(FormCollection x)
        {
            return new GrupoModel()
            {
                IdGrupo = string.IsNullOrEmpty(x["codigoGrupoDeProcedimento"]) ? 0 : Convert.ToInt32(x["codigoGrupoDeProcedimento"]),
                Nome = string.IsNullOrEmpty(x["nomeGrupoDeProcedimento"]) ? null : x["nomeGrupoDeProcedimento"]
            };
        }

        #endregion Public Methods

        #region Internal Methods

        internal static void DeletarGrupo(GrupoDeProcedimentoController grupoDeProcedimentoController, int codigoDoGrupoProcedimento)
        {
            ControleDeGrupo.DeletarGrupo(codigoDoGrupoProcedimento);
        }

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

        internal static List<GrupoModel> RecuperarGrupoPorTermo(FormCollection form)
        {
            string termo = form["keywords"];
            List<GrupoModel> listaDeModels = new List<GrupoModel>();

            List<PROCEDIMENTO_GRUPO> usuarioDoBanco = ControleDeGrupo.RecuperarGrupoPorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static List<GrupoModel> RecuperarGrupoPorTermo(string termo)
        {
            List<GrupoModel> listaDeModels = new List<GrupoModel>();

            List<PROCEDIMENTO_GRUPO> usuarioDoBanco = ControleDeGrupo.RecuperarGrupoPorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static GrupoModel SalvarGrupo(FormCollection form)
        {
            GrupoModel grupoModel = injetarEmUsuarioModel(form);
            grupoModel.validar();

            PROCEDIMENTO_GRUPO grupoDAO = injetarEmUsuarioDAO(grupoModel);
            grupoDAO = ControleDeGrupo.SalvarGrupo(grupoDAO);

            grupoModel = injetarEmUsuarioModel(grupoDAO);

            return grupoModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static PROCEDIMENTO_GRUPO injetarEmUsuarioDAO(GrupoModel x)
        {
            if (x == null)
                return null;
            else
                return new PROCEDIMENTO_GRUPO()
                {
                    GRUPOPROCEDIMENTO = x.Nome,
                    IDGRUPRO = x.IdGrupo
                };
        }

        #endregion Private Methods
    }
}
using MediCloud.BusinessProcess.Recomendacao;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Recomendacao;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Recomendacao
{
    public class CadastroDeSetor
    {
        #region Internal Methods

        internal static List<SetorModel> buscarSetor(FormCollection form)
        {
            string termo = form["keywords"];
            List<SetorModel> listaDeModels = new List<SetorModel>();

            List<SETOR> usuarioDoBanco = ControleDeSetor.buscarSetorPorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static SetorModel buscarSetorPorID(int v)
        {
            if (v != 0)
            {
                SETOR cargoEncontrado = ControleDeSetor.buscarSetorPorID(v);
                return injetarEmUsuarioModel(cargoEncontrado);
            }
            else
                return null;
        }

        internal static void DeletarSetor(SetorController setorController, int codigoDoSetor)
        {
            ControleDeSetor.ExcluirSetor(codigoDoSetor);
        }

        internal static SETOR injetarEmUsuarioDAO(SetorModel x)
        {
            if (x == null)
                return null;
            else
                return new SETOR()
                {
                    IDSETOR = x.IdSetor,
                    SETOR1 = x.NomeSetor
                };
        }

        internal static SetorModel RecuperarSetorPorID(int IdRef)
        {
            if (IdRef != 0)
            {
                SETOR referenteEncontrado = ControleDeSetor.buscarSetorPorID(IdRef);
                return injetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        internal static List<SetorModel> RecuperarSetorPorTermo(string prefix)
        {
            List<SETOR> contadoresEncontrados = ControleDeSetor.buscarSetorPorTermo(prefix);
            List<SetorModel> resultados = new List<SetorModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static SetorModel SalvarSetor(FormCollection form)
        {
            SetorModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            SETOR cargoDAO = injetarEmUsuarioDAO(usuarioModel);
            cargoDAO = ControleDeSetor.SalvarSetor(cargoDAO);

            usuarioModel = injetarEmUsuarioModel(cargoDAO);

            return usuarioModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static SetorModel injetarEmUsuarioModel(SETOR referenteEncontrado)
        {
            if (referenteEncontrado == null)
                return null;
            else
                return new SetorModel()
                {
                    IdSetor = (int)referenteEncontrado.IDSETOR,
                    NomeSetor = referenteEncontrado.SETOR1
                };
        }

        private static SetorModel injetarEmUsuarioModel(FormCollection form)
        {
            return new SetorModel()
            {
                IdSetor = string.IsNullOrEmpty(form["codigoSetor"]) ? 0 : Convert.ToInt32(form["codigoSetor"]),
                NomeSetor = string.IsNullOrEmpty(form["nomeSetor"]) ? null : form["nomeSetor"]
            };
        }

        #endregion Private Methods
    }
}
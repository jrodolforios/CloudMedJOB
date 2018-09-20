using MediCloud.BusinessProcess.Parametro;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeElaboradorPPRA
    {
        #region Internal Methods

        internal static ElaboradorPPRAModel BuscarElaboradorPorID(decimal? idEPPRA)
        {
            if (idEPPRA != 0)
            {
                EPPRA elaboradorEncontrado = ControleDeElaboradorPPRA.BuscarElaboradorPorID(idEPPRA.HasValue ? (int)idEPPRA.Value : 0);
                return InjetarEmUsuarioModel(elaboradorEncontrado);
            }
            else
                return null;
        }

        internal static void DeletarElaboradorPPRA(int codigoElaboradorPPRA)
        {
            ControleDeElaboradorPPRA.DeletarElaboradorPPRA(codigoElaboradorPPRA);
        }

        internal static ElaboradorPPRAModel InjetarEmUsuarioModel(EPPRA ePPRA)
        {
            if (ePPRA == null)
                return null;
            else
                return new ElaboradorPPRAModel()
                {
                    IdElaboradorPPRA = (int)ePPRA.IDEPPRA,
                    NomeElaboradorDoPPRA = ePPRA.ELABORADORPPRA
                };
        }

        internal static List<ElaboradorPPRAModel> RecuperarElaboradorPorTermo(string prefix)
        {
            List<EPPRA> contadoresEncontrados = ControleDeElaboradorPPRA.BuscarElaboradoresPorTermo(prefix);
            List<ElaboradorPPRAModel> resultados = new List<ElaboradorPPRAModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static List<ElaboradorPPRAModel> RecuperarElaboradorPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            return RecuperarElaboradorPorTermo(prefix);
        }

        internal static ElaboradorPPRAModel SalvarElaboradorPPRA(FormCollection form)
        {
            ElaboradorPPRAModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            EPPRA ElaboradorPPRADAO = InjetarEmUsuarioDAO(usuarioModel);
            ElaboradorPPRADAO = ControleDeElaboradorPPRA.SalvarElaboradorPPRA(ElaboradorPPRADAO);

            usuarioModel = InjetarEmUsuarioModel(ElaboradorPPRADAO);

            return usuarioModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static EPPRA InjetarEmUsuarioDAO(ElaboradorPPRAModel usuarioModel)
        {
            if (usuarioModel == null)
                return null;
            else
                return new EPPRA()
                {
                    ELABORADORPPRA = usuarioModel.NomeElaboradorDoPPRA,
                    IDEPPRA = usuarioModel.IdElaboradorPPRA
                };
        }

        private static ElaboradorPPRAModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new ElaboradorPPRAModel()
            {
                IdElaboradorPPRA = string.IsNullOrEmpty(form["codigoElaboradorPPRA"]) ? 0 : Convert.ToInt32(form["codigoElaboradorPPRA"]),
                NomeElaboradorDoPPRA = string.IsNullOrEmpty(form["nomeElaboradorPPRA"]) ? null : form["nomeElaboradorPPRA"]
            };
        }

        #endregion Private Methods
    }
}
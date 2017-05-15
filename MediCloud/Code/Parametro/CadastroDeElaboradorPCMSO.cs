using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro;
using MediCloud.BusinessProcess;
using MediCloud.BusinessProcess.Parametro;
using System.Web.Mvc;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeElaboradorPCMSO
    {
        internal static ElaboradorPCMSOModel InjetarEmUsuarioModel(EPCMSO ePCMSO)
        {
            if (ePCMSO == null)
                return null;
            else
                return new ElaboradorPCMSOModel()
            {
                IdElaboradorPCMSO = (int)ePCMSO.IDEPCMSO,
                NomeElaboradorPCMSO = ePCMSO.ELABORADORPCMSO
            };
        }

        internal static List<ElaboradorPCMSOModel> RecuperarElaboradorPorTermo(string prefix)
        {
            List<EPCMSO> contadoresEncontrados = ControleDeElaboradorPCMSO.BuscarElaboradoresPorTermo(prefix);
            List<ElaboradorPCMSOModel> resultados = new List<ElaboradorPCMSOModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static List<ElaboradorPCMSOModel> RecuperarElaboradorPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            return RecuperarElaboradorPorTermo(prefix);

        }

        internal static ElaboradorPCMSOModel BuscarElaboradorPorID(decimal? idEPCMSO)
        {
            if (idEPCMSO != 0)
            {
                EPCMSO elaboradorEncontrado = ControleDeElaboradorPCMSO.BuscarElaboradorPorID(idEPCMSO.HasValue ? (int)idEPCMSO.Value : 0);
                return InjetarEmUsuarioModel(elaboradorEncontrado);
            }
            else
                return null;
        }

        internal static void DeletarElaboradorPCMSO(int codigoElaboradorPCMSO)
        {
            ControleDeElaboradorPCMSO.DeletarElaboradorPCMSO(codigoElaboradorPCMSO);
        }

        internal static ElaboradorPCMSOModel SalvarElaboradorPCMSO(FormCollection form)
        {
            ElaboradorPCMSOModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            EPCMSO ElaboradorPCMSODAO = InjetarEmUsuarioDAO(usuarioModel);
            ElaboradorPCMSODAO = ControleDeElaboradorPCMSO.SalvarElaboradorPCMSO(ElaboradorPCMSODAO);

            usuarioModel = InjetarEmUsuarioModel(ElaboradorPCMSODAO);

            return usuarioModel;
        }

        private static EPCMSO InjetarEmUsuarioDAO(ElaboradorPCMSOModel usuarioModel)
        {
            if (usuarioModel == null)
                return null;
            else
                return new EPCMSO()
                {
                    ELABORADORPCMSO = usuarioModel.NomeElaboradorPCMSO,
                    IDEPCMSO = usuarioModel.IdElaboradorPCMSO
                };
        }

        private static ElaboradorPCMSOModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new ElaboradorPCMSOModel()
            {
                IdElaboradorPCMSO = string.IsNullOrEmpty(form["codigoElaboradorPCMSO"]) ? 0 : Convert.ToInt32(form["codigoElaboradorPCMSO"]),
                NomeElaboradorPCMSO = string.IsNullOrEmpty(form["nomeElaboradorPCMSO"]) ? null : form["nomeElaboradorPCMSO"]
            };
        }
    }
}
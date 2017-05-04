using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro;
using MediCloud.BusinessProcess;
using MediCloud.BusinessProcess.Parametro;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeElaboradorPCMSO
    {
        internal static ElaboradorPCMSOModel injetarEmUsuarioModel(EPCMSO ePCMSO)
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
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static ElaboradorPCMSOModel BuscarElaboradorPorID(decimal? idEPCMSO)
        {
            if (idEPCMSO != 0)
            {
                EPCMSO elaboradorEncontrado = ControleDeElaboradorPCMSO.BuscarElaboradorPorID(idEPCMSO.HasValue ? (int)idEPCMSO.Value : 0);
                return injetarEmUsuarioModel(elaboradorEncontrado);
            }
            else
                return null;
        }
    }
}
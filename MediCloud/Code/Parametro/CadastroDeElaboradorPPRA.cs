using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro;
using MediCloud.BusinessProcess.Parametro;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeElaboradorPPRA
    {
        internal static ElaboradorPPRAModel injetarEmUsuarioModel(EPPRA ePPRA)
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
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static ElaboradorPPRAModel BuscarElaboradorPorID(decimal? idEPPRA)
        {
            if (idEPPRA != 0)
            {
                EPPRA elaboradorEncontrado = ControleDeElaboradorPPRA.BuscarElaboradorPorID(idEPPRA.HasValue ? (int)idEPPRA.Value : 0);
                return injetarEmUsuarioModel(elaboradorEncontrado);
            }
            else
                return null;
        }
    }
}
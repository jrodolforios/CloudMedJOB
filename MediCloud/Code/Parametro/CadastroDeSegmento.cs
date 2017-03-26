using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro;
using MediCloud.BusinessProcess.Parametro;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeSegmento
    {
        internal static SegmentoModel injetarEmUsuarioModel(SEGMENTO sEGMENTO)
        {
            if (sEGMENTO == null)
                return null;
            else
                return new SegmentoModel()
            {
                IdSegmento = (int)sEGMENTO.IDSEG,
                NomeSegmento = sEGMENTO.SEGMENTO1
            };
        }

        internal static List<SegmentoModel> RecuperarSegmentoPorTermo(string prefix)
        {
            List<SEGMENTO> contadoresEncontrados = ControleDeSegmento.BuscarSegmentosPorTermo(prefix);
            List<SegmentoModel> resultados = new List<SegmentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }
    }
}
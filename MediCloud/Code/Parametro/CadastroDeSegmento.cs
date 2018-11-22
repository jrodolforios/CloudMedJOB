using MediCloud.BusinessProcess.Parametro;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeSegmento
    {
        #region Internal Methods

        internal static SegmentoModel buscarSegmentoPorID(int v)
        {
            SEGMENTO segmentoEncontrado = ControleDeSegmento.BuscarSegmentoPorID(v);
            return InjetarEmUsuarioModel(segmentoEncontrado);
        }

        internal static void DeletarSegmento(int codigoSegmento)
        {
            ControleDeSegmento.DeletarSegmento(codigoSegmento);
        }

        internal static SegmentoModel InjetarEmUsuarioModel(SEGMENTO sEGMENTO)
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
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static List<SegmentoModel> RecuperarSegmentoPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            List<SEGMENTO> contadoresEncontrados = ControleDeSegmento.BuscarSegmentosPorTermo(prefix);
            List<SegmentoModel> resultados = new List<SegmentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static SegmentoModel SalvarSegmento(FormCollection form)
        {
            SegmentoModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            SEGMENTO segmentoDAO = InjetarEmUsuarioDAO(usuarioModel);
            segmentoDAO = ControleDeSegmento.SalvarSegmento(segmentoDAO);

            usuarioModel = InjetarEmUsuarioModel(segmentoDAO);

            return usuarioModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static SEGMENTO InjetarEmUsuarioDAO(SegmentoModel usuarioModel)
        {
            if (usuarioModel == null)
                return null;
            else
                return new SEGMENTO()
                {
                    IDSEG = usuarioModel.IdSegmento,
                    SEGMENTO1 = usuarioModel.NomeSegmento
                };
        }

        private static SegmentoModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new SegmentoModel()
            {
                IdSegmento = string.IsNullOrEmpty(form["codigoSegmento"]) ? 0 : Convert.ToInt32(form["codigoSegmento"]),
                NomeSegmento = string.IsNullOrEmpty(form["nomeSegmento"]) ? null : form["nomeSegmento"]
            };
        }

        #endregion Private Methods
    }
}
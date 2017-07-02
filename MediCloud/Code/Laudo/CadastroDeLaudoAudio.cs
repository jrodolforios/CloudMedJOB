using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Laudo;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Laudo;
using MediCloud.Code.Clientes;
using MediCloud.Controllers;

namespace MediCloud.Code.Laudo
{
    public class CadastroDeLaudoAudio
    {
        internal static List<LaudoAudioModel> buscarLaudoAudio(FormCollection form)
        {
            string termo = form["keywords"];
            List<LaudoAudioModel> listaDeModels = new List<LaudoAudioModel>();

            List<LAUDOAUD> usuarioDoBanco = ControleDeLaudoAudio.buscarLaudoAudio(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmUsuarioModel(x, false));
            });

            return listaDeModels;
        }

        internal static LaudoAudioModel RecuperarLaudoAudioPorID(int v)
        {
            LAUDOAUD LaudoRXEncontrado = ControleDeLaudoAudio.BuscarLaudoAudioPorId(v);

            return InjetarEmUsuarioModel(LaudoRXEncontrado,false);
        }

        private static LaudoAudioModel InjetarEmUsuarioModel(LAUDOAUD x, bool materializarClassesDoMovimento = true)
        {
            if (x == null)
                return null;
            else
                return new LaudoAudioModel()
                {
                    DataProxAvaliacao = x.DATAPROX,
                    IdLaudoAudio = (int)x.IDLAUDO,
                    Observavao = x.OBSERVACAO,
                    OD1K = x.OD1K,
                    OD250 = x.OD250,
                    OD2K = x.OD2K, 
                    OD3K = x.OD3K,
                    OD4K = x.OD4K,
                    OD500 = x.OD500,
                    OD6K = x.OD6K,
                    OD8K = x.OD8K,

                    ODO1K = x.ODO1K,
                    ODO250 = x.ODO250,
                    ODO2K = x.ODO2K,
                    ODO3K = x.ODO3K,
                    ODO4K = x.ODO4K,
                    ODO500 = x.ODO500,
                    ODO6K = x.ODO6K,
                    ODO8K = x.ODO8K,

                    OE1K = x.OE1K,
                    OE250 = x.OE250,
                    OE2K = x.OE2K,
                    OE3K = x.OE3K,
                    OE4K = x.OE4K,
                    OE500 = x.OE500,
                    OE6K = x.OE6K, 
                    OE8K = x.OE8K,

                    OEO1K = x.OEO1K,
                    OEO250 = x.OEO250,
                    OEO2K = x.OEO2K,
                    OEO3K = x.OEO3K,
                    OEO4K = x.OEO4K,
                    OEO500 = x.OEO500,
                    OEO6K = x.OEO6K,
                    OEO8K = x.OEO8K,
                    
                    ProcedimentoMovimento = CadastroDeProcedimentosMovimento.BuscarProcedimentoDeMovimentoPorID((int)x.IDMOVPRO, true, materializarClassesDoMovimento)
                };
        }

        private static LaudoAudioModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new LaudoAudioModel()
            {
                DataProxAvaliacao = string.IsNullOrEmpty(form["data"]) ? null : (DateTime?)Convert.ToDateTime(form["data"]),
                IdLaudoAudio = string.IsNullOrEmpty(form["codigoLaudoAudio"]) ? 0 : Convert.ToInt32(form["codigoLaudoAudio"]),

                Observavao = string.IsNullOrEmpty(form["observacao"]) ? null : form["observacao"],

                OD1K = string.IsNullOrEmpty(form["OD1K"]) ? null : (int?)Convert.ToInt32(form["OD1K"]),
                OD250 = string.IsNullOrEmpty(form["OD250"]) ? null : (int?)Convert.ToInt32(form["OD250"]),
                OD2K = string.IsNullOrEmpty(form["OD2K"]) ? null : (int?)Convert.ToInt32(form["OD2K"]),
                OD3K = string.IsNullOrEmpty(form["OD3K"]) ? null : (int?)Convert.ToInt32(form["OD3K"]),
                OD4K = string.IsNullOrEmpty(form["OD4K"]) ? null : (int?)Convert.ToInt32(form["OD4K"]),
                OD500 = string.IsNullOrEmpty(form["OD500"]) ? null : (int?)Convert.ToInt32(form["OD500"]),
                OD6K = string.IsNullOrEmpty(form["OD6K"]) ? null : (int?)Convert.ToInt32(form["OD6K"]),
                OD8K = string.IsNullOrEmpty(form["OD8K"]) ? null : (int?)Convert.ToInt32(form["OD8K"]),
                ODO1K = string.IsNullOrEmpty(form["ODO1K"]) ? null : (int?)Convert.ToInt32(form["ODO1K"]),
                ODO250 = string.IsNullOrEmpty(form["ODO250"]) ? null : (int?)Convert.ToInt32(form["ODO250"]),
                ODO2K = string.IsNullOrEmpty(form["ODO2K"]) ? null : (int?)Convert.ToInt32(form["ODO2K"]),
                ODO3K = string.IsNullOrEmpty(form["ODO3K"]) ? null : (int?)Convert.ToInt32(form["ODO3K"]),
                ODO4K = string.IsNullOrEmpty(form["ODO4K"]) ? null : (int?)Convert.ToInt32(form["ODO4K"]),
                ODO500 = string.IsNullOrEmpty(form["ODO500"]) ? null : (int?)Convert.ToInt32(form["ODO500"]),
                ODO6K = string.IsNullOrEmpty(form["ODO6K"]) ? null : (int?)Convert.ToInt32(form["ODO6K"]),
                ODO8K = string.IsNullOrEmpty(form["ODO8K"]) ? null : (int?)Convert.ToInt32(form["ODO8K"]),
                OE1K = string.IsNullOrEmpty(form["OE1K"]) ? null : (int?)Convert.ToInt32(form["OE1K"]),
                OE250 = string.IsNullOrEmpty(form["OE250"]) ? null : (int?)Convert.ToInt32(form["OE250"]),
                OE2K = string.IsNullOrEmpty(form["OE2K"]) ? null : (int?)Convert.ToInt32(form["OE2K"]),
                OE3K = string.IsNullOrEmpty(form["OE3K"]) ? null : (int?)Convert.ToInt32(form["OE3K"]),
                OE4K = string.IsNullOrEmpty(form["OE4K"]) ? null : (int?)Convert.ToInt32(form["OE4K"]),
                OE500 = string.IsNullOrEmpty(form["OE500"]) ? null : (int?)Convert.ToInt32(form["OE500"]),
                OE6K = string.IsNullOrEmpty(form["OE6K"]) ? null : (int?)Convert.ToInt32(form["OE6K"]),
                OE8K = string.IsNullOrEmpty(form["OE8K"]) ? null : (int?)Convert.ToInt32(form["OE8K"]),
                OEO1K = string.IsNullOrEmpty(form["OEO1K"]) ? null : (int?)Convert.ToInt32(form["OEO1K"]),
                OEO250 = string.IsNullOrEmpty(form["OEO250"]) ? null : (int?)Convert.ToInt32(form["OEO250"]),
                OEO2K = string.IsNullOrEmpty(form["OEO2K"]) ? null : (int?)Convert.ToInt32(form["OEO2K"]),
                OEO3K = string.IsNullOrEmpty(form["OEO3K"]) ? null : (int?)Convert.ToInt32(form["OEO3K"]),
                OEO4K = string.IsNullOrEmpty(form["OEO4K"]) ? null : (int?)Convert.ToInt32(form["OEO4K"]),
                OEO500 = string.IsNullOrEmpty(form["OEO500"]) ? null : (int?)Convert.ToInt32(form["OEO500"]),
                OEO6K = string.IsNullOrEmpty(form["OEO6K"]) ? null : (int?)Convert.ToInt32(form["OEO6K"]),
                OEO8K = string.IsNullOrEmpty(form["OEO8K"]) ? null : (int?)Convert.ToInt32(form["OEO8K"]),

                ProcedimentoMovimento = CadastroDeProcedimentosMovimento.BuscarProcedimentoDeMovimentoPorID(string.IsNullOrEmpty(form["idProcedimentoMovimento"]) ? 0 : Convert.ToInt32(form["idProcedimentoMovimento"]))
            };
        }

        internal static byte[] ImprimirAudiometria(int codigoAudiometria)
        {
            return ControleDeLaudoAudio.ImprimirAudiometria(codigoAudiometria);
        }

        private static LAUDOAUD InjetarEmCargoModelDAO(LaudoAudioModel x)
        {
            if (x == null)
                return null;
            else
                return new LAUDOAUD()
                {
                    IDLAUDO = x.IdLaudoAudio,
                    IDMOVPRO = x.ProcedimentoMovimento.IdMovimentoProcedimento,

                    DATAPROX = x.DataProxAvaliacao,

                    OBSERVACAO = x.Observavao,
                    
                    OD250 = x.OD250,
                    OD500 = x.OD500,
                    OD1K = x.OD1K,
                    OD2K = x.OD2K,
                    OD3K = x.OD3K,
                    OD4K = x.OD4K,
                    OD6K = x.OD6K,
                    OD8K = x.OD8K,

                    ODO250 = x.ODO250,
                    ODO500 = x.ODO500,
                    ODO1K = x.ODO1K,
                    ODO2K = x.ODO2K,
                    ODO3K = x.ODO3K,
                    ODO4K = x.ODO4K,
                    ODO6K = x.ODO6K,
                    ODO8K = x.ODO8K,

                    OE250 = x.OE250,
                    OE500 = x.OE500,
                    OE1K = x.OE1K,
                    OE2K = x.OE2K,
                    OE3K = x.OE3K,
                    OE4K = x.OE4K,
                    OE6K = x.OE6K,
                    OE8K = x.OE8K,

                    OEO250 = x.OEO250,
                    OEO500 = x.OEO500,
                    OEO1K = x.OEO1K,
                    OEO2K = x.OEO2K,
                    OEO3K = x.OEO3K,
                    OEO4K = x.OEO4K,
                    OEO6K = x.OEO6K,
                    OEO8K = x.OEO8K
                };

        }

        internal static void DeletarLaudoAudio(LaudoAudioController laudoAudioController, int codigoLaudoAudio)
        {
            ControleDeLaudoAudio.ExcluirLaudoAudio(codigoLaudoAudio);
        }

        internal static LaudoAudioModel SalvarAudiometria(FormCollection form)
        {
            LaudoAudioModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            LAUDOAUD laudoDAO = InjetarEmCargoModelDAO(usuarioModel);
            laudoDAO = ControleDeLaudoAudio.SalvarLaudoAudio(laudoDAO);

            usuarioModel = InjetarEmUsuarioModel(laudoDAO);

            return usuarioModel;
        }
    }
}
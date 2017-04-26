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
                listaDeModels.Add(InjetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static LaudoAudioModel RecuperarLaudoAudioPorID(int v)
        {
            LAUDOAUD LaudoRXEncontrado = ControleDeLaudoAudio.BuscarLaudoAudioPorId(v);

            return InjetarEmUsuarioModel(LaudoRXEncontrado);
        }

        private static LaudoAudioModel InjetarEmUsuarioModel(LAUDOAUD x)
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
                    
                    ProcedimentoMovimento = CadastroDeProcedimentosMovimento.BuscarProcedimentoDeMovimentoPorID((int)x.IDMOVPRO, true)
                };
        }

        internal static void DeletarLaudoAudio(LaudoAudioController laudoAudioController, int codigoLaudoAudio)
        {
            ControleDeLaudoAudio.ExcluirLaudoAudio(codigoLaudoAudio);
        }
    }
}
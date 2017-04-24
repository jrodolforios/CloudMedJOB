using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.DatabaseModels;
using MediCloud.Models.Laudo;
using MediCloud.BusinessProcess.Laudo;

namespace MediCloud.Code.Laudo
{
    public class CadastroDeModeloLaudo
    {
        internal static ModeloLaudoModel InjetarEmUsuarioModel(MODELOLAUDO x)
        {
            if (x == null)
                return null;
            else
                return new ModeloLaudoModel()
                {
                    Conclusao = x.CONCLUSAO,
                    CorpoModelo = x.LAUDO,
                    IdModeloLaudo = (int)x.IDMODELO,
                    NomeModelo = x.MODELO,
                    Rodape = x.RODAPE
                };
        }

        internal static MODELOLAUDO InjetarEmUsuarioModel(ModeloLaudoModel x)
        {
            if (x == null)
                return null;
            else
                return new MODELOLAUDO()
                {
                    CONCLUSAO = x.Conclusao,
                    IDMODELO = x.IdModeloLaudo,
                    LAUDO = x.CorpoModelo,
                    MODELO = x.NomeModelo,
                    RODAPE = x.Rodape
                };
        }

        internal static List<ModeloLaudoModel> RecuperarModeloLaudoPorTermo(string prefix)
        {
            List<MODELOLAUDO> contadoresEncontrados = ControleDeModeloLaudo.buscarModeloLaudo(prefix);
            List<ModeloLaudoModel> resultados = new List<ModeloLaudoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static ModeloLaudoModel RecuperarModeloPorID(int v)
        {
            MODELOLAUDO LaudoRXEncontrado = ControleDeModeloLaudo.buscarModeloLaudoPorId(v);

            return InjetarEmUsuarioModel(LaudoRXEncontrado);
        }
    }
}
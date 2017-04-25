using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.DatabaseModels;
using MediCloud.Models.Laudo;
using MediCloud.BusinessProcess.Laudo;
using System.Web.Mvc;
using MediCloud.Controllers;

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

        internal static MODELOLAUDO injetarEmUsuarioModel(ModeloLaudoModel x)
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

        internal static ModeloLaudoModel injetarEmUsuarioModel(MODELOLAUDO x)
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

        internal static void DeletarModeloLaudo(ModeloLaudoController modeloLaudoController, int codigoModeloLaudo)
        {
            ControleDeModeloLaudo.ExcluirModeloLaudo(codigoModeloLaudo);
        }

        internal static List<ModeloLaudoModel> buscarModeloLaudo(FormCollection form)
        {
            string termo = form["keywords"];
            List<ModeloLaudoModel> listaDeModels = new List<ModeloLaudoModel>();

            List<MODELOLAUDO> usuarioDoBanco = ControleDeModeloLaudo.buscarModeloLaudo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
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
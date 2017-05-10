﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Parametro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Parametro;
using MediCloud.Controllers;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeFechamento
    {
        internal static List<FechamentoModel> BuscarFechamentoPorTermo(FormCollection form)
        {
            string termo = form["keywords"];
            List<FechamentoModel> listaDeModels = new List<FechamentoModel>();

            List<MOVIMENTO_FECHAMENTO> usuarioDoBanco = ControleDeFechamento.buscarCidadePorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        private static FechamentoModel InjetarEmUsuarioModel(MOVIMENTO_FECHAMENTO x)
        {
            if (x == null)
                return null;
            else
                return new FechamentoModel()
                {
                    DiaFechamento = Convert.ToInt32(x.DIA),
                    DiasPrazoBoleto = x.PRAZOBOLETO,
                    IdFechamento = (int)x.IDFEC,
                    PeriodoApuracao = x.PERIODO
                };
        }

        internal static FechamentoModel RecuperarFechamentoPorID(int v)
        {
            if (v != 0)
            {
                MOVIMENTO_FECHAMENTO referenteEncontrado = ControleDeFechamento.RecuperarFechamentoPorID(v);
                return InjetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        internal static void DeletarFechamento(FechamentoController fechamentoController, int codigoDoFechamento)
        {
            ControleDeFechamento.DeletarFechamento(codigoDoFechamento);
        }
    }
}
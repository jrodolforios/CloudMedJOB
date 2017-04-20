using MediCloud.BusinessProcess.Laudo;
using MediCloud.Code.Clientes;
using MediCloud.DatabaseModels;
using MediCloud.Models.Laudo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MediCloud.Code.Enum.EnumLaudo;

namespace MediCloud.Code.Laudo
{
    public class CadastroDeLaudoRX
    {
        internal static List<LaudoRXModel> buscarClientes(FormCollection form)
        {
            string termo = form["keywords"];
            List<LaudoRXModel> listaDeModels = new List<LaudoRXModel>();

            List<LAUDORX> usuarioDoBanco = ControleDeLaudoRX.buscarLaudoRX(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static LaudoRXModel injetarEmUsuarioModel(LAUDORX x)
        {
            if (x == null)
                return null;
            else
                return new LaudoRXModel()
                {
                    Conclusao = x.CONCLUSAO,
                    CorpoLaudo = x.LAUDO,
                    Data = x.DATA,
                    Idade = Convert.ToInt32(x.IDADE),
                    LaudoNegrito = x.LAUDONEGRITO,
                    Medico = x.MEDICO,
                    ModeloLaudo = CadastroDeModeloLaudo.InjetarEmUsuarioModel(x.MODELOLAUDO),
                    Paciente = x.PACIENTE,
                    ProcedimentoMovimento = CadastroDeProcedimentosMovimento.BuscarProcedimentoDeMovimentoPorID((int)x.IDMOVPRO),
                    Rodape = x.RODAPE,
                    Status = ConverteStatusLaudoParaEnum(x.STATUS)
                };
        }

        internal static StatusLiberadoLaudo ConverteStatusLaudoParaEnum (string status)
        {
            switch (status.ToUpper())
            {
                case "LIBERADO":
                    return StatusLiberadoLaudo.liberado;
                case "PENDENTE":
                    return StatusLiberadoLaudo.pendente;
                default:
                    return StatusLiberadoLaudo.vazio;
            }
        }
    }
}
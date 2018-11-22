using MediCloud.BusinessProcess.Laudo;
using MediCloud.Code.Clientes;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Laudo;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static MediCloud.Code.Enum.EnumLaudo;

namespace MediCloud.Code.Laudo
{
    public class CadastroDeLaudoRX
    {
        #region Internal Methods

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

        internal static LaudoRXModel buscarLaudoRXPorID(int v)
        {
            LAUDORX LaudoRXEncontrado = ControleDeLaudoRX.buscarLaudoRXPorId(v);

            return injetarEmUsuarioModel(LaudoRXEncontrado);
        }

        internal static StatusLiberadoLaudo ConverteStatusLaudoParaEnum(string status)
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

        internal static string ConverteStatusLaudoParaString(StatusLiberadoLaudo status)
        {
            switch (status)
            {
                case StatusLiberadoLaudo.liberado:
                    return "LIBERADO";

                case StatusLiberadoLaudo.pendente:
                    return "PENDENTE";

                default:
                    return null;
            }
        }

        internal static void DeletarLaudoRX(RaioXController raioXController, int codigoRaioX)
        {
            ControleDeLaudoRX.DeletarLaudoRX(codigoRaioX);
        }

        internal static byte[] ImprimirLaudo(int codigoLaudo)
        {
            return ControleDeLaudoRX.ImprimirLaudo(codigoLaudo);
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

        internal static void LiberarLaudoRX(RaioXController raioXController, int codigoRaioX)
        {
            ControleDeLaudoRX.LiberarLaudoRX(codigoRaioX);
        }

        internal static LaudoRXModel SalvarLaudoRX(FormCollection form)
        {
            LaudoRXModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            LAUDORX laudoDAO = injetarEmCargoModelDAO(usuarioModel);
            laudoDAO = ControleDeLaudoRX.SalvarLaudo(laudoDAO);

            usuarioModel = injetarEmUsuarioModel(laudoDAO);

            return usuarioModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static LAUDORX injetarEmCargoModelDAO(LaudoRXModel x)
        {
            if (x == null)
                return null;
            else
                return new LAUDORX()
                {
                    CONCLUSAO = x.Conclusao,
                    DATA = x.Data,
                    IDADE = x.Idade.ToString(),
                    IDMODELO = x.ModeloLaudo?.IdModeloLaudo,
                    IDMOVPRO = x.ProcedimentoMovimento.IdMovimentoProcedimento,
                    LAUDO = x.CorpoLaudo,
                    LAUDONEGRITO = x.LaudoNegrito,
                    MEDICO = x.Medico,
                    PACIENTE = x.Paciente,
                    RODAPE = x.Rodape,
                    STATUS = ConverteStatusLaudoParaString(x.Status)
                };
        }

        private static LaudoRXModel injetarEmUsuarioModel(FormCollection form)
        {
            return new LaudoRXModel()
            {
                Conclusao = string.IsNullOrEmpty(form["conclusao"]) ? string.Empty : form["conclusao"],
                CorpoLaudo = string.IsNullOrEmpty(form["corpoLaudo"]) ? string.Empty : form["corpoLaudo"],
                Data = DateTime.Parse(form["data"]),
                Idade = Int32.Parse(form["Idade"]),
                LaudoNegrito = string.IsNullOrEmpty(form["laudoNegrito"]) ? string.Empty : form["laudoNegrito"],
                Medico = string.IsNullOrEmpty(form["Medico"]) ? string.Empty : form["Medico"],
                ModeloLaudo = CadastroDeModeloLaudo.RecuperarModeloPorID(string.IsNullOrEmpty(form["idModeloLaudo"]) ? 0 : Int32.Parse(form["idModeloLaudo"])),
                Paciente = string.IsNullOrEmpty(form["Paciente"]) ? string.Empty : form["Paciente"],
                ProcedimentoMovimento = CadastroDeProcedimentosMovimento.BuscarProcedimentoDeMovimentoPorID(int.Parse(form["idProcedimentoMovimento"])),
                Rodape = string.IsNullOrEmpty(form["rodape"]) ? string.Empty : form["rodape"],
                Status = string.IsNullOrEmpty(form["Status"]) ? StatusLiberadoLaudo.vazio : (Convert.ToBoolean((form["Status"].ToLower() == "on")) ? StatusLiberadoLaudo.liberado : StatusLiberadoLaudo.pendente)
            };
        }

        #endregion Private Methods
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Parametro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Parametro;
using MediCloud.Code.Clientes;
using MediCloud.Code.Enum;
using MediCloud.Controllers;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeDadosOcupacionais
    {
        internal static List<DadosOcupacionaisModel> BuscarDadosOcupacionais(FormCollection form)
        {
            string termo = form["keywords"];
            List<DadosOcupacionaisModel> listaDeModels = new List<DadosOcupacionaisModel>();

            List<CLIENTE_OCUPACIONAL> usuarioDoBanco = ControleDeDadosOcupacionais.BuscarDadosOcupacionaisPorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        private static DadosOcupacionaisModel injetarEmUsuarioModel(CLIENTE_OCUPACIONAL x )
        {
            if (x == null)
                return null;
            else
                return new DadosOcupacionaisModel()
                {
                    Cliente = CadastroDeClientes.RecuperarClientePorID((int)x.IDCLI),
                    CodigoNexo = x.CODNEXO,
                    ElaboradorPCMSO = CadastroDeElaboradorPCMSO.BuscarElaboradorPorID(x.IDEPCMSO),
                    ElaboradorPPRA = CadastroDeElaboradorPPRA.BuscarElaboradorPorID(x.IDEPPRA),
                    Emissao = x.EMISSAO,
                    NaoDeseja = x.NAODESEJA.HasValue ? (x.NAODESEJA.Value == 1) : false,
                    Observacao = x.OBSERVACAO,
                    StatusPCMSOSel = ConverterStatusPCMSOParaEnum(x.PCMSO),
                    Vencimento = x.VENCIMENTO
                };
        }

        internal static void DeletarDadosOcupacionais(DadosOcupacionaisController dadosOcupacionaisController, int codigoDoDadosOcupacionais)
        {
            ControleDeDadosOcupacionais.DeletarDadosOcupacionais(codigoDoDadosOcupacionais);
        }

        private static EnumParametro.StatusPCMSO ConverterStatusPCMSOParaEnum(string PCMSO)
        {
            switch (PCMSO)
            {
                case "P":
                    return EnumParametro.StatusPCMSO.PCMSOCMT;
                case "T":
                    return EnumParametro.StatusPCMSO.PCMSOTerceiro;
                default:
                    return EnumParametro.StatusPCMSO.Vazio;
            }
        }

        internal static DadosOcupacionaisModel BuscarDadosOcupacionaisPorID(int v)
        {
            if (v != 0)
            {
                CLIENTE_OCUPACIONAL elaboradorEncontrado = ControleDeDadosOcupacionais.BuscarDadosOcupacionaisPorID((int)v);
                return injetarEmUsuarioModel(elaboradorEncontrado);
            }
            else
                return null;
        }

        private static string ConverterStatusPCMSOParaEnum(EnumParametro.StatusPCMSO PCMSO)
        {
            switch (PCMSO)
            {
                case EnumParametro.StatusPCMSO.PCMSOCMT:
                    return "P";
                case EnumParametro.StatusPCMSO.PCMSOTerceiro:
                    return "T";
                default:
                    return null;
            }
        }
    }
}
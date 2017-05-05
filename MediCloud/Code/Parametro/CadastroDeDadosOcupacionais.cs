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

        private static DadosOcupacionaisModel injetarEmUsuarioModel(CLIENTE_OCUPACIONAL x)
        {
            if (x == null)
                return null;
            else
                return new DadosOcupacionaisModel()
                {
                    IdClienteOcupacional = (int)x.IDCLIOC,
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

        private static string ConverterStatusPCMSOParaString(EnumParametro.StatusPCMSO PCMSO)
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

        internal static DadosOcupacionaisModel SalvarDadosOcupacionais(FormCollection form)
        {
            DadosOcupacionaisModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            CLIENTE_OCUPACIONAL DadosOcupacionaisDAO = injetarEmUsuarioDAO(usuarioModel);
            DadosOcupacionaisDAO = ControleDeDadosOcupacionais.SalvarDadosOcupacionais(DadosOcupacionaisDAO);

            usuarioModel = injetarEmUsuarioModel(DadosOcupacionaisDAO);

            return usuarioModel;
        }

        private static CLIENTE_OCUPACIONAL injetarEmUsuarioDAO(DadosOcupacionaisModel x)
        {
            if (x == null)
                return null;
            else
                return new CLIENTE_OCUPACIONAL()
                {
                    CODNEXO = x.CodigoNexo,
                    EMISSAO = x.Emissao,
                    IDCLIOC = x.IdClienteOcupacional,
                    IDCLI = x.Cliente.IdCliente,
                    IDEPCMSO = x.ElaboradorPCMSO.IdElaboradorPCMSO,
                    IDEPPRA = x.ElaboradorPPRA.IdElaboradorPPRA,
                    NAODESEJA = x.NaoDeseja ? 1 : 0,
                    OBSERVACAO = x.Observacao,
                    PCMSO = ConverterStatusPCMSOParaString(x.StatusPCMSOSel),
                    VENCIMENTO = x.Vencimento
                };
        }

        private static DadosOcupacionaisModel injetarEmUsuarioModel(FormCollection form)
        {
            return new DadosOcupacionaisModel()
            {
                IdClienteOcupacional = string.IsNullOrEmpty(form["codigoDadosOcupacionais"]) ? 0 : Convert.ToInt32(form["codigoDadosOcupacionais"]),
                Cliente = CadastroDeClientes.RecuperarClientePorID(string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"])),
                CodigoNexo = string.IsNullOrEmpty(form["idCliente"]) ? null : form["idCliente"],
                ElaboradorPCMSO = CadastroDeElaboradorPCMSO.BuscarElaboradorPorID(string.IsNullOrEmpty(form["idElaboradorPCMSO"]) ? 0 : Convert.ToInt32(form["idElaboradorPCMSO"])),
                ElaboradorPPRA = CadastroDeElaboradorPPRA.BuscarElaboradorPorID(string.IsNullOrEmpty(form["idElaboradorPPRA"]) ? 0 : Convert.ToInt32(form["idElaboradorPPRA"])),
                Emissao = string.IsNullOrEmpty(form["emissao"]) ? null : (DateTime?)Convert.ToDateTime(form["emissao"]),
                NaoDeseja = string.IsNullOrEmpty(form["naoDeseja"]) ? false : Convert.ToBoolean(form["naoDeseja"].ToLower() == "on"),
                Observacao = string.IsNullOrEmpty(form["observacoes"]) ? null : form["observacoes"],
                StatusPCMSOSel = string.IsNullOrEmpty(form["tipoPCMSO"]) ? EnumParametro.StatusPCMSO.Vazio : (EnumParametro.StatusPCMSO)Convert.ToInt32(form["tipoPCMSO"]),
                Vencimento = string.IsNullOrEmpty(form["vencimento"]) ? null : (DateTime?)Convert.ToDateTime(form["vencimento"])
            };
        }
    }
}
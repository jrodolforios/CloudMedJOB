using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Parametro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Parametro;
using MediCloud.Code.Enum;
using MediCloud.Controllers;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeCidade
    {
        internal static List<CidadeModel> buscarCidade(FormCollection form)
        {
            string termo = form["keywords"];
            return buscarCidade(termo);
        }

        internal static List<CidadeModel> buscarCidade(string prefix)
        {
            List<CidadeModel> listaDeModels = new List<CidadeModel>();

            List<CIDADE> usuarioDoBanco = ControleDeCidade.buscarCidadePorTermo(prefix);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        private static CidadeModel injetarEmUsuarioModel(CIDADE x)
        {
            if (x == null)
                return null;
            else
                return new CidadeModel()
                {
                    Estado = ConverterSiglaParaEnum(x.ESTADO),
                    IdCidade = (int)x.IDCID,
                    IdentificacaoNF = x.CIDNF,
                    NomeCidade = x.CIDADE1
                };
        }

        internal static CidadeModel RecuperarCidadePorID(int v)
        {
            if (v != 0)
            {
                CIDADE referenteEncontrado = ControleDeCidade.buscarCidadePorID(v);
                return injetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        private static EnumParametro.EstadoEnum ConverterSiglaParaEnum(string estado)
        {
            switch (estado)
            {
                case "AC":
                    return EnumParametro.EstadoEnum.Acre;
                case "AL":
                    return EnumParametro.EstadoEnum.Alagoas;
                case "AP":
                    return EnumParametro.EstadoEnum.Amapa;
                case "AM":
                    return EnumParametro.EstadoEnum.Amazonas;
                case "BA":
                    return EnumParametro.EstadoEnum.Bahia;
                case "CE":
                    return EnumParametro.EstadoEnum.Ceara;
                case "DF":
                    return EnumParametro.EstadoEnum.DistritoFederal;
                case "ES":
                    return EnumParametro.EstadoEnum.EspiritoSanto;
                case "GO":
                    return EnumParametro.EstadoEnum.Goias;
                case "MA":
                    return EnumParametro.EstadoEnum.Maranhao;
                case "MT":
                    return EnumParametro.EstadoEnum.MatoGrosso;
                case "MS":
                    return EnumParametro.EstadoEnum.MatoGrossoDoSul;
                case "MG":
                    return EnumParametro.EstadoEnum.MinasGerais;
                case "PA":
                    return EnumParametro.EstadoEnum.Para;
                case "PB":
                    return EnumParametro.EstadoEnum.Paraiba;
                case "PR":
                    return EnumParametro.EstadoEnum.Parana;
                case "PE":
                    return EnumParametro.EstadoEnum.Pernambuco;
                case "PI":
                    return EnumParametro.EstadoEnum.Piaui;
                case "RJ":
                    return EnumParametro.EstadoEnum.RioDeJaneiro;
                case "RN":
                    return EnumParametro.EstadoEnum.RioGrandeDoNorte;
                case "RS":
                    return EnumParametro.EstadoEnum.RioGrandeDoSul;
                case "RO":
                    return EnumParametro.EstadoEnum.Rondonia;
                case "RR":
                    return EnumParametro.EstadoEnum.Roraima;
                case "SC":
                    return EnumParametro.EstadoEnum.SantaCatarina;
                case "SP":
                    return EnumParametro.EstadoEnum.SaoPaulo;
                case "SE":
                    return EnumParametro.EstadoEnum.Sergipe;
                case "TO":
                    return EnumParametro.EstadoEnum.Tocantins;
                default:
                    return EnumParametro.EstadoEnum.Vazio;
            }
        }

        internal static void DeletarCidade(CidadeController cidadeController, int codigoDoCidade)
        {
            ControleDeCidade.DeletarCidade(codigoDoCidade);
        }

        internal static CidadeModel SalvarCidade(FormCollection form)
        {
            CidadeModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            CIDADE cidadeDAO = injetarEmUsuarioDAO(usuarioModel);
            cidadeDAO = ControleDeCidade.SalvarCidade(cidadeDAO);

            usuarioModel = injetarEmUsuarioModel(cidadeDAO);

            return usuarioModel;
        }

        private static CIDADE injetarEmUsuarioDAO(CidadeModel x)
        {
            if (x == null)
                return null;
            else
                return new CIDADE()
                {
                    CIDADE1 = x.NomeCidade,
                    CIDNF = x.IdentificacaoNF,
                    ESTADO = ConverterSiglaParaString(x.Estado),
                    IDCID = x.IdCidade
                };
        }

        private static CidadeModel injetarEmUsuarioModel(FormCollection form)
        {
            return new CidadeModel()
            {
                Estado = string.IsNullOrEmpty(form["estado"]) ? EnumParametro.EstadoEnum.Vazio : (EnumParametro.EstadoEnum)Convert.ToInt32(form["estado"]),
                IdCidade = string.IsNullOrEmpty(form["codigoCidade"]) ? 0 : Convert.ToInt32(form["codigoCidade"]),
                IdentificacaoNF = string.IsNullOrEmpty(form["identificacaoNF"]) ? 0 : Convert.ToInt32(form["identificacaoNF"]),
                NomeCidade = string.IsNullOrEmpty(form["nomeCidade"]) ? null : form["nomeCidade"]
            };
        }

        private static string ConverterSiglaParaString(EnumParametro.EstadoEnum estado)
        {
            switch (estado)
            {
                case EnumParametro.EstadoEnum.Acre:
                    return "AC";
                case EnumParametro.EstadoEnum.Alagoas:
                    return "AL";
                case EnumParametro.EstadoEnum.Amapa:
                    return "AP";
                case EnumParametro.EstadoEnum.Amazonas:
                    return "AM";
                case EnumParametro.EstadoEnum.Bahia:
                    return "BA";
                case EnumParametro.EstadoEnum.Ceara:
                    return "CE";
                case EnumParametro.EstadoEnum.DistritoFederal:
                    return "DF";
                case EnumParametro.EstadoEnum.EspiritoSanto:
                    return "ES";
                case EnumParametro.EstadoEnum.Goias:
                    return "GO";
                case EnumParametro.EstadoEnum.Maranhao:
                    return "MA";
                case EnumParametro.EstadoEnum.MatoGrosso:
                    return "MT";
                case EnumParametro.EstadoEnum.MatoGrossoDoSul:
                    return "MS";
                case EnumParametro.EstadoEnum.MinasGerais:
                    return "MG";
                case EnumParametro.EstadoEnum.Para:
                    return "PA";
                case EnumParametro.EstadoEnum.Paraiba:
                    return "PB";
                case EnumParametro.EstadoEnum.Parana:
                    return "PR";
                case EnumParametro.EstadoEnum.Pernambuco:
                    return "PE";
                case EnumParametro.EstadoEnum.Piaui:
                    return "PI";
                case EnumParametro.EstadoEnum.RioDeJaneiro:
                    return "RJ";
                case EnumParametro.EstadoEnum.RioGrandeDoNorte:
                    return "RN";
                case EnumParametro.EstadoEnum.RioGrandeDoSul:
                    return "RS";
                case EnumParametro.EstadoEnum.Rondonia:
                    return "RO";
                case EnumParametro.EstadoEnum.Roraima:
                    return "RR";
                case EnumParametro.EstadoEnum.SantaCatarina:
                    return "SC";
                case EnumParametro.EstadoEnum.SaoPaulo:
                    return "SP";
                case EnumParametro.EstadoEnum.Sergipe:
                    return "SE";
                case EnumParametro.EstadoEnum.Tocantins:
                    return "TO";
                default:
                    return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Recomendacao;
using MediCloud.BusinessProcess.Recomendacao;
using MediCloud.DatabaseModels;
using MediCloud.Code.Enum;
using System.Web.Mvc;

namespace MediCloud.Code.Recomendacao
{
    public class CadastroDeRiscoNatureza
    {
        internal static List<RiscoModel> BuscarRiscosPorIDRecomendacao(int idRec)
        {
            List<RISCO> contadoresEncontrados = ControleDeRiscoNatureza.BuscarRiscosPorIDRecomendacao(idRec);
            List<RiscoModel> resultados = new List<RiscoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmRiscoModel(x));
            });

            return resultados;
        }

        internal static List<RiscoModel> BuscarRiscosPorTermo(string prefix)
        {
            List<RiscoModel> listaDeModels = new List<RiscoModel>();

            List<RISCO> usuarioDoBanco = ControleDeRiscoNatureza.buscarRiscoPorTermo(prefix);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmRiscoModel(x, true));
            });

            return listaDeModels;
        }

        internal static List<NaturezaModel> BuscarNaturezaPorTermo(FormCollection form)
        {
            string termo = form["keywords"];

            List<NaturezaModel> listaDeModels = new List<NaturezaModel>();

            List<NATUREZA> usuarioDoBanco = ControleDeRiscoNatureza.buscarNaturezaPorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmNaturezaModel(x));
            });

            return listaDeModels;
        }

        private static RiscoModel InjetarEmRiscoModel(RISCO x, bool materializarclasses = false)
        {
            if (x == null)
                return null;
            else
                return new RiscoModel()
                {
                    IdRisco = (int)x.IDRISCO,
                    NomeRisco = x.RISCO1,
                    Eventualidade = ConverterEventualidadeParaEnum(x.EVENTUALIDADE),
                    Natureza = materializarclasses ? RecuperarNaturezaDeRisco((int)x.IDNAT) : new NaturezaModel() { IdNatureza = (int)x.IDNAT }
                };
        }

        internal static NaturezaModel SalvarNatureza(FormCollection form)
        {
            NaturezaModel usuarioModel = InjetarEmNaturezaModel(form);
            usuarioModel.validar();

            NATUREZA naturezaDAO = InjetarEmNaturezaDAO(usuarioModel);
            naturezaDAO = ControleDeRiscoNatureza.SalvarNatureza(naturezaDAO);

            usuarioModel = InjetarEmNaturezaModel(naturezaDAO);

            return usuarioModel;
        }

        private static NATUREZA InjetarEmNaturezaDAO(NaturezaModel x)
        {
            if (x == null)
                return null;
            else
                return new NATUREZA()
                {
                    IDNAT = x.IdNatureza,
                    NATUREZA1 = x.NomeNatureza
                };
        }

        private static NaturezaModel InjetarEmNaturezaModel(FormCollection form)
        {
            return new NaturezaModel()
            {
                IdNatureza = string.IsNullOrEmpty(form["codigoNatureza"]) ? 0 : Convert.ToInt32(form["codigoNatureza"]),
                NomeNatureza = string.IsNullOrEmpty(form["nomeNatureza"]) ? null : form["nomeNatureza"]
            };
        }

        private static NaturezaModel InjetarEmNaturezaModel(NATUREZA x)
        {
            if (x == null)
                return null;
            else
                return new NaturezaModel()
                {
                    IdNatureza = (int)x.IDNAT,
                    NomeNatureza = x.NATUREZA1,

                    Riscos = RecuperarRiscosDeNatureza(x.IDNAT)
                };
        }

        private static List<RiscoModel> RecuperarRiscosDeNatureza(decimal iDNAT)
        {
            List<RISCO> contadoresEncontrados = ControleDeRiscoNatureza.BuscarRiscosPorIDNatureza(iDNAT);
            List<RiscoModel> resultados = new List<RiscoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmRiscoModel(x));
            });

            return resultados;
        }

        internal static void DeletarNatureza(int codigoNatureza)
        {
            ControleDeRiscoNatureza.DeletarNatureza(codigoNatureza);
        }

        private static NaturezaModel RecuperarNaturezaDeRisco(int idNat)
        {
            NATUREZA naturezaEncontrada = ControleDeRiscoNatureza.RecuperarNaturezaPorID(idNat);

            return InjetarEmNaturezaModel(naturezaEncontrada);
        }

        private static EnumRecomendacao.eventualidadeEnum ConverterEventualidadeParaEnum(string x)
        {
            switch (x.ToUpper())
            {
                case "E":
                    return EnumRecomendacao.eventualidadeEnum.Eventual;
                case "H":
                    return EnumRecomendacao.eventualidadeEnum.Habitual;
                default:
                    return EnumRecomendacao.eventualidadeEnum.vazio;
            }
        }

        internal static void DeletarRisco(int codigoRisco)
        {
            ControleDeRiscoNatureza.DeletarRisco(codigoRisco);
        }

        private static string ConverterEventualidadeParaString(EnumRecomendacao.eventualidadeEnum x)
        {
            switch (x)
            {
                case EnumRecomendacao.eventualidadeEnum.Eventual:
                    return "E";
                case EnumRecomendacao.eventualidadeEnum.Habitual:
                    return "H";
                default:
                    return null;
            }
        }

        internal static NaturezaModel RecuperarNaturezaPorID(int v)
        {
            NATUREZA naturezaEncontrada = ControleDeRiscoNatureza.BuscarNaturezaPorID(v);

            return InjetarEmNaturezaModel(naturezaEncontrada);

        }

        internal static RiscoModel BuscarRiscoPorID(int codigoRisco)
        {
            RISCO riscoEncontrado = ControleDeRiscoNatureza.BuscarRiscoPorID(codigoRisco);

            return InjetarEmRiscoModel(riscoEncontrado);
        }

        internal static RiscoModel SalvarRisco(FormCollection form)
        {
            RiscoModel riscoModel = InjetarEmRiscoModel(form);
            riscoModel.validar();

            RISCO riscoDAO = InjetarEmRiscoDAO(riscoModel);
            riscoDAO = ControleDeRiscoNatureza.SalvarRisco(riscoDAO);

            riscoModel = InjetarEmRiscoModel(riscoDAO);

            return riscoModel;
        }

        private static RISCO InjetarEmRiscoDAO(RiscoModel x)
        {
            if (x == null)
                return null;
            else
                return new RISCO()
                {
                    EVENTUALIDADE = ConverterEventualidadeParaString(x.Eventualidade),
                    IDNAT = x.Natureza.IdNatureza,
                    IDRISCO = x.IdRisco,
                    RISCO1 = x.NomeRisco
                };
        }

        private static RiscoModel InjetarEmRiscoModel(FormCollection form)
        {
            return new RiscoModel()
            {
                Eventualidade = string.IsNullOrEmpty(form["eventualidade"]) ? EnumRecomendacao.eventualidadeEnum.vazio : (EnumRecomendacao.eventualidadeEnum)Convert.ToInt32(form["eventualidade"]),
                IdRisco = string.IsNullOrEmpty(form["codigoRisco"]) ? 0 : Convert.ToInt32(form["codigoRisco"]),
                Natureza = RecuperarNaturezaPorID(string.IsNullOrEmpty(form["codigoNaturezaRisco"]) ? 0 : Convert.ToInt32(form["codigoNaturezaRisco"])),
                NomeRisco = string.IsNullOrEmpty(form["nomeRisco"]) ? null : form["nomeRisco"]
            };
        }
    }
}
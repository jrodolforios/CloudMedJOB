using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Financeiro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.Code.Enum;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeFechamentoCaixa
    {
        internal static List<FechamentoCaixaModel> RecuperarFechamentoCaixaPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            return RecuperarFechamentoCaixaPorTermo(prefix);
        }

        internal static List<FechamentoCaixaModel> RecuperarFechamentoCaixaPorTermo(string prefix)
        {
            List<FECHAMENTO_CAIXA> contadoresEncontrados = ControleDeFechamentoCaixa.RecuperarFechamentoCaixaPorTermo(prefix);
            List<FechamentoCaixaModel> resultados = new List<FechamentoCaixaModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        private static FechamentoCaixaModel InjetarEmUsuarioModel(FECHAMENTO_CAIXA x)
        {
            if (x == null)
                return null;
            else
                return new FechamentoCaixaModel()
                {
                    Data = x.DATA,
                    DataFechamento = x.DATA_FECHAMENTO,
                    IdFechamentoCaixa = (int)x.IDFCX,
                    Observacoes = x.OBSERVACOES,
                    Periodo = ConverterPeriodoDeStringParaEnum(x.PERIODO),
                    Quantidade = (int?)x.QUANTIDADE,
                    Usuario = x.USUARIO,
                    Valor = x.TOTAL,

                    detalhesFechamentoCaixa = RecuperarDetalhesFechamento((int)x.IDFCX)

                };
        }

        private static List<DetalheFechamentoCaixaModel> RecuperarDetalhesFechamento(int idFechamentoCaixa)
        {
            List<SLCONSULTAMOVIMENTO> contadoresEncontrados = ControleDeFechamentoCaixa.RecuperarDetalhesDeFechamentoDeCaixa(idFechamentoCaixa);
            List<DetalheFechamentoCaixaModel> resultados = new List<DetalheFechamentoCaixaModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmDetalheFechamentoCaixaModel(x));
            });

            return resultados;
        }

        internal static void FecharCaixa(int codigoFechamentoDeCaixa)
        {
            ControleDeFechamentoCaixa.FecharCaixa(codigoFechamentoDeCaixa); 
        }

        private static EnumFinanceiro.TipoPagamento getEnumPorString(string TIpoPagamento)
        {
            switch (TIpoPagamento)
            {
                case "V":
                    return EnumFinanceiro.TipoPagamento.AVista;
                case "P":
                    return EnumFinanceiro.TipoPagamento.APrazo;
                default:
                    return EnumFinanceiro.TipoPagamento.Vazio;
            }
        }

        private static string getStringPorEnum(EnumFinanceiro.TipoPagamento TIpoPagamento)
        {
            switch (TIpoPagamento)
            {
                case EnumFinanceiro.TipoPagamento.AVista:
                    return "V";
                case EnumFinanceiro.TipoPagamento.APrazo:
                    return "P";
                default:
                    return null;
            }
        }


        private static DetalheFechamentoCaixaModel InjetarEmDetalheFechamentoCaixaModel(SLCONSULTAMOVIMENTO x)
        {
            if (x == null)
                return null;
            else
                return new DetalheFechamentoCaixaModel()
                {
                    IdFechamentoCaixa = (int)x.IDFCX,
                    Quantidade = null,
                    TipoPagamento = getEnumPorString(x.TIPOPAGTO),
                    Usuario = x.USUARIO,
                    Valor = x.VALOR
                };
        }

        private static EnumFinanceiro.PeriodoFechamentoCaixa ConverterPeriodoDeStringParaEnum(string periodo)
        {
            switch (periodo)
            {
                case "D":
                    return EnumFinanceiro.PeriodoFechamentoCaixa.DiaInteiro;
                case "M":
                    return EnumFinanceiro.PeriodoFechamentoCaixa.Manha;
                case "T":
                    return EnumFinanceiro.PeriodoFechamentoCaixa.Tarde;
                default:
                    return EnumFinanceiro.PeriodoFechamentoCaixa.vazio;
            }
        }

        internal static void DeletarFechamentoCaixa(int codigoFechamentoCaixa)
        {
            ControleDeFechamentoCaixa.DeletarFechamentoCaixa(codigoFechamentoCaixa);
        }

        private static string ConverterPeriodoDeStringParaEnum(EnumFinanceiro.PeriodoFechamentoCaixa periodo)
        {
            switch (periodo)
            {
                case EnumFinanceiro.PeriodoFechamentoCaixa.DiaInteiro:
                    return "D";
                case EnumFinanceiro.PeriodoFechamentoCaixa.Manha:
                    return "M";
                case EnumFinanceiro.PeriodoFechamentoCaixa.Tarde:
                    return "T";
                default:
                    return null;
            }
        }

        internal static FechamentoCaixaModel buscarFechamentoCaixaPorID(int codigoFechamentoCaixa)
        {
            if (codigoFechamentoCaixa != 0)
            {
                FECHAMENTO_CAIXA usuarioencontrado = ControleDeFechamentoCaixa.BuscarFechamentoCaixa(codigoFechamentoCaixa);
                return InjetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        internal static FechamentoCaixaModel SalvarFechamentoCaixa(FormCollection form)
        {
            FechamentoCaixaModel fechamento = InjetarEmUsuarioModel(form);
            fechamento.validar();

            FECHAMENTO_CAIXA faturamentoDAO = InjetarEmUsuarioDAO(fechamento);
            faturamentoDAO = ControleDeFechamentoCaixa.SalvarFechamentoCaixa(faturamentoDAO);

            fechamento = InjetarEmUsuarioModel(faturamentoDAO);

            return fechamento;
        }

        private static FECHAMENTO_CAIXA InjetarEmUsuarioDAO(FechamentoCaixaModel fechamento)
        {
            if (fechamento == null)
                return null;
            else
                return new FECHAMENTO_CAIXA()
                {
                    DATA = fechamento.Data.Value,
                    DATA_FECHAMENTO = fechamento.DataFechamento,
                    IDFCX = fechamento.IdFechamentoCaixa,
                    OBSERVACOES = fechamento.Observacoes,
                    PERIODO = ConverterPeriodoDeStringParaEnum(fechamento.Periodo),
                    QUANTIDADE = fechamento.Quantidade,
                    TOTAL = fechamento.Valor,
                    USUARIO = fechamento.Usuario
                };
        }

        private static FechamentoCaixaModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new FechamentoCaixaModel()
            {
                Data = string.IsNullOrEmpty(form["data"]) ? null : (DateTime?)Convert.ToDateTime(form["data"]),
                DataFechamento = string.IsNullOrEmpty(form["dataFechamento"]) ? null : (DateTime?)Convert.ToDateTime(form["dataFechamento"]),
                IdFechamentoCaixa = string.IsNullOrEmpty(form["codigoFechamentoCaixa"]) ? 0 : Convert.ToInt32(form["codigoFechamentoCaixa"]),
                Observacoes = string.IsNullOrEmpty(form["observacoes"]) ? null : form["observacoes"],
                Periodo = string.IsNullOrEmpty(form["periodo"]) ? EnumFinanceiro.PeriodoFechamentoCaixa.vazio : (EnumFinanceiro.PeriodoFechamentoCaixa)Convert.ToInt32(form["periodo"]),
                Quantidade = string.IsNullOrEmpty(form["quantidade"]) ? 0 : Convert.ToInt32(form["quantidade"]),
                Usuario = string.IsNullOrEmpty(form["usuario"]) ? null : form["usuario"],
                Valor = string.IsNullOrEmpty(form["total"]) ? null : (decimal?)Convert.ToDecimal(form["total"])
            };
        }
    }
}
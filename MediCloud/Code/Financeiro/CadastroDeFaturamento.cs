using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.DatabaseModels;
using MediCloud.Models.Financeiro;
using MediCloud.BusinessProcess.Financeiro;
using System.Web.Mvc;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeFaturamento
    {
        internal static FaturamentoModel RecuperarFaturamentoPorID(decimal? idFat, bool carregarClasses = true)
        {
            if (idFat.HasValue && idFat != 0)
            {
                FATURAMENTO faturamentoEncontrado = ControleDeFaturamento.buscarFaturamentoPorID(idFat);
                return InjetarEmUsuarioModel(faturamentoEncontrado, carregarClasses);
            }
            else
                return null;
        }

        private static FaturamentoModel InjetarEmUsuarioModel(FATURAMENTO x, bool carregarClasses = false)
        {
            if (x == null)
                return null;
            else
                return new FaturamentoModel()
                {
                    Ano = (int)x.ANO,
                    Data = x.DATA,
                    Dia = Convert.ToInt32(x.DIA),
                    IdFaturamento = (int)x.IDFAT,
                    DataLimite = x.DATALIMITE,
                    Mes = x.MES,
                    Usuario = x.USUARIO,
                    Valor = x.VALOR,

                    NotasFiscais = carregarClasses ? CadastroDeNotaFiscal.RecuperarNotasFiscaisDeFaturamento(x.IDFAT) : new List<NotaFiscalModel>()
                };
        }

        internal static List<FaturamentoModel> RecuperarFaturamentoPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            return RecuperarFaturamentoPorTermo(prefix);
        }

        internal static List<FaturamentoModel> RecuperarFaturamentoPorTermo(string prefix)
        {
            List<FATURAMENTO> contadoresEncontrados = ControleDeFaturamento.BuscarFaturamentoPorTermo(prefix); 
            List<FaturamentoModel> resultados = new List<FaturamentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static FATURAMENTO injetarEmUsuarioDAO(FaturamentoModel faturamento)
        {
            if (faturamento == null)
                return null;
            else
                return new FATURAMENTO()
                {
                    ANO = faturamento.Ano,
                    DATA = faturamento.Data ?? DateTime.MinValue,
                    DATALIMITE = faturamento.DataLimite,
                    DIA = faturamento.Dia.ToString(),
                    IDCLI_FIN = faturamento.IdClienteFim,
                    IDCLI_INI = faturamento.IdClienteInicio,
                    IDFAT = faturamento.IdFaturamento,
                    MES = faturamento.Mes,
                    USUARIO = faturamento.Usuario,
                    VALOR = faturamento.Valor
                };
        }

        internal static void DeletarFaturamento(int codigoFaturamento)
        {
            ControleDeFaturamento.ExcluirFaturamento(codigoFaturamento);
        }

        internal static FaturamentoModel SalvarFaturamento(FormCollection form)
        {
            FaturamentoModel faturamentoModel = InjetarEmUsuarioModel(form);
            faturamentoModel.validar();

            FATURAMENTO faturamentoDAO = InjetarEmUsuarioDAO(faturamentoModel);
            faturamentoDAO = ControleDeFaturamento.SalvarFaturamento(faturamentoDAO);

            faturamentoModel = InjetarEmUsuarioModel(faturamentoDAO);

            return faturamentoModel;
        }

        private static FATURAMENTO InjetarEmUsuarioDAO(FaturamentoModel x)
        {
            if (x == null)
                return null;
            else
                return new FATURAMENTO()
                {
                    ANO = x.Ano,
                    DATA = x.Data ?? DateTime.MinValue,
                    DATALIMITE = x.DataLimite,
                    DIA = x.Dia.ToString(),
                    IDCLI_FIN = x.IdClienteFim,
                    IDCLI_INI = x.IdClienteInicio,
                    IDFAT = x.IdFaturamento,
                    MES = x.Mes,
                    USUARIO = x.Usuario,
                    VALOR = x.Valor
                };
        }

        private static FaturamentoModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new FaturamentoModel()
            {
                Ano = string.IsNullOrEmpty(form["ano"]) ? 0 : Convert.ToInt32(form["ano"]),
                Data = string.IsNullOrEmpty(form["data"]) ? null : (DateTime?)Convert.ToDateTime(form["data"]),
                DataLimite = string.IsNullOrEmpty(form["dataLimite"]) ? null : (DateTime?)Convert.ToDateTime(form["dataLimite"]),
                Dia = string.IsNullOrEmpty(form["dia"]) ? 0 : Convert.ToInt32(form["dia"]),
                IdFaturamento = string.IsNullOrEmpty(form["codigoFaturamento"]) ? 0 : Convert.ToInt32(form["codigoFaturamento"]),
                Mes = string.IsNullOrEmpty(form["mes"]) ? null : form["mes"],
                Usuario = string.IsNullOrEmpty(form["usuario"]) ? null : form["usuario"],
                Valor = string.IsNullOrEmpty(form["valorFatura"]) ? null : (decimal?)Convert.ToDecimal(form["valorFatura"])
            };
        }

        internal static void FecharFaturamento(int codigoFaturamento)
        {
            ControleDeFaturamento.FecharFaturamento(codigoFaturamento);
        }
    }
}
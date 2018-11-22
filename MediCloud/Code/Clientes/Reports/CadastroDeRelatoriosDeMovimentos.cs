using MediCloud.BusinessProcess.Cliente.Reports;
using MediCloud.Models.Seguranca;
using System;
using System.Web.Mvc;

namespace MediCloud.Code.Reports.Clientes
{
    public class CadastroDeRelatoriosDeMovimentos
    {
        #region Internal Methods

        internal static byte[] GerarRelatorioAnual(FormCollection form)
        {
            #region Recuperação dos filtros

            int idCliente = string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"]);

            IntervaloDeDatasModel dataDoMovimento = new IntervaloDeDatasModel()
            {
                DataInicial = string.IsNullOrEmpty(form["periodoInicio"]) ? null : (DateTime?)Convert.ToDateTime(form["periodoInicio"]),
                DataFinal = string.IsNullOrEmpty(form["periodoFim"]) ? null : (DateTime?)Convert.ToDateTime(form["periodoFim"])
            };

            #endregion Recuperação dos filtros

            return ControleDeRelatoriosDeMovimentos.ImprimirRelatorioAnual(idCliente, dataDoMovimento.DataInicial, dataDoMovimento.DataFinal);
        }

        internal static byte[] GerarRelatorioDeConvocacoes(FormCollection form)
        {
            #region Recuperação dos filtros

            int idCliente = string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"]);
            int idFuncionario = string.IsNullOrEmpty(form["idFuncionario"]) ? 0 : Convert.ToInt32(form["idFuncionario"]);

            IntervaloDeDatasModel dataDoMovimento = new IntervaloDeDatasModel()
            {
                DataInicial = string.IsNullOrEmpty(form["dataMovimentoInicio"]) ? null : (DateTime?)Convert.ToDateTime(form["dataMovimentoInicio"]),
                DataFinal = string.IsNullOrEmpty(form["dataMovimentoFim"]) ? null : (DateTime?)Convert.ToDateTime(form["dataMovimentoFim"])
            };

            #endregion Recuperação dos filtros

            return ControleDeRelatoriosDeMovimentos.ImprimirRelatorioDeConvocacoes(idCliente, idFuncionario, dataDoMovimento.DataInicial, dataDoMovimento.DataFinal);
        }

        #endregion Internal Methods
    }
}
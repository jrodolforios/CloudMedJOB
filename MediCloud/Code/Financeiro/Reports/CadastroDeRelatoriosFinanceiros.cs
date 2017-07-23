using MediCloud.BusinessProcess.Financeiro.Reports;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Code.Financeiro.Reports
{
    public class CadastroDeRelatoriosFinanceiros
    {
        internal static byte[] GerarRelatorioDeMovimentos(FormCollection form)
        {
            #region Recuperação dos filtros
            int idProcedimento = string.IsNullOrEmpty(form["idProcedimento"]) ? 0 : Convert.ToInt32(form["idProcedimento"]);
            string IdProfissional = string.IsNullOrEmpty(form["idProfissional"]) ? string.Empty : form["idProfissional"];

            IntervaloDeDatasModel dataDoExame = new IntervaloDeDatasModel()
            {
                DataInicial = string.IsNullOrEmpty(form["dataExameInicio"]) ? null : (DateTime?)Convert.ToDateTime(form["dataExameInicio"]),
                DataFinal = string.IsNullOrEmpty(form["dataExameFim"]) ? null : (DateTime?)Convert.ToDateTime(form["dataExameFim"])
            };

            IntervaloDeDatasModel dataDoMovimento = new IntervaloDeDatasModel()
            {
                DataInicial = string.IsNullOrEmpty(form["dataMovimentoInicio"]) ? null : (DateTime?)Convert.ToDateTime(form["dataMovimentoInicio"]),
                DataFinal = string.IsNullOrEmpty(form["dataMovimentoFim"]) ? null : (DateTime?)Convert.ToDateTime(form["dataMovimentoFim"])
            };

            int idFuncionario = string.IsNullOrEmpty(form["idFuncionario"]) ? 0 : Convert.ToInt32(form["idFuncionario"]);
            int idCliente = string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"]);
            #endregion

            return ControleDeRelatoriosFinanceiros.ImprimirASOComMedCoord(idProcedimento,IdProfissional, dataDoExame.DataInicial, dataDoExame.DataFinal, dataDoMovimento.DataInicial, dataDoMovimento.DataFinal, idFuncionario, idCliente);
        }
    }
}
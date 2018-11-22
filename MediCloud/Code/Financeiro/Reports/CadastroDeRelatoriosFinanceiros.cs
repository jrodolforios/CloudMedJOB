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
            int idFornecedor = string.IsNullOrEmpty(form["idFornecedor"]) ? 0 : Convert.ToInt32(form["idFornecedor"]);

            IntervaloDeDatasModel dataDoExame = new IntervaloDeDatasModel()
            {
                DataInicial = string.IsNullOrEmpty(form["dataExameInicio"]) ? null : (DateTime?)Convert.ToDateTime(form["dataExameInicio"]),
                DataFinal = string.IsNullOrEmpty(form["dataExameFim"]) ? null : (DateTime?)Convert.ToDateTime(form["dataExameFim"])
            };

            int idFuncionario = string.IsNullOrEmpty(form["idFuncionario"]) ? 0 : Convert.ToInt32(form["idFuncionario"]);
            int idCliente = string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"]);
            #endregion

            return ControleDeRelatoriosFinanceiros.ImprimirRelatorioDeMovimentos(idProcedimento,IdProfissional, idFornecedor, dataDoExame.DataInicial, dataDoExame.DataFinal, idFuncionario, idCliente);
        }

        internal static byte[] GerarRelatorioAnaliticoDeFaturamento(FormCollection form)
        {
            #region Recuperação dos filtros
            int idCliente = string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"]);
            int idGrupoDeClientes = string.IsNullOrEmpty(form["idGrupoDeClientes"]) ? 0 : Convert.ToInt32(form["idGrupoDeClientes"]);
            int idProcedimento = string.IsNullOrEmpty(form["idProcedimento"]) ? 0 : Convert.ToInt32(form["idProcedimento"]);
            int idFaturamento = string.IsNullOrEmpty(form["idFaturamento"]) ? 0 : Convert.ToInt32(form["idFaturamento"]);
            string informacoesAdicionais = string.IsNullOrEmpty(form["informacoesAdicionaisRel"]) ? string.Empty : form["informacoesAdicionaisRel"];
            #endregion

            return ControleDeRelatoriosFinanceiros.ImprimirRelatorioAnaliticoDeFaturamento(idCliente, idGrupoDeClientes, idProcedimento, idFaturamento,informacoesAdicionais);

        }
    }
}
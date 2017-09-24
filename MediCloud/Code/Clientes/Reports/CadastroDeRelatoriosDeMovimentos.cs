using MediCloud.BusinessProcess.Cliente.Reports;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Code.Reports.Clientes
{
    public class CadastroDeRelatoriosDeMovimentos
    {
        internal static byte[] GerarRelatorioAnual(FormCollection form)
        {
            #region Recuperação dos filtros
            int idCliente = string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"]);

            IntervaloDeDatasModel dataDoMovimento = new IntervaloDeDatasModel()
            {
                DataInicial = string.IsNullOrEmpty(form["periodoInicio"]) ? null : (DateTime?)Convert.ToDateTime(form["periodoInicio"]),
                DataFinal = string.IsNullOrEmpty(form["periodoFim"]) ? null : (DateTime?)Convert.ToDateTime(form["periodoFim"])
            };

            #endregion

            return ControleDeRelatoriosDeMovimentos.ImprimirRelatorioAnual(idCliente, dataDoMovimento.DataInicial, dataDoMovimento.DataFinal);
        }
    }
}
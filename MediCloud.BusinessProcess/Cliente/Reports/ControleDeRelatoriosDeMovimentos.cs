using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;

namespace MediCloud.BusinessProcess.Cliente.Reports
{
    public class ControleDeRelatoriosDeMovimentos
    {
        public static byte[] ImprimirRelatorioAnual(int idCliente, DateTime? dataInicial, DateTime? dataFinal)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                INFORMACOES_CLINICA informacoesDaClinica = Util.Util.RecuperarInformacoesDaClinica();

                List<SELECTANUAL> tempProc = new List<SELECTANUAL>();

                CLIENTE ClienteReport = contexto.CLIENTE.First(x => x.IDCLI == idCliente);

                List<SELECTANUAL> Resultado = new List<SELECTANUAL>();

                Resultado.AddRange(contexto.SELECTANUAL.Where(x => x.RAZAOSOCIAL == ClienteReport.RAZAOSOCIAL && x.NOMEFANTASIA == ClienteReport.NOMEFANTASIA
                                    && ((dataInicial.HasValue && dataFinal.HasValue) ? ((x.DATAMOV.HasValue ? x.DATAMOV.Value >= (dataInicial.HasValue ? dataInicial.Value : DateTime.MinValue) : true) && (x.DATAMOV.HasValue ? x.DATAMOV.Value <= (dataFinal.HasValue ? dataFinal.Value : DateTime.MaxValue) : true)) : true)
                                    ).ToList());

                MovimentoReports Report = new MovimentoReports(Resultado, informacoesDaClinica, Util.Enum.Cliente.MovimentoReportEnum.imprimirRelatorioAnual, (dataInicial.HasValue ? dataFinal.Value : DateTime.MaxValue), (dataFinal.HasValue ? dataFinal.Value : DateTime.MinValue));

                return Report.generate();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
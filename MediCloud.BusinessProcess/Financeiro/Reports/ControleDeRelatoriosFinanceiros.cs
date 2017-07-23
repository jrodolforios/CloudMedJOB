using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCloud.BusinessProcess.Financeiro.Reports
{
    public class ControleDeRelatoriosFinanceiros
    {
        public static byte[] ImprimirASOComMedCoord(int idProcedimento, string idProfissional, DateTime? dataInicialExame, DateTime? dataFinalExame, DateTime? dataInicialMovimento, DateTime? dataFinalMovimento, int idFuncionario, int idCliente)
        {

            CloudMedContext contexto = new CloudMedContext();

            try
            {
                INFORMACOES_CLINICA informacoesDaClinica = Util.Util.RecuperarInformacoesDaClinica();

                List<MOVIMENTO_PROCEDIMENTO> tempProc = new List<MOVIMENTO_PROCEDIMENTO>();
                List<MOVIMENTO> reportResult = contexto.MOVIMENTO.Where(
                    
                    x => x.MOVIMENTO_PROCEDIMENTO.Any(y => 
                    y.IDMOV == x.IDMOV
                    && (idProcedimento <= 0 ? true : y.IDPRO == idProcedimento) 
                    && (string.IsNullOrEmpty(idProfissional) ? true : y.IDPRF == idProfissional)
                    && ((dataFinalExame.HasValue && dataFinalExame.HasValue) ? ((y.DATAEXAME.HasValue ? y.DATAEXAME.Value >= (dataInicialExame.HasValue ? dataInicialExame.Value : DateTime.MaxValue) : true) && (y.DATAEXAME.HasValue ? y.DATAEXAME.Value <= (dataFinalExame.HasValue ? dataFinalExame.Value : DateTime.MinValue) : true)) : true)
                    )

                    && ((dataInicialMovimento.HasValue && dataFinalMovimento.HasValue) ? ((x.DATAMOV.HasValue ? x.DATAMOV.Value >= (dataInicialMovimento.HasValue ? dataInicialMovimento.Value : DateTime.MaxValue) : true) && (x.DATAMOV.HasValue ? x.DATAMOV.Value <= (dataFinalMovimento.HasValue ? dataFinalMovimento.Value : DateTime.MinValue) : true)) : true)
                    && (idFuncionario <= 0 ? true : x.IDFUN == idFuncionario)
                    && (idCliente <= 0 ? true : x.IDCLI == idCliente)
                    ).ToList();

                reportResult.ForEach(x => {
                    tempProc.Clear();
                    tempProc.AddRange(x.MOVIMENTO_PROCEDIMENTO.Where(y =>
                    y.IDMOV == x.IDMOV
                    && (idProcedimento <= 0 ? true : y.IDPRO == idProcedimento)
                    && (string.IsNullOrEmpty(idProfissional) ? true : y.IDPRF == idProfissional)
                    && ((dataFinalExame.HasValue && dataFinalExame.HasValue) ? ((y.DATAEXAME.HasValue ? y.DATAEXAME.Value >= (dataInicialExame.HasValue ? dataInicialExame.Value : DateTime.MaxValue) : true) && (y.DATAEXAME.HasValue ? y.DATAEXAME.Value <= (dataFinalExame.HasValue ? dataFinalExame.Value : DateTime.MinValue) : true)) : true)
                    ).ToList());

                    x.MOVIMENTO_PROCEDIMENTO.Clear();

                    tempProc.ForEach(y => 
                    {
                        x.MOVIMENTO_PROCEDIMENTO.Add(y);
                    });
                });

                FinanceiroReports Report = new FinanceiroReports(reportResult, informacoesDaClinica, Util.Enum.Financeiro.FinanceiroReportEnum.imprimirRelatorioDeMovimentos);

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

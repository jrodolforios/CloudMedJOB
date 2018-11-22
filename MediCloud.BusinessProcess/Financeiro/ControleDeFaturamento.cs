using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeFaturamento
    {
        #region Public Methods

        public static FATURAMENTO buscarFaturamentoPorID(decimal? idFat)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                FATURAMENTO faturamento = contexto.FATURAMENTO.First(x => x.IDFAT == idFat);

                return faturamento;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public static List<FATURAMENTO> BuscarFaturamentoPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.FATURAMENTO.Where(x => prefix.Contains(x.ANO.ToString())
                                                    || prefix.Contains(x.MES.ToString())
                                                    || prefix.Contains(x.DIA.ToString())
                                                    || prefix.Contains(((int)x.IDFAT).ToString())).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<FATURAMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirFaturamento(int codigoFaturamento)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.FATURAMENTO.Any(x => x.IDFAT == codigoFaturamento))
                    contexto.FATURAMENTO.Remove(contexto.FATURAMENTO.First(x => x.IDFAT == codigoFaturamento));

                contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void FecharFaturamento(int codigoFaturamento)
        {
            CloudMedContext contexto = new CloudMedContext();
            FATURAMENTO setorSalvo = new FATURAMENTO();

            try
            {
                contexto.Database.ExecuteSqlCommand($"EXEC FECHA_FATURAMENTO {codigoFaturamento}");
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal RecuperarFaturaPrevistaMes(int mes, int ano)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                decimal? totalNoMesAnoIndicado = contexto.MOVIMENTO_PROCEDIMENTO.Where(x => x.DATAEXAME.Value.Month == mes && x.DATAEXAME.Value.Year == ano).Sum(x => x.TOTAL);

                return totalNoMesAnoIndicado ?? 0;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal RecuperarFaturaPrevistaMesAtual()
        {
            return RecuperarFaturaPrevistaMes(DateTime.Now.Month, DateTime.Now.Year);
        }

        public static List<decimal?> RecuperarUltimosOitoMesesDeFaturamento()
        {
            return RecuperarUltimosOitoMesesDeFaturamento(DateTime.Now.Month, DateTime.Now.Year);
        }

        public static List<decimal?> RecuperarUltimosOitoMesesDeFaturamento(int mes, int ano)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                List<MOVIMENTO_PROCEDIMENTO> totalNoMesAnoIndicado = contexto.MOVIMENTO_PROCEDIMENTO.Where(x => (x.DATAEXAME.Value.Month <= mes && x.DATAEXAME.Value.Year == ano) || x.DATAEXAME.Value.Year == ano - 1).OrderByDescending(x => x.DATAEXAME).ToList();

                List<decimal?> TotalMeses = totalNoMesAnoIndicado.OrderByDescending(x => x.DATAEXAME.Value.Year.ToString() + x.DATAEXAME.Value.Month.ToString()).GroupBy(x => x.DATAEXAME.Value.Year.ToString() + x.DATAEXAME.Value.Month.ToString()).Take(8).Select(x => x.Sum(y => y.TOTAL)).ToList();

                return TotalMeses;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<decimal?>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FATURAMENTO SalvarFaturamento(FATURAMENTO faturamentoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            FATURAMENTO setorSalvo = new FATURAMENTO();

            try
            {
                //Garantir que pegue o faturamento do dia inteiro.
                faturamentoDAO.DATALIMITE = faturamentoDAO.DATALIMITE?.AddDays(1).AddSeconds(-1);

                if (faturamentoDAO.IDFAT > 0)
                {
                    setorSalvo = contexto.FATURAMENTO.First(x => x.IDFAT == faturamentoDAO.IDFAT);

                    setorSalvo.ANO = faturamentoDAO.ANO;
                    setorSalvo.DATA = faturamentoDAO.DATA;
                    setorSalvo.DATALIMITE = faturamentoDAO.DATALIMITE;
                    setorSalvo.DIA = faturamentoDAO.DIA;
                    setorSalvo.IDCLI_FIN = faturamentoDAO.IDCLI_FIN;
                    setorSalvo.IDCLI_INI = faturamentoDAO.IDCLI_INI;
                    setorSalvo.MES = faturamentoDAO.MES;
                    setorSalvo.USUARIO = faturamentoDAO.USUARIO;
                    setorSalvo.VALOR = faturamentoDAO.VALOR;
                }
                else
                {
                    setorSalvo = contexto.FATURAMENTO.Add(faturamentoDAO);
                }

                contexto.SaveChanges();
                return setorSalvo;
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

        #endregion Public Methods
    }
}
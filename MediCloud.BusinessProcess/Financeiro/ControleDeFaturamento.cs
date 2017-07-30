using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeFaturamento
    {
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

        public static FATURAMENTO SalvarFaturamento(FATURAMENTO faturamentoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            FATURAMENTO setorSalvo = new FATURAMENTO();

            try
            {
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
    }
}

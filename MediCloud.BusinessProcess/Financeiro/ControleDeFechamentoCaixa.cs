using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeFechamentoCaixa
    {
        public static List<FECHAMENTO_CAIXA> RecuperarFechamentoCaixaPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.FECHAMENTO_CAIXA.Where(x => prefix.Contains(x.USUARIO.ToString())
                                                    || prefix.Contains(x.DATA.Month.ToString())
                                                    || prefix.Contains(x.DATA.Year.ToString())
                                                    || prefix.Contains(x.DATA.Day.ToString())).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<FECHAMENTO_CAIXA>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FECHAMENTO_CAIXA BuscarFechamentoCaixa(int codigoFechamentoCaixa)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.FECHAMENTO_CAIXA.Any(x => x.IDFCX == codigoFechamentoCaixa))
                    return contexto.FECHAMENTO_CAIXA.First(x => x.IDFCX == codigoFechamentoCaixa);

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

        public static void DeletarFechamentoCaixa(int codigoFechamentoCaixa)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.FECHAMENTO_CAIXA.Any(x => x.IDFCX == codigoFechamentoCaixa))
                    contexto.FECHAMENTO_CAIXA.Remove(contexto.FECHAMENTO_CAIXA.First(x => x.IDFCX == codigoFechamentoCaixa));

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

        public static void FecharCaixa(int codigoFechamentoDeCaixa)
        {
            CloudMedContext contexto = new CloudMedContext();
            FATURAMENTO setorSalvo = new FATURAMENTO();

            try
            {
                contexto.Database.ExecuteSqlCommand($"EXEC FECHA_CAIXA_DIARIO {codigoFechamentoDeCaixa}");
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

        public static List<SLCONSULTAMOVIMENTO> RecuperarDetalhesDeFechamentoDeCaixa(int idFechamentoCaixa)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.SLCONSULTAMOVIMENTO.Where(x => x.IDFCX == idFechamentoCaixa).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<SLCONSULTAMOVIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static FECHAMENTO_CAIXA SalvarFechamentoCaixa(FECHAMENTO_CAIXA fechamentoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            FECHAMENTO_CAIXA setorSalvo = new FECHAMENTO_CAIXA();

            try
            {
                if (fechamentoDAO.IDFCX > 0)
                {
                    setorSalvo = contexto.FECHAMENTO_CAIXA.First(x => x.IDFCX == fechamentoDAO.IDFCX);

                    setorSalvo.DATA = fechamentoDAO.DATA;
                    setorSalvo.DATA_FECHAMENTO = fechamentoDAO.DATA_FECHAMENTO;
                    setorSalvo.OBSERVACOES = fechamentoDAO.OBSERVACOES;
                    setorSalvo.PERIODO = fechamentoDAO.PERIODO;
                    setorSalvo.QUANTIDADE = fechamentoDAO.QUANTIDADE;
                    setorSalvo.TOTAL = fechamentoDAO.TOTAL;
                    setorSalvo.USUARIO = fechamentoDAO.USUARIO;
                }
                else
                {
                    setorSalvo = contexto.FECHAMENTO_CAIXA.Add(fechamentoDAO);
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
    }
}

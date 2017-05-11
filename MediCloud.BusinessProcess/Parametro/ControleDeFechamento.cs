using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeFechamento
    {
        public static List<MOVIMENTO_FECHAMENTO> buscarCidadePorTermo(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<MOVIMENTO_FECHAMENTO> fechamento = contexto.MOVIMENTO_FECHAMENTO.Where(x => x.PERIODO.Contains(termo)
                                                                                              || x.DIA.Contains(termo)).ToList();

                return fechamento;
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

        public static MOVIMENTO_FECHAMENTO RecuperarFechamentoPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.MOVIMENTO_FECHAMENTO.Any(x => x.IDFEC == v))
                    return contexto.MOVIMENTO_FECHAMENTO.First(x => x.IDFEC == v);
                else
                    return null;
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

        public static void DeletarFechamento(int codigoDoFechamento)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.MOVIMENTO_FECHAMENTO.Any(x => x.IDFEC == codigoDoFechamento))
                    contexto.MOVIMENTO_FECHAMENTO.Remove(contexto.MOVIMENTO_FECHAMENTO.First(x => x.IDFEC == codigoDoFechamento));

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

        public static MOVIMENTO_FECHAMENTO SalvarFechamento(MOVIMENTO_FECHAMENTO fechamentoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            MOVIMENTO_FECHAMENTO setorSalvo = new MOVIMENTO_FECHAMENTO();

            try
            {

                if (fechamentoDAO.IDFEC > 0)
                {
                    setorSalvo = contexto.MOVIMENTO_FECHAMENTO.First(x => x.IDFEC == fechamentoDAO.IDFEC);

                    setorSalvo.DIA = fechamentoDAO.DIA;
                    setorSalvo.PERIODO = fechamentoDAO.PERIODO;
                    setorSalvo.PRAZOBOLETO = fechamentoDAO.PRAZOBOLETO;
                }
                else
                {
                    setorSalvo = contexto.MOVIMENTO_FECHAMENTO.Add(fechamentoDAO);
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

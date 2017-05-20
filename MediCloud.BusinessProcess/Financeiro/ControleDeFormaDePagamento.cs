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
    public class ControleDeFormaDePagamento
    {
        public static FORMADEPAGAMENTO buscarFormaDePagamento(int idFormPag)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.FORMADEPAGAMENTO.Where(x => x.IDFORPAG == idFormPag).First();
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

        public static List<FORMADEPAGAMENTO> RecuperarTodos()
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.FORMADEPAGAMENTO.ToList();
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

        public static List<FORMADEPAGAMENTO> RecuperarFormaDePagamentoPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.FORMADEPAGAMENTO.Where(x => x.FORMADEPAGAMENTO1.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<FORMADEPAGAMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarFormaPagamento(int codigoFormaPagamento)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.FORMADEPAGAMENTO.Any(x => x.IDFORPAG == codigoFormaPagamento))
                    contexto.FORMADEPAGAMENTO.Remove(contexto.FORMADEPAGAMENTO.First(x => x.IDFORPAG == codigoFormaPagamento));

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

        public static FORMADEPAGAMENTO SalvarFormaPagamento(FORMADEPAGAMENTO formaPagamentoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            FORMADEPAGAMENTO setorSalvo = new FORMADEPAGAMENTO();

            try
            {

                if (formaPagamentoDAO.IDFORPAG > 0)
                {
                    setorSalvo = contexto.FORMADEPAGAMENTO.First(x => x.IDFORPAG == formaPagamentoDAO.IDFORPAG);

                    setorSalvo.FORMADEPAGAMENTO1 = formaPagamentoDAO.FORMADEPAGAMENTO1;
                    setorSalvo.TIPOPAGTO = formaPagamentoDAO.TIPOPAGTO;
                }
                else
                {
                    setorSalvo = contexto.FORMADEPAGAMENTO.Add(formaPagamentoDAO);
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

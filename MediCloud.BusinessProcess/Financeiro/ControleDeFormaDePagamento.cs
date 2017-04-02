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
    }
}

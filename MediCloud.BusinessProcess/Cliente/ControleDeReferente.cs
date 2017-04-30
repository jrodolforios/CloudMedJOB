using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Cliente
{
    public class ControleDeReferente
    {
        public static MOVIMENTO_REFERENTE buscarFormaDePagamento(int idRef)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.MOVIMENTO_REFERENTE.Where(x => x.IDREF == idRef).First();
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

        public static List<MOVIMENTO_REFERENTE> RecuperarTodos()
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.MOVIMENTO_REFERENTE.ToList();
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

        public static List<MOVIMENTO_REFERENTE> buscarReferentePorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<MOVIMENTO_REFERENTE> referencia = contexto.MOVIMENTO_REFERENTE.Where(x => x.NOMEREFERENCIA.Contains(prefix)).ToList();

                return referencia;
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
    }
}

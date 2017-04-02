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
    public class ControleDeTabelaPreco
    {
        public static TABELA buscarSetorPorID(int idRef)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.TABELA.Where(x => x.IDTAB == idRef).First();
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

        public static List<TABELA> RecuperarTodos()
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.TABELA.ToList();
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

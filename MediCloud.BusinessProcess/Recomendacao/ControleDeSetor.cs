using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Recomendacao
{
    public class ControleDeSetor
    {
        public static SETOR buscarSetorPorID(int idRef)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.SETOR.Where(x => x.IDSETOR == idRef).First();
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

        public static List<SETOR> buscarSetorPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<SETOR> cargo = contexto.SETOR.Where(x => x.SETOR1.Contains(prefix)).ToList();

                return cargo;
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

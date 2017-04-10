using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using MediCloud.BusinessProcess.Util;
using System.Data.Entity.Validation;

namespace MediCloud.BusinessProcess.Fornecedor
{
    public class ControleDeFornecedor
    {
        public static FORNECEDOR buscarProcedimentosMovimentoPorIdMovimento(int idFor)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.FORNECEDOR.First(x => x.IDFOR == idFor);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new FORNECEDOR();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<FORNECEDOR> buscarCargosPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.FORNECEDOR.Where(x => x.RAZAOSOCIAL.Contains(prefix)
                || x.NOMEFANTASIA.Contains(prefix)
                ).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<FORNECEDOR>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

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
    public class ControleDeProcedimentosMovimento
    {
        public static List<MOVIMENTO_PROCEDIMENTO> buscarProcedimentosMovimentoPorIdMovimento(decimal idMov)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.MOVIMENTO_PROCEDIMENTO.Where(x => x.IDMOV == idMov).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<MOVIMENTO_PROCEDIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarProcedimento(int codigoProcedimento)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                contexto.MOVIMENTO_PROCEDIMENTO.Remove(contexto.MOVIMENTO_PROCEDIMENTO.First(x => x.IDMOVPRO == codigoProcedimento));
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
    }
}

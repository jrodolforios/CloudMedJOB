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
    public class ControleDeASO
    {
        public static List<MOVIMENTO> buscarCliente(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.MOVIMENTO.ToList();
                }
                else
                {
                    return contexto.MOVIMENTO.Where(x => x.CLIENTE.NOMEFANTASIA.Contains(termo)
                        || x.FUNCIONARIO.FUNCIONARIO1.Contains(termo)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<MOVIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MOVIMENTO buscarASOPorId(int idASO)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (idASO <= 0)
                {
                    return null;
                }
                else
                {
                    return contexto.MOVIMENTO.First(x => x.IDMOV == idASO);
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new MOVIMENTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Laudo
{
    public class ControleDeLaudoRX
    {
        public static List<LAUDORX> buscarLaudoRX(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.LAUDORX.ToList();
                }
                else
                {
                    return contexto.LAUDORX.Where(x => x.MEDICO.Contains(termo)
                        || x.PACIENTE.Contains(termo)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<LAUDORX>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

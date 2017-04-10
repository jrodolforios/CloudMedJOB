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
    public class ControleDeProfissional
    {
        public static PROFISSIONAIS recuperarProfissionalPorID(string idPro)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.PROFISSIONAIS.Any(x => x.IDPRF == idPro))
                    return contexto.PROFISSIONAIS.First(x => x.IDPRF == idPro);
                else
                    return null;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new PROFISSIONAIS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PROFISSIONAIS> buscarCargosPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.PROFISSIONAIS.Where(x => x.PROFISSIONAL.Contains(prefix) || x.IDPRF.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<PROFISSIONAIS>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

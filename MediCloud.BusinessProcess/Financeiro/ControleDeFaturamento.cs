using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeFaturamento
    {
        public static FATURAMENTO buscarCargoPorID(decimal? idFat)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                FATURAMENTO faturamento = contexto.FATURAMENTO.First(x => x.IDFAT == idFat);

                return faturamento;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Parametro.GrupoProcedimento
{
    public class ControleDeGrupo
    {
        public static PROCEDIMENTO_GRUPO recuperarSubGrupoPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.PROCEDIMENTO_GRUPO.First(x => x.IDGRUPRO == v);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new PROCEDIMENTO_GRUPO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

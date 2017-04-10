using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using MediCloud.BusinessProcess.Util;
using System.Data.Entity.Validation;

namespace MediCloud.BusinessProcess.Parametro.GrupoProcedimento
{
    public class ControleDeSubGrupo
    {
        public static PROCEDIMENTO_GRUPO_SUBGRUP recuperarSubGrupoPorID(int idSubGrupo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.PROCEDIMENTO_GRUPO_SUBGRUP.First(x => x.IDSUBGRUPRO == idSubGrupo);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new PROCEDIMENTO_GRUPO_SUBGRUP();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

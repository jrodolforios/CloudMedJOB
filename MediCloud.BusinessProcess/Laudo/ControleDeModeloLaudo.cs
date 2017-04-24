using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Laudo
{
    public class ControleDeModeloLaudo
    {
        public static List<MODELOLAUDO> buscarModeloLaudo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(prefix))
                {
                    return contexto.MODELOLAUDO.ToList();
                }
                else
                {
                    return contexto.MODELOLAUDO.Where(x => x.MODELO.Contains(prefix)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<MODELOLAUDO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MODELOLAUDO buscarModeloLaudoPorId(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (v <= 0)
                {
                    return null;
                }
                else
                {
                    return contexto.MODELOLAUDO.First(x => (int)x.IDMODELO == v);
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new MODELOLAUDO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

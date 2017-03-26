using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeElaboradorPCMSO
    {
        public static List<EPCMSO> BuscarElaboradoresPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.EPCMSO.Where(x => x.ELABORADORPCMSO.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<EPCMSO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EPCMSO BuscarElaboradorPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            if (v == 0)
                return null;

            try
            {
                return contexto.EPCMSO.First(x => x.IDEPCMSO == v);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new EPCMSO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
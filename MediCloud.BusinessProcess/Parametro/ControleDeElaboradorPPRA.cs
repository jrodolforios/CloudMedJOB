using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Util;
using System.Data.Entity.Validation;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeElaboradorPPRA
    {
        public static List<EPPRA> BuscarElaboradoresPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.EPPRA.Where(x => x.ELABORADORPPRA.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<EPPRA>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EPPRA BuscarElaboradorPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            if (v == 0)
                return null;
            try
            {
                return contexto.EPPRA.First(x => x.IDEPPRA == v);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new EPPRA();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
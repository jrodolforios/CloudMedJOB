using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeContador
    {
        public static List<CONTADOR> BuscarContadoresPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.CONTADOR.Where(x => x.CONTADOR1.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CONTADOR>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CONTADOR BuscarContadorPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            if (v == 0)
                return null;

            try
            {
                return contexto.CONTADOR.First(x => x.IDCONT == v);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new CONTADOR();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
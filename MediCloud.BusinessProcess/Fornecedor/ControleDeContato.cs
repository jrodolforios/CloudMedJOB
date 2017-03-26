using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;

namespace MediCloud.BusinessProcess.Fornecedor
{
    public class ControleDeContato
    {
        public static void ExcluirContato(int codigoDoContato)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.CLIENTE_CONTATO.Remove(contexto.CLIENTE_CONTATO.First(x => x.IDCON == codigoDoContato));

                contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
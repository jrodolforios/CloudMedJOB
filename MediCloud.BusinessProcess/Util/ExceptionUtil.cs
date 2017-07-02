using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCloud.BusinessProcess.Util
{
    public class ExceptionUtil
    {
        public static void TratarErrosDeValidacaoDoBanco(DbEntityValidationException ex)
        {
            string rs = "";
            foreach (var eve in ex.EntityValidationErrors)
            {
                rs = string.Format("Validação de \"{0}\" em \"{1}\" apresentou o seguinte problema de validação:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                Console.WriteLine(rs);

                foreach (var ve in eve.ValidationErrors)
                {
                    rs += "" + string.Format("- Propriedade: \"{0}\", Erro: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                }
            }
            throw new Exception(rs);
        }

        public static void GerarLogDeExcecao(Exception exc, string url = "")
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                LOG_ERRO log = new LOG_ERRO()
                {
                    Data = DateTime.Now,
                    MESSAGE = exc?.Message,
                    MESSAGE_INNER_EXCEPTION = exc.InnerException?.Message,
                    STACKTRACE = exc?.StackTrace,
                    URL = url
                };

                contexto.LOG_ERRO.Add(log);
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

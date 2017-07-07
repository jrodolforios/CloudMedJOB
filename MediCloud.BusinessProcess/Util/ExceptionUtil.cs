using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                rs = string.Format("O cadastro de \"{0}\" apresentou o seguinte problema de validação:", eve.Entry.Entity.GetType().Name);
                Console.WriteLine(rs);

                foreach (var ve in eve.ValidationErrors)
                {
                    rs += "" + string.Format("\r\n- {0}", ve.ErrorMessage);
                }
            }
            throw new InvalidOperationException(rs);
        }

        public static void GerarLogDeExcecao(Exception exc, string url = "")
        {
            CloudMedContext contexto = new CloudMedContext();
            bool enviarEmail = Convert.ToBoolean(ConfigurationManager.AppSettings["EnviarEmailDeErro"].ToString());

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

                LOG_ERRO logPersistido = contexto.LOG_ERRO.Add(log);
                contexto.SaveChanges();

                if (enviarEmail)
                    Util.EnviarEmailDeErro(logPersistido);
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

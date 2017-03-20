using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCloud.BusinessProcess.Util
{
    class ExceptionUtil
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
    }
}

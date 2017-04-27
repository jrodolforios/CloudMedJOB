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
    public class ControleDeLaudoVisao
    {
        public static List<LAUDOAV> buscarLaudoAudio(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.LAUDOAV.ToList();
                }
                else
                {
                    return contexto.LAUDOAV.Where(x => x.FUNCIONARIO.FUNCIONARIO1.Contains(termo)
                    || x.CLIENTE.NOMEFANTASIA.Contains(termo)
                    || x.CARGO.CARGO1.Contains(termo)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<LAUDOAV>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirLaudoVisao(int codigoLaudoVisao)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.LAUDOAV.Remove(contexto.LAUDOAV.First(x => x.IDLAUDO == codigoLaudoVisao));

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

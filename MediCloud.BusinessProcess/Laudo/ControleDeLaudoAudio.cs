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
    public class ControleDeLaudoAudio
    {
        public static List<LAUDOAUD> buscarLaudoAudio(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(prefix))
                {
                    return contexto.LAUDOAUD.ToList();
                }
                else
                {
                    return contexto.LAUDOAUD.Where(x => x.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.FUNCIONARIO.FUNCIONARIO1.Contains(prefix)
                    || x.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.CLIENTE.NOMEFANTASIA.Contains(prefix)
                    || x.MOVIMENTO_PROCEDIMENTO.PROCEDIMENTO.PROCEDIMENTO1.Contains(prefix)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<LAUDOAUD>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static LAUDOAUD BuscarLaudoAudioPorId(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.LAUDOAUD.Any(x => (int)x.IDLAUDO == v))
                    return contexto.LAUDOAUD.First(x => (int)x.IDLAUDO == v);
                else
                    return null;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new LAUDOAUD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirLaudoAudio(int codigoLaudoAudio)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.LAUDOAUD.Remove(contexto.LAUDOAUD.First(x => x.IDLAUDO == codigoLaudoAudio));

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeRotaDeEntrega
    {
        public static List<ROTA> BuscarContadoresPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.ROTA.Where(x => x.NOMEROTA.Contains(prefix) || x.OBSERVACAO.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<ROTA>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ROTA buscarRotaDeEntregaPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.ROTA.Any(x => x.IDROTA == v))
                    return contexto.ROTA.First(x => x.IDROTA == v);
                else
                    return null;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ROTA SalvarRotaDeEntrega(ROTA rotaDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            ROTA setorSalvo = new ROTA();

            try
            {

                if (rotaDAO.IDROTA > 0)
                {
                    setorSalvo = contexto.ROTA.First(x => x.IDROTA == rotaDAO.IDROTA);

                    setorSalvo.NOMEROTA = rotaDAO.NOMEROTA;
                    setorSalvo.OBSERVACAO = rotaDAO.OBSERVACAO;

                }
                else
                {
                    setorSalvo = contexto.ROTA.Add(rotaDAO);
                }

                contexto.SaveChanges();
                return setorSalvo;

            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarRotaDeEntrega(int codigoRotaDeEntrega)
        {
            CloudMedContext contexto = new CloudMedContext();
            ROTA setorSalvo = new ROTA();

            try
            {
                if (contexto.ROTA.Any(x => x.IDROTA == codigoRotaDeEntrega))
                    contexto.ROTA.Remove(contexto.ROTA.First(x => x.IDROTA == codigoRotaDeEntrega));

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

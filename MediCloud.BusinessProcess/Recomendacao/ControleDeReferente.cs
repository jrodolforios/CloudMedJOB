using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Recomendacao
{
    public class ControleDeReferente
    {
        public static MOVIMENTO_REFERENTE buscarFormaDePagamento(int idRef)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.MOVIMENTO_REFERENTE.Where(x => x.IDREF == idRef).First();
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

        public static List<MOVIMENTO_REFERENTE> RecuperarTodos()
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.MOVIMENTO_REFERENTE.ToList();
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

        public static void DeletarReferencia(int codigoReferencia)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.MOVIMENTO_REFERENTE.Any(x => x.IDREF == codigoReferencia))
                    contexto.MOVIMENTO_REFERENTE.Remove(contexto.MOVIMENTO_REFERENTE.First(x => x.IDREF == codigoReferencia));

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

        public static List<MOVIMENTO_REFERENTE> buscarReferentePorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<MOVIMENTO_REFERENTE> referencia = contexto.MOVIMENTO_REFERENTE.Where(x => x.NOMEREFERENCIA.Contains(prefix)).ToList();

                return referencia;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static MOVIMENTO_REFERENTE SalvarReferencia(MOVIMENTO_REFERENTE referenteDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            MOVIMENTO_REFERENTE setorSalvo = new MOVIMENTO_REFERENTE();

            try
            {

                if (referenteDAO.IDREF > 0)
                {
                    setorSalvo = contexto.MOVIMENTO_REFERENTE.First(x => x.IDREF == referenteDAO.IDREF);

                    setorSalvo.IDREF = referenteDAO.IDREF;
                    setorSalvo.NOMEREFERENCIA = referenteDAO.NOMEREFERENCIA;

                }
                else
                {
                    setorSalvo = contexto.MOVIMENTO_REFERENTE.Add(referenteDAO);
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
    }
}

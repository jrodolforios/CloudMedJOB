using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeContador
    {
        #region Public Methods

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

        public static CONTADOR buscarContadorPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CONTADOR.Any(x => x.IDCONT == v))
                    return contexto.CONTADOR.Where(x => x.IDCONT == v).First();
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

        public static void DeletarContador(int codigoContador)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CONTADOR.Any(x => x.IDCONT == codigoContador))
                    contexto.CONTADOR.Remove(contexto.CONTADOR.First(x => x.IDCONT == codigoContador));

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

        public static CONTADOR SalvarContador(CONTADOR contadorDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CONTADOR setorSalvo = new CONTADOR();

            try
            {
                if (contadorDAO.IDCONT > 0)
                {
                    setorSalvo = contexto.CONTADOR.First(x => x.IDCONT == contadorDAO.IDCONT);

                    setorSalvo.CONTADOR1 = contadorDAO.CONTADOR1;
                }
                else
                {
                    setorSalvo = contexto.CONTADOR.Add(contadorDAO);
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

        #endregion Public Methods
    }
}
using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Recomendacao
{
    public class ControleDeSetor
    {
        #region Public Methods

        public static SETOR buscarSetorPorID(int idRef)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.SETOR.Where(x => x.IDSETOR == idRef).First();
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

        public static List<SETOR> buscarSetorPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<SETOR> cargo = contexto.SETOR.Where(x => x.SETOR1.Contains(prefix)).ToList();

                return cargo;
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

        public static void ExcluirSetor(int codigoDoSetor)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.SETOR.Remove(contexto.SETOR.First(x => x.IDSETOR == codigoDoSetor));

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

        public static SETOR SalvarSetor(SETOR setorDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            SETOR setorSalvo = new SETOR();

            try
            {
                if (setorDAO.IDSETOR > 0)
                {
                    setorSalvo = contexto.SETOR.First(x => x.IDSETOR == setorDAO.IDSETOR);

                    setorSalvo.IDSETOR = setorDAO.IDSETOR;
                    setorSalvo.SETOR1 = setorDAO.SETOR1;
                }
                else
                {
                    setorSalvo = contexto.SETOR.Add(setorDAO);
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
using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeProfissional
    {
        #region Public Methods

        public static List<PROFISSIONAIS> buscarCargosPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.PROFISSIONAIS.Where(x => x.PROFISSIONAL.Contains(prefix) || x.IDPRF.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<PROFISSIONAIS>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarProfissional(string codigoDoProfissional)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.PROFISSIONAIS.Any(x => x.IDPRF == codigoDoProfissional))
                    contexto.PROFISSIONAIS.Remove(contexto.PROFISSIONAIS.First(x => x.IDPRF == codigoDoProfissional));

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

        public static PROFISSIONAIS recuperarProfissionalPorID(string idPro)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.PROFISSIONAIS.Any(x => x.IDPRF == idPro))
                    return contexto.PROFISSIONAIS.First(x => x.IDPRF == idPro);
                else
                    return null;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new PROFISSIONAIS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PROFISSIONAIS SalvarProfissional(PROFISSIONAIS profissionalDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            PROFISSIONAIS profissionalSalvo = new PROFISSIONAIS();

            try
            {
                if (contexto.PROFISSIONAIS.Any(x => x.IDPRF == profissionalDAO.IDPRF))
                {
                    profissionalSalvo = contexto.PROFISSIONAIS.First(x => x.IDPRF == profissionalDAO.IDPRF);

                    profissionalSalvo.PROFISSIONAL = profissionalDAO.PROFISSIONAL;
                    profissionalSalvo.STATUS = profissionalDAO.STATUS;
                }
                else
                {
                    profissionalSalvo = contexto.PROFISSIONAIS.Add(profissionalDAO);
                }

                contexto.SaveChanges();
                return profissionalSalvo;
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
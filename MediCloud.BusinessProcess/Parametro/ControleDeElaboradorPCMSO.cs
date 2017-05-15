using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeElaboradorPCMSO
    {
        public static List<EPCMSO> BuscarElaboradoresPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.EPCMSO.Where(x => x.ELABORADORPCMSO.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<EPCMSO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EPCMSO BuscarElaboradorPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            if (v == 0)
                return null;

            try
            {
                if (contexto.EPCMSO.Any(x => x.IDEPCMSO == v))
                    return contexto.EPCMSO.First(x => x.IDEPCMSO == v);
                else
                    return null;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new EPCMSO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarElaboradorPCMSO(int codigoElaboradorPCMSO)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.EPCMSO.Any(x => x.IDEPCMSO == codigoElaboradorPCMSO))
                    contexto.EPCMSO.Remove(contexto.EPCMSO.First(x => x.IDEPCMSO == codigoElaboradorPCMSO));

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

        public static EPCMSO SalvarElaboradorPCMSO(EPCMSO elaboradorPCMSODAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            EPCMSO setorSalvo = new EPCMSO();

            try
            {

                if (elaboradorPCMSODAO.IDEPCMSO > 0)
                {
                    setorSalvo = contexto.EPCMSO.First(x => x.IDEPCMSO == elaboradorPCMSODAO.IDEPCMSO);

                    setorSalvo.IDEPCMSO = elaboradorPCMSODAO.IDEPCMSO;
                    setorSalvo.ELABORADORPCMSO = elaboradorPCMSODAO.ELABORADORPCMSO;

                }
                else
                {
                    setorSalvo = contexto.EPCMSO.Add(elaboradorPCMSODAO);
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
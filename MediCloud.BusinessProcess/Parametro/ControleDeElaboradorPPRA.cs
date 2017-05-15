using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Util;
using System.Data.Entity.Validation;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeElaboradorPPRA
    {
        public static List<EPPRA> BuscarElaboradoresPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.EPPRA.Where(x => x.ELABORADORPPRA.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<EPPRA>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EPPRA BuscarElaboradorPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();

            if (v == 0)
                return null;
            try
            {
                return contexto.EPPRA.First(x => x.IDEPPRA == v);
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new EPPRA();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarElaboradorPPRA(int cosdigoElaboradorPPRA)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.EPPRA.Any(x => x.IDEPPRA == cosdigoElaboradorPPRA))
                    contexto.EPPRA.Remove(contexto.EPPRA.First(x => x.IDEPPRA == cosdigoElaboradorPPRA));

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

        public static EPPRA SalvarElaboradorPPRA(EPPRA elaboradorPPRADAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            EPPRA setorSalvo = new EPPRA();

            try
            {

                if (elaboradorPPRADAO.IDEPPRA > 0)
                {
                    setorSalvo = contexto.EPPRA.First(x => x.IDEPPRA == elaboradorPPRADAO.IDEPPRA);

                    setorSalvo.IDEPPRA = elaboradorPPRADAO.IDEPPRA;
                    setorSalvo.ELABORADORPPRA = elaboradorPPRADAO.ELABORADORPPRA;

                }
                else
                {
                    setorSalvo = contexto.EPPRA.Add(elaboradorPPRADAO);
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
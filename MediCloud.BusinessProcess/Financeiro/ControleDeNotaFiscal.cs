using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Financeiro
{
    public class ControleDeNotaFiscal
    {
        public static List<NOTAFISCAL> BuscarNotaFiscalPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.NOTAFISCAL.Where(x => x.RAZAOSOCIAL.Contains(prefix)
                                                   || x.DATAEMISSAO.ToString().Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<NOTAFISCAL>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static NOTAFISCAL RecuperarNotaFiscalPorID(int v)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.NOTAFISCAL.Any(x => x.IDNF == v))
                    return contexto.NOTAFISCAL.Where(x => x.IDNF == v).First();
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

        public static List<SLNOTAFISCAL> RecuperarDetalheDeNotaFiscal(int idNF)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.SLNOTAFISCAL.Where(x => x.IDNF == idNF).Distinct().ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<SLNOTAFISCAL>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<NOTAFISCAL> RecuperarNotasFiscaisDeFaturamento(decimal idFaturamento)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.NOTAFISCAL.Where(x => x.IDFAT == idFaturamento).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<NOTAFISCAL>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirNotaFiscal(int codigoDaNotaFiscal)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.NOTAFISCAL.Any(x => x.IDNF == codigoDaNotaFiscal))
                    contexto.NOTAFISCAL.Remove(contexto.NOTAFISCAL.First(x => x.IDNF == codigoDaNotaFiscal));

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

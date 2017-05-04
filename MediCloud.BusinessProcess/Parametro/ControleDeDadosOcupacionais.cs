using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeDadosOcupacionais
    {
        public static List<CLIENTE_OCUPACIONAL> BuscarDadosOcupacionaisPorTermo(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<CLIENTE_OCUPACIONAL> cargo = contexto.CLIENTE_OCUPACIONAL.Where(x => x.CLIENTE.NOMEFANTASIA.Contains(termo)
                                                                                       || (x.EPCMSO == null ? false : x.EPCMSO.ELABORADORPCMSO.Contains(termo))
                                                                                       || (x.IDEPPRA == null ? false : x.EPPRA.ELABORADORPPRA.Contains(termo))).ToList();

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

        public static void DeletarDadosOcupacionais(int codigoDoDadosOcupacionais)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_OCUPACIONAL.Any(x => x.IDCLI == codigoDoDadosOcupacionais))
                    contexto.CLIENTE_OCUPACIONAL.Remove(contexto.CLIENTE_OCUPACIONAL.First(x => x.IDCLI == codigoDoDadosOcupacionais));

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

        public static CLIENTE_OCUPACIONAL BuscarDadosOcupacionaisPorID(int codigoDoDadosOcupacionais)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_OCUPACIONAL.Any(x => x.IDCLI == codigoDoDadosOcupacionais))
                    return contexto.CLIENTE_OCUPACIONAL.First(x => x.IDCLI == codigoDoDadosOcupacionais);
                else
                    return null;
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
    }
}

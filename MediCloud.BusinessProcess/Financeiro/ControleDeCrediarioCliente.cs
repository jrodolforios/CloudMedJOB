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
    public class ControleDeCrediarioCliente
    {
        public static List<CLIENTE_CREDIARIO> RecuperarCrediariosDeGrupoDeClientes(int idGrupoDeClientes)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.CLIENTE_CREDIARIO.Where(x => x.IDCLIGRU == idGrupoDeClientes).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CLIENTE_CREDIARIO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BloquearCrediario(int codigoDoCrediario, bool bloquear)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.CLIENTE_CREDIARIO.Any(x => x.IDCRE == codigoDoCrediario))
                    contexto.CLIENTE_CREDIARIO.First(x => x.IDCRE == codigoDoCrediario).STATUS = bloquear ? "S" : "N";

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

        public static List<CLIENTE_CREDIARIO> RecuperarCrediarioClientePorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.CLIENTE_CREDIARIO.Where(x => x.CLIENTE.RAZAOSOCIAL.Contains(prefix)
                                                      || x.CLIENTE.NOMEFANTASIA.Contains(prefix)
                                                      || x.TABELA.TABELA1.Contains(prefix)
                                                      || x.MOVIMENTO_FECHAMENTO.PERIODO.Contains(prefix)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CLIENTE_CREDIARIO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

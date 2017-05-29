using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Parametro
{
    public class ControleDeTabelaPreco
    {
        public static TABELA buscarTabelaPorID(int idRef)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.TABELA.Any(x => x.IDTAB == idRef))
                    return contexto.TABELA.Where(x => x.IDTAB == idRef).First();
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

        public static List<TABELA> RecuperarTodos()
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.TABELA.ToList();
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

        public static List<TABELA> buscarTabelaPorTermo(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (!string.IsNullOrEmpty(termo))
                    return contexto.TABELA.Where(x => x.TABELA1.Contains(termo)).ToList();
                else
                    return RecuperarTodos();
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

        public static void DeletarTabelaDePreco(int codigoTabelaDePreco)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.TABELA.Any(x => x.IDTAB == codigoTabelaDePreco))
                    contexto.TABELA.Remove(contexto.TABELA.First(x => x.IDTAB == codigoTabelaDePreco));

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

        public static List<TABELAXFORNECEDORXPROCEDIMENTO> buscarTabelaFornecedorPorIDTabela(decimal idTab)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.TABELAXFORNECEDORXPROCEDIMENTO.Any(x => x.IDTAB == idTab))
                    return contexto.TABELAXFORNECEDORXPROCEDIMENTO.Where(x => x.IDTAB == idTab).ToList();
                else
                    return new List<TABELAXFORNECEDORXPROCEDIMENTO>();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<TABELAXFORNECEDORXPROCEDIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TABELA SalvarTabela(TABELA tabelaDePrecoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            TABELA setorSalvo = new TABELA();

            try
            {

                if (tabelaDePrecoDAO.IDTAB > 0)
                {
                    setorSalvo = contexto.TABELA.First(x => x.IDTAB == tabelaDePrecoDAO.IDTAB);

                    setorSalvo.STATUS = tabelaDePrecoDAO.STATUS;
                    setorSalvo.TABELA1 = tabelaDePrecoDAO.TABELA1;
                    setorSalvo.TIPOPAGTO = tabelaDePrecoDAO.TIPOPAGTO;

                }
                else
                {
                    setorSalvo = contexto.TABELA.Add(tabelaDePrecoDAO);
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

        public static List<TABELA> RecuperarTabelasDeCLiente(int idCliente)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (idCliente > 0)
                    return contexto.TABELA.Where(x => x.CLIENTE.Any(y => y.IDCLI == idCliente)).ToList();
                else
                    return new List<TABELA>();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<TABELA>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

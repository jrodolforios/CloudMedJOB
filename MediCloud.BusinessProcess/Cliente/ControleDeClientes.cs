using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using Phidelis.Criptografia.Criptors;

namespace MediCloud.BusinessProcess.Cliente
{
    public class ControleDeClientes
    {
        public static CLIENTE buscarCliente(int codigo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.CLIENTE.Where(x => x.IDCLI == codigo).First();
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

        public static List<CLIENTE> buscarCliente(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.CLIENTE.ToList();
                }
                else
                {
                    return contexto.CLIENTE.Where(x => x.NOMEFANTASIA.Contains(termo)
                        || x.RAZAOSOCIAL.Contains(termo)
                        || x.CPFCNPJ.Contains(termo)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CLIENTE>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirCliente(int codigoDoCliente)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.CLIENTE.Remove(contexto.CLIENTE.First(x => x.IDCLI == codigoDoCliente));

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

        public static CLIENTE SalvarCliente(CLIENTE clienteDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CLIENTE usuarioSalvo = new CLIENTE();
            MD5Criptor criptor = new MD5Criptor();

            try
            {

                if (clienteDAO.IDCLI > 0)
                {
                    usuarioSalvo = contexto.CLIENTE.First(x => x.IDCLI == clienteDAO.IDCLI);

                    usuarioSalvo.BAIRRO = clienteDAO.BAIRRO;
                    usuarioSalvo.CEP = clienteDAO.CEP;
                    usuarioSalvo.CIDADE = clienteDAO.CIDADE;
                    usuarioSalvo.CPFCNPJ = clienteDAO.CPFCNPJ;
                    usuarioSalvo.DATAATUALIZACAO = DateTime.Now;
                    usuarioSalvo.ENDERECO = clienteDAO.ENDERECO;
                    usuarioSalvo.IDCONT = clienteDAO.IDCONT;
                    usuarioSalvo.IDEPCMSO = clienteDAO.IDEPCMSO;
                    usuarioSalvo.IDEPPRA = clienteDAO.IDEPPRA;
                    usuarioSalvo.IDSEG = clienteDAO.IDSEG;
                    usuarioSalvo.NFUN = clienteDAO.NFUN;
                    usuarioSalvo.NOMEFANTASIA = clienteDAO.NOMEFANTASIA;
                    usuarioSalvo.OBSERVACOES = clienteDAO.OBSERVACOES;
                    usuarioSalvo.RAZAOSOCIAL = clienteDAO.RAZAOSOCIAL;
                    usuarioSalvo.TIPOCLIENTE = clienteDAO.TIPOCLIENTE;
                    usuarioSalvo.UF = clienteDAO.UF;

                }
                else
                {
                    usuarioSalvo = contexto.CLIENTE.Add(clienteDAO);
                }

                contexto.SaveChanges();
                return usuarioSalvo;

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

        public static CLIENTE_OUTRASEMP SalvarEmpresa(CLIENTE_OUTRASEMP empresaDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CLIENTE_OUTRASEMP usuarioSalvo = new CLIENTE_OUTRASEMP();

            try
            {

                if (empresaDAO.IDEMP > 0)
                {
                    usuarioSalvo = contexto.CLIENTE_OUTRASEMP.First(x => x.IDEMP == empresaDAO.IDEMP);

                    usuarioSalvo.EMAIL = empresaDAO.EMAIL;
                    usuarioSalvo.EMPRESA = empresaDAO.EMPRESA;
                    usuarioSalvo.IDCLI = empresaDAO.IDCLI;
                    usuarioSalvo.NOMERESP = empresaDAO.NOMERESP;
                    usuarioSalvo.TELEFONE = empresaDAO.TELEFONE;

                }
                else
                {
                    usuarioSalvo = contexto.CLIENTE_OUTRASEMP.Add(empresaDAO);
                }

                contexto.SaveChanges();
                return usuarioSalvo;

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

        public static void ExcluirEmpresa(int codigoDaEmpresa)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_OUTRASEMP.Any(x => x.IDEMP == codigoDaEmpresa))
                    contexto.CLIENTE_OUTRASEMP.Remove(contexto.CLIENTE_OUTRASEMP.First(x => x.IDEMP == codigoDaEmpresa));

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

        public static CLIENTE_OUTRASEMP BuscarEmpresa(int codigoDaEmpresa)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_OUTRASEMP.Any(x => x.IDEMP == codigoDaEmpresa))
                    return contexto.CLIENTE_OUTRASEMP.Where(x => x.IDEMP == codigoDaEmpresa).First();
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

        public static List<CLIENTE_OUTRASEMP> buscarEmpresasDeCliente(int idCliente)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (contexto.CLIENTE_OUTRASEMP.Any(x => x.IDCLI == idCliente))
                    return contexto.CLIENTE_OUTRASEMP.Where(x => x.IDCLI == idCliente).ToList();
                else
                    return new List<CLIENTE_OUTRASEMP>();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CLIENTE_OUTRASEMP>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AdicionarTabela(int codigoCliente, int codigoTabela)
        {
            CloudMedContext contexto = new CloudMedContext();
            CLIENTE cliente;
            try
            {
                if (contexto.CLIENTE.Any(x => x.IDCLI == codigoCliente))
                {
                    cliente = contexto.CLIENTE.First(x => x.IDCLI == codigoCliente);

                    if (!cliente.TABELA.Any(x => x.IDTAB == codigoTabela))
                        cliente.TABELA.Add(contexto.TABELA.First(x => x.IDTAB == codigoTabela));
                }

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

        public static void excluirTabelaDeCliente(int codigoCliente, int codigoTabela)
        {
            CloudMedContext contexto = new CloudMedContext();
            CLIENTE cliente;
            try
            {
                if (contexto.CLIENTE.Any(x => x.IDCLI == codigoCliente))
                {
                    cliente = contexto.CLIENTE.First(x => x.IDCLI == codigoCliente);

                    if (cliente.TABELA.Any(x => x.IDTAB == codigoTabela))
                        cliente.TABELA.Remove(contexto.TABELA.First(x => x.IDTAB == codigoTabela));
                }

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
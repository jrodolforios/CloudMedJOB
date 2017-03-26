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
    }
}
using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using Phidelis.Criptografia.Criptors;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Fornecedor
{
    public class ControleDeContato
    {
        #region Public Methods

        public static void ExcluirContato(int codigoDoContato)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.CLIENTE_CONTATO.Any(x => x.IDCON == codigoDoContato))
                    contexto.CLIENTE_CONTATO.Remove(contexto.CLIENTE_CONTATO.First(x => x.IDCON == codigoDoContato));

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

        public static void ExcluirContatoFornecedor(int codigoDoContatoFornecedor)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.FORNECEDOR_CONTATO.Any(x => x.IDCON == codigoDoContatoFornecedor))
                    contexto.FORNECEDOR_CONTATO.Remove(contexto.FORNECEDOR_CONTATO.First(x => x.IDCON == codigoDoContatoFornecedor));

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

        public static FORNECEDOR_CONTATO recuperarContatoFornecedorPorID(int codigoDoContatoFornecedor)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                if (contexto.FORNECEDOR_CONTATO.Any(x => x.IDCON == codigoDoContatoFornecedor))
                    return contexto.FORNECEDOR_CONTATO.Where(x => x.IDCON == codigoDoContatoFornecedor).First();
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

        public static CLIENTE_CONTATO recuperarContatoPorID(int codigoDoContato)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.CLIENTE_CONTATO.Where(x => x.IDCON == codigoDoContato).First();
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

        public static List<FORNECEDOR_CONTATO> recuperarContatosDeFornecedorPorIdFornecedor(int idFor)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.FORNECEDOR_CONTATO.Where(x => x.IDFOR == idFor).ToList();
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

        public static CLIENTE_CONTATO SalvarContato(CLIENTE_CONTATO contatoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CLIENTE_CONTATO usuarioSalvo = new CLIENTE_CONTATO();
            MD5Criptor criptor = new MD5Criptor();

            try
            {
                if (contatoDAO.IDCON > 0)
                {
                    usuarioSalvo = contexto.CLIENTE_CONTATO.First(x => x.IDCON == contatoDAO.IDCON);

                    usuarioSalvo.DEPARTAMENTO = contatoDAO.DEPARTAMENTO;
                    usuarioSalvo.EMAIL = contatoDAO.EMAIL;
                    usuarioSalvo.FONEFIXO = contatoDAO.FONEFIXO;
                    usuarioSalvo.FONEMOVEL = contatoDAO.FONEMOVEL;
                    usuarioSalvo.FUNCAO = contatoDAO.FUNCAO;
                    usuarioSalvo.IDCLI = contatoDAO.IDCLI;
                    usuarioSalvo.NASCIMENTO = contatoDAO.NASCIMENTO;
                    usuarioSalvo.NOME = contatoDAO.NOME;
                    usuarioSalvo.OBS = contatoDAO.OBS;
                }
                else
                {
                    usuarioSalvo = contexto.CLIENTE_CONTATO.Add(contatoDAO);
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

        public static FORNECEDOR_CONTATO SalvarContatoFornecedor(FORNECEDOR_CONTATO contatoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            FORNECEDOR_CONTATO usuarioSalvo = new FORNECEDOR_CONTATO();

            try
            {
                if (contatoDAO.IDCON > 0)
                {
                    usuarioSalvo = contexto.FORNECEDOR_CONTATO.First(x => x.IDCON == contatoDAO.IDCON);

                    usuarioSalvo.DEPARTAMENTO = contatoDAO.DEPARTAMENTO;
                    usuarioSalvo.EMAIL = contatoDAO.EMAIL;
                    usuarioSalvo.FONEFIXO = contatoDAO.FONEFIXO;
                    usuarioSalvo.FONEMOVEL = contatoDAO.FONEMOVEL;
                    usuarioSalvo.FUNCAO = contatoDAO.FUNCAO;
                    usuarioSalvo.IDFOR = contatoDAO.IDFOR;
                    usuarioSalvo.NASCIMENTO = contatoDAO.NASCIMENTO;
                    usuarioSalvo.NOME = contatoDAO.NOME;
                    usuarioSalvo.OBS = contatoDAO.OBS;
                }
                else
                {
                    usuarioSalvo = contexto.FORNECEDOR_CONTATO.Add(contatoDAO);
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

        #endregion Public Methods
    }
}
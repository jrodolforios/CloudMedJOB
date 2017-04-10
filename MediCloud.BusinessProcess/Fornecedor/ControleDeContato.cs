using MediCloud.BusinessProcess.Util;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using MediCloud.DatabaseModels;
using Phidelis.Criptografia.Criptors;

namespace MediCloud.BusinessProcess.Fornecedor
{
    public class ControleDeContato
    {
        public static void ExcluirContato(int codigoDoContato)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
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
                return contexto.FORNECEDOR_CONTATO.Where(x => x.IDCON == idFor).ToList();
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
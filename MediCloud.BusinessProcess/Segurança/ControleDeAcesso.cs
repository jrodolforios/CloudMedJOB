using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using Phidelis.Criptografia.Criptors;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Segurança
{
    public class ControleDeAcesso
    {
        #region Public Methods

        /// <summary>
        /// Realiza o bloqueio (ou não) do usuário
        /// </summary>
        /// <param name="codigoDoUsuario">Código do usuário a ser bloqueado</param>
        /// <param name="bloquear">Bloquear ou desbloquear o usuário</param>
        public static void BloquearUsuario(int codigoDoUsuario, bool bloquear)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                SYS_USUARIO usuario = contexto.SYS_USUARIO.First(x => x.CODUSU == codigoDoUsuario);
                usuario.BLOQUEARSESSAO = bloquear ? "S" : "N";

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

        /// <summary>
        /// Realiza a busca do usuário a partir do nome ou login
        /// </summary>
        /// <param name="termo">Termo para realizar a busca (parte do nome ou login)</param>
        /// <returns>Lista de usuários encontrados</returns>
        public static List<SYS_USUARIO> buscarUsuario(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                return contexto.SYS_USUARIO.Where(x => x.NOME.Contains(termo) || x.LOGIN.Contains(termo)).ToList();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<SYS_USUARIO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Realiza a busca de um único usuário a partir de seu código
        /// </summary>
        /// <param name="codigo">Código do usuário a ser encontrado</param>
        /// <returns>Usuário encontrado</returns>
        public static SYS_USUARIO buscarUsuario(int codigo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                return contexto.SYS_USUARIO.Where(x => x.CODUSU == codigo).First();
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

        /// <summary>
        /// Efetua login no CloudMed
        /// </summary>
        /// <param name="usuario">usuario cadastrado no sistema</param>
        /// <param name="senha">senha para login</param>
        /// <returns></returns>
        public static SYS_USUARIO EfetuarLogon(string usuario, string senha)
        {
            CloudMedContext context = new CloudMedContext();
            MD5Criptor criptor = new MD5Criptor();
            string senhaMD5;
            SYS_USUARIO usuarioEncontrado;

            try
            {
                IQueryable<SYS_USUARIO> usuariosEncontrado = context.SYS_USUARIO.Where(x => x.LOGIN.ToLower() == usuario.ToLower());

                if (usuariosEncontrado.Any())
                    usuarioEncontrado = usuariosEncontrado.First();
                else
                    return null;

                if (usuarioEncontrado.DATALTSENHA <= DateTime.Now)
                    BloquearUsuario((int)usuarioEncontrado.CODUSU, true);

                senhaMD5 = criptor.transform(senha);

                //Apenas para primeiro login quando a senha vai ser redefinida para o padrão CoudMed.
                if (usuarioEncontrado != null && string.IsNullOrEmpty(usuarioEncontrado.SENHA))
                {
                    usuarioEncontrado.SENHA = senhaMD5;
                }

                if (usuarioEncontrado.SENHA == senhaMD5 && usuarioEncontrado.BLOQUEARSESSAO == "N")
                {
                    usuarioEncontrado.DATALT = DateTime.Now;
                    context.SaveChanges();

                    return usuarioEncontrado;
                }
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

        /// <summary>
        /// Realiza a exclusão od usuário
        /// </summary>
        /// <param name="codigoDoUsuario">Código do usuário a ser excluído</param>
        public static void ExcluirUsuario(int codigoDoUsuario)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.SYS_USUARIO.Remove(contexto.SYS_USUARIO.First(x => x.CODUSU == codigoDoUsuario));

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

        /// <summary>
        /// Salva usuário realizando ou uma atualização ou uma inserção no banco de dados
        /// </summary>
        /// <param name="usuario">Usuário a ser salvo</param>
        /// <returns>Usuário salvo</returns>
        public static SYS_USUARIO SalvarUsuario(SYS_USUARIO usuario)
        {
            CloudMedContext contexto = new CloudMedContext();
            SYS_USUARIO usuarioSalvo = new SYS_USUARIO();
            MD5Criptor criptor = new MD5Criptor();

            try
            {
                //Ação necessária devido a uma exigência do Banco de dados que o sistema não utiliza mais.
                usuario.RELATSIMULTANEO = "N";

                if (usuario.CODUSU > 0)
                {
                    usuarioSalvo = contexto.SYS_USUARIO.First(x => x.CODUSU == usuario.CODUSU);

                    usuarioSalvo.NOME = usuario.NOME;
                    usuarioSalvo.LOGIN = usuario.LOGIN;
                    usuarioSalvo.BLOQUEARSESSAO = usuario.BLOQUEARSESSAO;
                    usuarioSalvo.DATALTSENHA = usuario.DATALTSENHA;
                    usuarioSalvo.RELATSIMULTANEO = usuario.RELATSIMULTANEO;

                    if (!string.IsNullOrEmpty(usuario.SENHA))
                        usuarioSalvo.SENHA = criptor.transform(usuario.SENHA);
                }
                else
                {
                    usuario.SENHA = criptor.transform(usuario.SENHA);

                    usuarioSalvo = contexto.SYS_USUARIO.Add(usuario);
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

        /// <summary>
        /// Realiza a troca de senha de um determinado usuário
        /// </summary>
        /// <param name="codigoDoUsuario">Código do usuário a ser trocada a senha</param>
        /// <param name="senhaAtual"></param>
        /// <param name="novaSenha"></param>
        public static void TrocarSenha(int codigoDoUsuario, string senhaAtual, string novaSenha)
        {
            CloudMedContext context = new CloudMedContext();
            SYS_USUARIO usuarioEncontrado;

            try
            {
                MD5Criptor criptor = new MD5Criptor();
                string senhaAtualMD5 = criptor.transform(senhaAtual);
                string novaSenhaMD5 = criptor.transform(novaSenha);

                IQueryable<SYS_USUARIO> usuariosEncontrado = context.SYS_USUARIO.Where(x => x.CODUSU == codigoDoUsuario);

                if (usuariosEncontrado.Any())
                    usuarioEncontrado = usuariosEncontrado.First();
                else
                    throw new ArgumentException("Usuário não encontrado, procure-nos para mais informações.");

                if (usuarioEncontrado.SENHA == senhaAtualMD5)
                {
                    usuarioEncontrado.SENHA = novaSenhaMD5;
                    context.SaveChanges();
                }
                else
                    throw new ArgumentException("Sua senha atual é inválida. Tente digitar a sua senha atual corretamente.");
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

        #endregion Public Methods
    }
}
using MediCloud.DatabaseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MediCloud.Persistence;
using Phidelis.Criptografia.Criptors;

namespace MediCloud.BusinessProcess.Segurança
{
    public class ControleDeAcesso
    {
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

            IQueryable<SYS_USUARIO> usuariosEncontrado = context.SYS_USUARIO.Where(x => x.LOGIN == usuario);

            if (usuariosEncontrado.Any())
                usuarioEncontrado = usuariosEncontrado.First();
            else
                return null;

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

        public static void TrocarSenha(int codigoDoUsuario, string senhaAtual, string novaSenha)
        {
            CloudMedContext context = new CloudMedContext();
            SYS_USUARIO usuarioEncontrado;
            MD5Criptor criptor = new MD5Criptor();
            string senhaAtualMD5 = criptor.transform(senhaAtual);
            string novaSenhaMD5 = criptor.transform(novaSenha);

            IQueryable<SYS_USUARIO> usuariosEncontrado = context.SYS_USUARIO.Where(x => x.CODUSU == codigoDoUsuario);

            if (usuariosEncontrado.Any())
                usuarioEncontrado = usuariosEncontrado.First();
            else
                throw new ArgumentException("Usuário não encontrado, procure-nos para mais informações.");

            if(usuarioEncontrado.SENHA == senhaAtualMD5)
            {
                usuarioEncontrado.SENHA = novaSenhaMD5;
                context.SaveChanges();
            }
            else
                throw new ArgumentException("Sua senha atual é inválida. Tente digitar a sua senha atual corretamente.");
        }
    }
}
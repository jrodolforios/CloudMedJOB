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
    }
}
using MediCloud.BusinessProcess.Segurança;
using MediCloud.DatabaseModels;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.View.Controllers;

namespace MediCloud.App_Code
{
    public class CadastroDeUsuarios
    {
        public static List<UsuarioModel> buscarUsuarios (FormCollection form)
        {
            string termo = form["keywords"];
            List<UsuarioModel> listaDeModels = new List<UsuarioModel>();

            List<SYS_USUARIO> usuarioDoBanco = ControleDeAcesso.buscarUsuario(termo);

            usuarioDoBanco.ForEach(x => 
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        private static UsuarioModel injetarEmUsuarioModel(SYS_USUARIO usuarioDoBanco)
        {
            return new UsuarioModel()
            {
                Codigo = Convert.ToInt32(usuarioDoBanco.CODUSU),
                loginUsuario = usuarioDoBanco.LOGIN,
                nomeUsuario = usuarioDoBanco.NOME,
                acessoBloqueado = usuarioDoBanco.BLOQUEARSESSAO == "S"                
            };
        }

        internal static void DeletarUsuario(BaseController controller, int codigoDoUsuario)
        {
            ControleDeAcesso.DeletarUsuario(codigoDoUsuario);
        }

        internal static void BloquearUsuario(AccountController accountController, int codigoDoUsuario, bool bloquear)
        {
            ControleDeAcesso.BloquearUsuario(codigoDoUsuario, bloquear);
        }
    }
}
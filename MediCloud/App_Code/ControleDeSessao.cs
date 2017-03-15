using MediCloud.BusinessProcess.Segurança;
using MediCloud.DatabaseModels;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.App_Code
{
    public class ControleDeSessao
    {
        public const string NOME_SESSAO_USUARIO = "UserSession";

        internal static void EstahLogado(Controller controlador)
        {
            if (controlador.Session[NOME_SESSAO_USUARIO] == null)
                controlador.Response.Redirect("Account");
        }

        internal static void Logar(FormCollection form, Controller controlador)
        {
            string usuario = form["usuario"];
            string senha = form["senha"];

            SYS_USUARIO usuarioLogado = ControleDeAcesso.EfetuarLogon(usuario, senha);

            if (usuarioLogado != null)
                PreecherSessaoDoUsuario(usuarioLogado, controlador);
            else
                throw new AccessViolationException("Usuário ou senha inválidos ou usuário bloqueado.");

        }

        private static void PreecherSessaoDoUsuario(SYS_USUARIO usuarioLogado, Controller controlador)
        {
            SessaoUsuarioModel sessaoUsuario = new SessaoUsuarioModel()
            {
                codigoDoUsuario = Convert.ToInt32(usuarioLogado.CODUSU),
                bloqueado = usuarioLogado.BLOQUEARSESSAO == "S",
                dataUltimaAteracaoSenha = usuarioLogado.DATALTSENHA,
                dataUltimoLogin = usuarioLogado.DATALT,
                login = usuarioLogado.LOGIN,
                NomeDoUsuario = usuarioLogado.NOME,
                senhaMD5 = usuarioLogado.SENHA,
                trocaSenhaNoProximoLogon = usuarioLogado.TROCARSENHA == "S"
            };

            controlador.Session[NOME_SESSAO_USUARIO] = sessaoUsuario;
        }
    }
}
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
        internal static void Logar(FormCollection form, Controller controlador)
        {
            string usuario = form["usuario"];
            string senha = form["senha"];

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
                throw new AccessViolationException("Os campos \"Usuario\" e \"Senha\" devem ser devidamente preenchidos.");

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

            controlador.Session[Constantes.NOME_SESSAO_USUARIO] = sessaoUsuario;
        }

        internal static void Deslogar(Controller controlador)
        {
            controlador.Session.Clear();
        }
    }
}
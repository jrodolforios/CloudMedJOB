using MediCloud.App_Code;
using MediCloud.BusinessProcess.Segurança;
using MediCloud.DatabaseModels;
using MediCloud.Models.Seguranca;
using System;
using System.Web.Mvc;

namespace MediCloud.Code
{
    public class ControleDeSessao
    {
        #region Internal Methods

        internal static void Deslogar(Controller controlador)
        {
            controlador.Session.Clear();
        }

        internal static void Logar(FormCollection form, BaseController controlador)
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

        internal static void TrocarASenha(BaseController controlador, string senhaAtual, string novaSenha, string repitaNovaSenha)
        {
            if (!string.IsNullOrEmpty(novaSenha) && !string.IsNullOrEmpty(senhaAtual) && !string.IsNullOrEmpty(repitaNovaSenha) && (novaSenha == repitaNovaSenha))
            {
                ControleDeAcesso.TrocarSenha(controlador.CurrentUser.codigoDoUsuario, senhaAtual, novaSenha);
            }
            else
            {
                throw new ArgumentException("PreenchaCorretamente todos os campos (os campos \"Nova senha\" e \"Repita a nova senha\" devem ser iguais)");
            }
        }

        #endregion Internal Methods



        #region Private Methods

        private static void PreecherSessaoDoUsuario(SYS_USUARIO usuarioLogado, BaseController controlador)
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

        #endregion Private Methods
    }
}
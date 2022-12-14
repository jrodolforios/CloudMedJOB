using MediCloud.App_Code;
using MediCloud.BusinessProcess.Segurança;
using MediCloud.DatabaseModels;
using MediCloud.Models.Seguranca;
using MediCloud.View.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code
{
    public class CadastroDeUsuarios
    {
        #region Public Methods

        public static List<UsuarioModel> buscarUsuarios(FormCollection form)
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

        #endregion Public Methods

        #region Internal Methods

        internal static void BloquearUsuario(AccountController accountController, int codigoDoUsuario, bool bloquear)
        {
            ControleDeAcesso.BloquearUsuario(codigoDoUsuario, bloquear);
        }

        internal static void DeletarUsuario(BaseController controller, int codigoDoUsuario)
        {
            ControleDeAcesso.ExcluirUsuario(codigoDoUsuario);
        }

        internal static UsuarioModel RecuperarUsuarioPorID(int? codigoUsuario)
        {
            if (codigoUsuario.HasValue && codigoUsuario != 0)
            {
                SYS_USUARIO usuarioencontrado = ControleDeAcesso.buscarUsuario(codigoUsuario.Value);
                return injetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        internal static UsuarioModel SalvarUsuario(FormCollection form)
        {
            UsuarioModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            SYS_USUARIO usuarioDAO = injetarEmUsuarioDAO(usuarioModel);
            usuarioDAO = ControleDeAcesso.SalvarUsuario(usuarioDAO);

            usuarioModel = injetarEmUsuarioModel(usuarioDAO);

            return usuarioModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static SYS_USUARIO injetarEmUsuarioDAO(UsuarioModel usuarioModel)
        {
            return new SYS_USUARIO()
            {
                CODUSU = usuarioModel.Codigo,
                LOGIN = usuarioModel.LoginUsuario,
                NOME = usuarioModel.NomeUsuario,
                BLOQUEARSESSAO = usuarioModel.AcessoBloqueado ? "S" : "N",
                DATALTSENHA = usuarioModel.DataParaBloqueio,
                SENHA = usuarioModel.SenhaDescriptografada
            };
        }

        private static UsuarioModel injetarEmUsuarioModel(SYS_USUARIO usuarioDoBanco)
        {
            return new UsuarioModel()
            {
                Codigo = Convert.ToInt32(usuarioDoBanco.CODUSU),
                LoginUsuario = usuarioDoBanco.LOGIN,
                NomeUsuario = usuarioDoBanco.NOME,
                AcessoBloqueado = usuarioDoBanco.BLOQUEARSESSAO == "S",
                DataParaBloqueio = usuarioDoBanco.DATALTSENHA,
                SenhaCriptografada = usuarioDoBanco.SENHA,
                RepetirSenhaDescriptografada = usuarioDoBanco.SENHA
            };
        }

        private static UsuarioModel injetarEmUsuarioModel(FormCollection form)
        {
            return new UsuarioModel()
            {
                Codigo = string.IsNullOrEmpty(form["codigoUsuario"]) ? 0 : Convert.ToInt32(form["codigoUsuario"]),
                LoginUsuario = string.IsNullOrEmpty(form["login"]) ? string.Empty : form["login"],
                NomeUsuario = string.IsNullOrEmpty(form["nomeCompleto"]) ? string.Empty : form["nomeCompleto"],
                AcessoBloqueado = string.IsNullOrEmpty(form["bloqueado"]) ? false : Convert.ToBoolean(form["bloqueado"].ToLower() == "on"),
                DataParaBloqueio = string.IsNullOrEmpty(form["BloquearEm"]) ? null : (DateTime?)Convert.ToDateTime(form["BloquearEm"]),
                SenhaDescriptografada = string.IsNullOrEmpty(form["senha"]) ? string.Empty : form["senha"],
                RepetirSenhaDescriptografada = string.IsNullOrEmpty(form["RepetirSenha"]) ? string.Empty : form["RepetirSenha"]
            };
        }

        #endregion Private Methods
    }
}
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeContador
    {
        #region Public Methods

        public static ContadorModel InjetarEmUsuarioModel(CONTADOR usuarioDoBanco)
        {
            if (usuarioDoBanco == null)
                return null;
            else
                return new ContadorModel()
                {
                    IdContador = (int)usuarioDoBanco.IDCONT,
                    NomeContador = usuarioDoBanco.CONTADOR1
                };
        }

        #endregion Public Methods

        #region Internal Methods

        internal static void DeletarContador(ContadorController contadorController, int codigoContador)
        {
            ControleDeContador.DeletarContador(codigoContador);
        }

        internal static ContadorModel RecuperarContadorPorID(int v)
        {
            if (v != 0)
            {
                CONTADOR referenteEncontrado = ControleDeContador.buscarContadorPorID(v);
                return InjetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        internal static List<ContadorModel> RecuperarContadorPorTermo(string prefix)
        {
            List<CONTADOR> contadoresEncontrados = ControleDeContador.BuscarContadoresPorTermo(prefix);
            List<ContadorModel> resultados = new List<ContadorModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static List<ContadorModel> RecuperarContadorPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            return RecuperarContadorPorTermo(prefix);
        }

        internal static ContadorModel SalvarContador(FormCollection form)
        {
            ContadorModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            CONTADOR cargoDAO = InjetarEmUsuarioDAO(usuarioModel);
            cargoDAO = ControleDeContador.SalvarContador(cargoDAO);

            usuarioModel = InjetarEmUsuarioModel(cargoDAO);

            return usuarioModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static CONTADOR InjetarEmUsuarioDAO(ContadorModel x)
        {
            if (x == null)
                return null;
            else
                return new CONTADOR()
                {
                    CONTADOR1 = x.NomeContador,
                    IDCONT = x.IdContador
                };
        }

        private static ContadorModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new ContadorModel()
            {
                IdContador = string.IsNullOrEmpty(form["codigoContador"]) ? 0 : Convert.ToInt32(form["codigoContador"]),
                NomeContador = string.IsNullOrEmpty(form["nomeContador"]) ? null : form["nomeContador"]
            };
        }

        #endregion Private Methods
    }
}
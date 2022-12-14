using MediCloud.BusinessProcess.Financeiro;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeRotaDeEntrega
    {
        #region Internal Methods

        internal static void DeletarRotaDeEntrega(RotaDeEntregaController rotaDeEntregaController, int codigoRotaDeEntrega)
        {
            ControleDeRotaDeEntrega.DeletarRotaDeEntrega(codigoRotaDeEntrega);
        }

        internal static RotaDeEntregaModel RecuperarRotaDeEntregaPorID(int v)
        {
            if (v != 0)
            {
                ROTA referenteEncontrado = ControleDeRotaDeEntrega.buscarRotaDeEntregaPorID(v);
                return InjetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        internal static List<RotaDeEntregaModel> RecuperarRotaDeEntregaPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            return RecuperarRotaDeEntregaPorTermo(prefix);
        }

        internal static List<RotaDeEntregaModel> RecuperarRotaDeEntregaPorTermo(string prefix)
        {
            List<ROTA> contadoresEncontrados = ControleDeRotaDeEntrega.BuscarContadoresPorTermo(prefix);
            List<RotaDeEntregaModel> resultados = new List<RotaDeEntregaModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static RotaDeEntregaModel SalvarRotaDeEntrega(FormCollection form)
        {
            RotaDeEntregaModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            ROTA cargoDAO = InjetarEmUsuarioDAO(usuarioModel);
            cargoDAO = ControleDeRotaDeEntrega.SalvarRotaDeEntrega(cargoDAO);

            usuarioModel = InjetarEmUsuarioModel(cargoDAO);

            return usuarioModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static ROTA InjetarEmUsuarioDAO(RotaDeEntregaModel x)
        {
            if (x == null)
                return null;
            else
                return new ROTA()
                {
                    IDROTA = x.IdRotaDeEntrega,
                    OBSERVACAO = x.Observacao,
                    NOMEROTA = x.NomeRotaDeEntrega
                };
        }

        private static RotaDeEntregaModel InjetarEmUsuarioModel(ROTA x)
        {
            if (x == null)
                return null;
            else
                return new RotaDeEntregaModel()
                {
                    IdRotaDeEntrega = (int)x.IDROTA,
                    NomeRotaDeEntrega = x.NOMEROTA,
                    Observacao = x.OBSERVACAO
                };
        }

        private static RotaDeEntregaModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new RotaDeEntregaModel()
            {
                IdRotaDeEntrega = string.IsNullOrEmpty(form["codigoRotaDeEntrega"]) ? 0 : Convert.ToInt32(form["codigoRotaDeEntrega"]),
                NomeRotaDeEntrega = string.IsNullOrEmpty(form["nomeRotaDeEntrega"]) ? null : form["nomeRotaDeEntrega"],
                Observacao = string.IsNullOrEmpty(form["observacoes"]) ? null : form["observacoes"],
            };
        }

        #endregion Private Methods
    }
}
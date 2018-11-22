using MediCloud.BusinessProcess.Cliente;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Clientes
{
    public class CadastroDeCargo
    {
        #region Public Methods

        public static CARGO injetarEmCargoModelDAO(CargoModel usuarioModel)
        {
            if (usuarioModel == null)
                return null;
            else
                return new CARGO()
                {
                    ABREVIADO = usuarioModel.Abreviatura,
                    CARGO1 = usuarioModel.NomeCargo,
                    CODNEXO = usuarioModel.CodigoNexo,
                    IDCGO = usuarioModel.IdCargo,
                    STATUS = usuarioModel.Ativo ? "A" : "I"
                };
        }

        #endregion Public Methods

        #region Internal Methods

        internal static List<CargoModel> buscarCargo(FormCollection form)
        {
            string termo = form["keywords"];
            List<CargoModel> listaDeModels = new List<CargoModel>();

            List<CARGO> usuarioDoBanco = ControleDeCargo.buscarCliente(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static void DeletarCargo(CargoController cargoController, int codigoDoCargo)
        {
            ControleDeCargo.ExcluirCargo(codigoDoCargo);
        }

        internal static CargoModel injetarEmUsuarioModel(CARGO x)
        {
            if (x == null)
                return null;
            else
                return new CargoModel()
                {
                    Abreviatura = x.ABREVIADO,
                    Ativo = x.STATUS == "A",
                    CodigoNexo = x.CODNEXO,
                    IdCargo = (int)x.IDCGO,
                    NomeCargo = x.CARGO1
                };
        }

        internal static CargoModel RecuperarCargoPorID(int codigoCargo)
        {
            if (codigoCargo != 0)
            {
                CARGO cargoEncontrado = ControleDeCargo.buscarCargoPorID(codigoCargo);
                return injetarEmUsuarioModel(cargoEncontrado);
            }
            else
                return null;
        }

        internal static List<CargoModel> RecuperarCargoPorTermo(string prefix)
        {
            List<CARGO> contadoresEncontrados = ControleDeCargo.buscarCargosPorTermo(prefix);
            List<CargoModel> resultados = new List<CargoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static CargoModel SalvarCargo(FormCollection form)
        {
            CargoModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            CARGO cargoDAO = injetarEmCargoModelDAO(usuarioModel);
            cargoDAO = ControleDeCargo.SalvarCargo(cargoDAO);

            usuarioModel = injetarEmUsuarioModel(cargoDAO);

            return usuarioModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static CargoModel injetarEmUsuarioModel(FormCollection form)
        {
            return new CargoModel()
            {
                Abreviatura = string.IsNullOrEmpty(form["abreviatura"]) ? string.Empty : form["abreviatura"],
                Ativo = string.IsNullOrEmpty(form["inativo"]) ? true : Convert.ToBoolean(!(form["inativo"].ToLower() == "on")),
                CodigoNexo = string.IsNullOrEmpty(form["codigoNexo"]) ? string.Empty : form["codigoNexo"],
                IdCargo = string.IsNullOrEmpty(form["codigoCargo"]) ? 0 : Convert.ToInt32(form["codigoCargo"]),
                NomeCargo = string.IsNullOrEmpty(form["nomeCargo"]) ? string.Empty : form["nomeCargo"]
            };
        }

        #endregion Private Methods
    }
}
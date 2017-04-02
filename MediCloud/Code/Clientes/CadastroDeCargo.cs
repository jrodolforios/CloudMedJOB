using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Cliente;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Cliente;
using MediCloud.Controllers;

namespace MediCloud.Code.Clientes
{
    public class CadastroDeCargo
    {
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

        internal static void DeletarCargo(CargoController cargoController, int codigoDoCargo)
        {
            ControleDeCargo.ExcluirCargo(codigoDoCargo);
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

        internal static CargoModel SalvarCargo(FormCollection form)
        {
            CargoModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            CARGO cargoDAO = injetarEmCargoModelDAO(usuarioModel);
            cargoDAO = ControleDeCargo.SalvarCargo(cargoDAO);

            usuarioModel = injetarEmUsuarioModel(cargoDAO);

            return usuarioModel;
        }

        private static CARGO injetarEmCargoModelDAO(CargoModel usuarioModel)
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Funcionario;
using MediCloud.DatabaseModels;
using MediCloud.Code.Clientes;
using MediCloud.BusinessProcess.Funcionario;
using MediCloud.Controllers;
using MediCloud.Models.Seguranca;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.Code.Funcionario
{
    public class CadastroDeFuncionario
    {
        internal static List<FuncionarioModel> BuscarFuncionarios(FormCollection form)
        {
            string termo = form["keywords"];
            return RecuperarFuncionarioPorTermo(termo);
        }

        internal static List<FuncionarioModel> RecuperarFuncionarioPorTermo(string prefix)
        {
            List<FuncionarioModel> listaDeModels = new List<FuncionarioModel>();

            List<FUNCIONARIO> usuarioDoBanco = ControleDeFuncionario.buscarFuncionario(prefix);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }


        public static FuncionarioModel injetarEmUsuarioModel(FUNCIONARIO x)
        {
            if (x == null)
                return null;
            else
                return new FuncionarioModel()
                {
                    CodigoNexo = x.CODNEXO,
                    CTPS = x.CTPS,
                    DataNascimento = x.NASCIMENTO,
                    Empresa = CadastroDeClientes.RecuperarClientePorID((int)x.IDCLI),
                    Endereco = x.ENDERECO,
                    IdFuncionario = (int)x.IDFUN,
                    Inativo = x.INATIVO,
                    Matricula = x.MATRICULA,
                    NomeCompleto = x.FUNCIONARIO1,
                    RG = x.RG,
                    TelFixo = x.TELEFONE,
                    TelMovel = x.CELULAR,
                    UltimoMovimento = x.DATAULTIMOMOV
                };
        }

        public static FUNCIONARIO injetarEmUsuarioModelDAO(FuncionarioModel x)
        {
            if (x == null)
                return null;
            else
                return new FUNCIONARIO()
                {
                    CELULAR = x.TelMovel,
                    CODNEXO = x.CodigoNexo,
                    CTPS = x.CTPS,
                    DATAULTIMOMOV = x.UltimoMovimento,
                    ENDERECO = x.Endereco,
                    FUNCIONARIO1 = x.NomeCompleto,
                    IDCLI = x.Empresa.IdCliente,
                    IDFUN = x.IdFuncionario,
                    INATIVO = x.Inativo,
                    MATRICULA = x.Matricula,
                    NASCIMENTO = x.DataNascimento,
                    RG = x.RG,
                    TELEFONE = x.TelFixo
                };
        }

        internal static void InativarFuncionario(FuncionarioController funcionarioController, int codigoDoFuncionario, bool inativar)
        {
            ControleDeFuncionario.InativarFuncionario(codigoDoFuncionario, inativar);
        }

        internal static void DeletarFuncionario(FuncionarioController funcionarioController, int codigoDoFuncionario)
        {
            ControleDeFuncionario.ExcluirFuncionario(codigoDoFuncionario);
        }

        internal static FuncionarioModel RecuperarFuncionarioPorID(int codigoFuncionario)
        {
            if (codigoFuncionario != 0)
            {
                FUNCIONARIO usuarioencontrado = ControleDeFuncionario.buscarFuncionarioPorID(codigoFuncionario);
                return injetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        internal static FuncionarioModel SalvarFuncionario(FormCollection form)
        {
            FuncionarioModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            FUNCIONARIO usuarioDAO = injetarEmUsuarioModelDAO(usuarioModel);
            usuarioDAO = ControleDeFuncionario.SalvarFuncionario(usuarioDAO);

            usuarioModel = injetarEmUsuarioModel(usuarioDAO);

            return usuarioModel;
        }

        private static FuncionarioModel injetarEmUsuarioModel(FormCollection form)
        {
            return new FuncionarioModel()
            {
                CodigoNexo = string.IsNullOrEmpty(form["codigoNexo"]) ? string.Empty : form["codigoNexo"],
                CTPS = string.IsNullOrEmpty(form["CTPS"]) ? string.Empty : form["CTPS"],
                DataNascimento = string.IsNullOrEmpty(form["dataNascimento"]) ? null : (DateTime?)Convert.ToDateTime(form["dataNascimento"]),
                Empresa = CadastroDeClientes.RecuperarClientePorID(string.IsNullOrEmpty(form["idEmpresa"]) ? 0 : Convert.ToInt32(form["idEmpresa"])),
                Endereco = string.IsNullOrEmpty(form["endereco"]) ? string.Empty : form["endereco"],
                IdFuncionario = string.IsNullOrEmpty(form["codigoFuncionario"]) ? 0 : Convert.ToInt32(form["codigoFuncionario"]),
                Inativo = string.IsNullOrEmpty(form["inativo"]) ? false : Convert.ToBoolean(form["inativo"].ToLower() == "on"),
                Matricula = string.IsNullOrEmpty(form["matricula"]) ? string.Empty : form["matricula"],
                NomeCompleto = string.IsNullOrEmpty(form["nomeCompleto"]) ? string.Empty : form["nomeCompleto"],
                RG = string.IsNullOrEmpty(form["RG"]) ? string.Empty : form["RG"],
                TelFixo = Util.ApenasNumeros(string.IsNullOrEmpty(form["telFixo"]) ? string.Empty : form["telFixo"]),
                TelMovel = Util.ApenasNumeros(string.IsNullOrEmpty(form["telMovel"]) ? string.Empty : form["telMovel"])
            };
        }

        internal static List<FuncionarioModel> RecuperarContadorPorTermoECliente(string prefix, int idCliente)
        {
            List<FUNCIONARIO> contadoresEncontrados = ControleDeFuncionario.buscarFuncionariosDeClientePorTermo(prefix, idCliente);
            List<FuncionarioModel> resultados = new List<FuncionarioModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }
    }
}
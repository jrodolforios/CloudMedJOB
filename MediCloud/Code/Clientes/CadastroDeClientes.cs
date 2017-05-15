using MediCloud.BusinessProcess;
using MediCloud.DatabaseModels;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Cliente;
using MediCloud.BusinessProcess.Cliente;
using MediCloud.Code.Fornecedor;
using MediCloud.Code.Parametro;
using MediCloud.Code.Enum;
using MediCloud.Controllers;
using MediCloud.Code.Financeiro;
using MediCloud.BusinessProcess.Util;
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.BusinessProcess.Parametro;

namespace MediCloud.Code.Clientes
{
    public class CadastroDeClientes
    {
        internal static List<ClienteModel> buscarClientes(FormCollection form)
        {
            string termo = form["keywords"];
            List<ClienteModel> listaDeModels = new List<ClienteModel>();

            List<CLIENTE> usuarioDoBanco = ControleDeClientes.buscarCliente(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        private static ClienteModel injetarEmUsuarioModel(FormCollection form)
        {
            return new ClienteModel()
            {
                Bairro = string.IsNullOrEmpty(form["bairro"]) ? string.Empty : form["bairro"],
                CEP = string.IsNullOrEmpty(form["CEP"]) ? string.Empty : form["CEP"],
                Cidade = string.IsNullOrEmpty(form["cidade"]) ? string.Empty : form["cidade"],
                CNPJ = string.IsNullOrEmpty(form["CNPJ"]) ? string.Empty : form["CNPJ"],
                Contador = CadastroDeContador.injetarEmUsuarioModel(ControleDeContador.BuscarContadorPorID(string.IsNullOrEmpty(form["idContador"]) ? 0 : Convert.ToInt32(form["idContador"]))),
                ElaboradorDoPCMSO = CadastroDeElaboradorPCMSO.InjetarEmUsuarioModel(ControleDeElaboradorPCMSO.BuscarElaboradorPorID(string.IsNullOrEmpty(form["idElaboradorPCMSO"]) ? 0 : Convert.ToInt32(form["idElaboradorPCMSO"]))),
                ElaboradorDoPPRA = CadastroDeElaboradorPPRA.InjetarEmUsuarioModel(ControleDeElaboradorPPRA.BuscarElaboradorPorID(string.IsNullOrEmpty(form["idElaboradorPPRA"]) ? 0 : Convert.ToInt32(form["idElaboradorPPRA"]))),
                EnderecoCompleto = string.IsNullOrEmpty(form["endereco"]) ? string.Empty : form["endereco"],
                IdCliente = string.IsNullOrEmpty(form["codigoCliente"]) ? 0 : Convert.ToInt32(form["codigoCliente"]),
                NomeFantasia = string.IsNullOrEmpty(form["nomeFantasia"]) ? string.Empty : form["nomeFantasia"],
                NumeroDeFuncionarios = string.IsNullOrEmpty(form["numeroFuncionarios"]) ? 0 : Convert.ToInt32(form["numeroFuncionarios"]),
                Observacoes = string.IsNullOrEmpty(form["observacoes"]) ? string.Empty : form["observacoes"],
                RazaoSocial = string.IsNullOrEmpty(form["razaoSocial"]) ? string.Empty : form["razaoSocial"],
                Segmento = CadastroDeSegmento.InjetarEmUsuarioModel(ControleDeSegmento.BuscarSegmentoPorID(string.IsNullOrEmpty(form["idSegmento"]) ? 0 : Convert.ToInt32(form["idSegmento"]))),
                TipoEmpresa = recuperarTipoEmpresaDoForm(form["tipoEmpresa"]),
                UF = string.IsNullOrEmpty(form["UF"]) ? string.Empty : form["UF"]
            };
        }

        private static EnumCliente.tipoEmpresa recuperarTipoEmpresaDoForm(string v)
        {
            switch (v)
            {
                case "PessoaFisica":
                    return EnumCliente.tipoEmpresa.PessoaFisica;
                case "PessoaJuridica":
                    return EnumCliente.tipoEmpresa.PessoaJuridica;
                case "CEI":
                    return EnumCliente.tipoEmpresa.CEI;
                default:
                    return EnumCliente.tipoEmpresa.Vazio;
            }
        }

        internal static ClienteModel injetarEmUsuarioModel(CLIENTE x)
        {
            return new ClienteModel()
            {
                IdCliente = (int)x.IDCLI,
                Bairro = x.BAIRRO,
                CEP = x.CEP,
                Cidade = x.CIDADE,
                CNPJ = x.CPFCNPJ,
                Contador = CadastroDeContador.injetarEmUsuarioModel(x.CONTADOR),
                Contatos = CadastroDeContato.injetarEmUsuarioModel(x.CLIENTE_CONTATO.ToList()),
                ElaboradorDoPCMSO = CadastroDeElaboradorPCMSO.InjetarEmUsuarioModel(x.EPCMSO),
                ElaboradorDoPPRA = CadastroDeElaboradorPPRA.InjetarEmUsuarioModel(x.EPPRA),
                EnderecoCompleto = x.ENDERECO,
                NomeFantasia = x.NOMEFANTASIA,
                NumeroDeFuncionarios = x.NFUN,
                RazaoSocial = x.RAZAOSOCIAL,
                Segmento = CadastroDeSegmento.InjetarEmUsuarioModel(x.SEGMENTO),
                TipoEmpresa = getTipoCliente(x.TIPOCLIENTE),
                UF = x.UF,
                Observacoes = x.OBSERVACOES
            };
        }

        public static CLIENTE injetarEmUsuarioDAO(ClienteModel x)
        {
            return new CLIENTE()
            {
                BAIRRO = x.Bairro,
                CEP = Util.ApenasNumeros(x.CEP),
                CIDADE = x.Cidade,
                CPFCNPJ = x.CNPJ,
                ENDERECO = x.EnderecoCompleto,
                IDCLI = x.IdCliente,
                IDCONT = x.Contador?.IdContador,
                IDEPCMSO = x.ElaboradorDoPCMSO?.IdElaboradorPCMSO,
                IDEPPRA = x.ElaboradorDoPPRA?.IdElaboradorPPRA,
                IDSEG = x.Segmento?.IdSegmento,
                NOMEFANTASIA = x.NomeFantasia,
                OBSERVACOES = x.Observacoes,
                RAZAOSOCIAL = x.RazaoSocial,
                TIPOCLIENTE = getTipoClienteBanco(x.TipoEmpresa),
                UF = x.UF,
                NFUN = x.NumeroDeFuncionarios
            };
        }

        internal static List<ClienteModel> RecuperarContadorPorTermo(string prefix)
        {
            List<CLIENTE> contadoresEncontrados = ControleDeClientes.buscarCliente(prefix);
            List<ClienteModel> resultados = new List<ClienteModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        private static string getTipoClienteBanco(EnumCliente.tipoEmpresa tipoEmpresa)
        {
            switch (tipoEmpresa)
            {
                case EnumCliente.tipoEmpresa.PessoaFisica:
                    return "F";
                case EnumCliente.tipoEmpresa.PessoaJuridica:
                    return "J";
                case EnumCliente.tipoEmpresa.CEI:
                    return "E";
                default:
                    return null;
            }
        }

        internal static void DeletarCliente(ClienteController clienteController, int codigoDoUsuario)
        {
                ControleDeClientes.ExcluirCliente(codigoDoUsuario);
        }

        private static EnumCliente.tipoEmpresa getTipoCliente(string tIPOCLIENTE)
        {
            switch (tIPOCLIENTE)
            {
                case "F":
                    return EnumCliente.tipoEmpresa.PessoaFisica;
                case "J":
                    return EnumCliente.tipoEmpresa.PessoaJuridica;
                case "E":
                    return EnumCliente.tipoEmpresa.CEI;
                default:
                    return EnumCliente.tipoEmpresa.Vazio;
            }
        }

        internal static ClienteModel RecuperarClientePorID(int? codigoCliente)
        {
            if (codigoCliente.HasValue && codigoCliente != 0)
            {
                CLIENTE usuarioencontrado = ControleDeClientes.buscarCliente(codigoCliente.Value);
                return injetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        internal static ClienteModel SalvarCliente(FormCollection form)
        {
            ClienteModel clienteModel = injetarEmUsuarioModel(form);
            clienteModel.validar();

            CLIENTE clienteDAO = injetarEmUsuarioDAO(clienteModel);
            clienteDAO = ControleDeClientes.SalvarCliente(clienteDAO);

            clienteModel = injetarEmUsuarioModel(clienteDAO);

            return clienteModel;
        }
    }
}
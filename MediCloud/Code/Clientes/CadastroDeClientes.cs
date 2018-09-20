using MediCloud.BusinessProcess.Cliente;
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.BusinessProcess.Parametro;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code.Enum;
using MediCloud.Code.Financeiro;
using MediCloud.Code.Fornecedor;
using MediCloud.Code.Parametro;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediCloud.Code.Clientes
{
    public class CadastroDeClientes
    {
        #region Public Methods

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

        #endregion Public Methods

        #region Internal Methods

        internal static void AdicionarTabela(int codigoCliente, int codigoTabela)
        {
            ControleDeClientes.AdicionarTabela(codigoCliente, codigoTabela);
        }

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

        internal static List<ClienteModel> buscarClientesDoMes()
        {
            List<ClienteModel> listaDeModels = new List<ClienteModel>();

            List<CLIENTE> usuarioDoBanco = ControleDeClientes.buscarClienteDoMes();

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static List<ClienteModel> buscarClientesDoMesAnterior()
        {
            List<ClienteModel> listaDeModels = new List<ClienteModel>();

            List<CLIENTE> usuarioDoBanco = ControleDeClientes.buscarClienteDoMesAnterior();

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static void DeletarCliente(ClienteController clienteController, int codigoDoUsuario)
        {
            ControleDeClientes.ExcluirCliente(codigoDoUsuario);
        }

        internal static void DeletarEmpresa(ClienteController clienteController, int codigoDaEmpresa)
        {
            ControleDeClientes.ExcluirEmpresa(codigoDaEmpresa);
        }

        internal static void DeletarTabelaDeCliente(int codigoCliente, int codigoTabela)
        {
            ControleDeClientes.excluirTabelaDeCliente(codigoCliente, codigoTabela);
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
                Contador = CadastroDeContador.InjetarEmUsuarioModel(x.CONTADOR),

                Contatos = CadastroDeContato.injetarEmUsuarioModel(x.CLIENTE_CONTATO.ToList()),
                Empresas = BuscarEmpresasDeCliente((int)x.IDCLI),
                Tabelas = CadastroDeTabelaDePreco.BuscarTabelasDeCliente((int)x.IDCLI),

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

        internal static ClienteModel RecuperarClientePorID(int? codigoCliente, bool carregarClasses = true)
        {
            if (codigoCliente.HasValue && codigoCliente != 0)
            {
                CLIENTE usuarioencontrado = ControleDeClientes.buscarCliente(codigoCliente.Value);
                if (carregarClasses)
                    return injetarEmUsuarioModel(usuarioencontrado);
                else
                    return injetarEmUsuarioModelAJAX(usuarioencontrado);
            }
            else
                return null;
        }

        internal static List<ClienteModel> RecuperarClientePorTermo(string prefix)
        {
            List<CLIENTE> contadoresEncontrados = ControleDeClientes.buscarCliente(prefix);
            List<ClienteModel> resultados = new List<ClienteModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static List<ClienteModel> RecuperarClientePorTermoAJAX(string prefix)
        {
            List<CLIENTE> contadoresEncontrados = ControleDeClientes.buscarCliente(prefix);
            List<ClienteModel> resultados = new List<ClienteModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModelAJAX(x));
            });

            return resultados;
        }

        internal static EmpresaModel RecuperarEmpresaPorID(int codigoDaEmpresa)
        {
            if (codigoDaEmpresa != 0)
            {
                CLIENTE_OUTRASEMP usuarioencontrado = ControleDeClientes.BuscarEmpresa(codigoDaEmpresa);
                return InjetarEmUsuarioModel(usuarioencontrado);
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

        internal static EmpresaModel SalvarEmpresa(FormCollection form)
        {
            EmpresaModel empresaModel = InjetarEmUsuarioModel(form);
            empresaModel.validar();

            CLIENTE_OUTRASEMP empresaDAO = InjetarEmUsuarioDAO(empresaModel);
            empresaDAO = ControleDeClientes.SalvarEmpresa(empresaDAO);

            empresaModel = InjetarEmUsuarioModel(empresaDAO);

            return empresaModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static List<EmpresaModel> BuscarEmpresasDeCliente(int idCliente)
        {
            List<EmpresaModel> listaDeModels = new List<EmpresaModel>();

            List<CLIENTE_OUTRASEMP> usuarioDoBanco = ControleDeClientes.buscarEmpresasDeCliente(idCliente);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmUsuarioModel(x));
            });

            return listaDeModels;
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

        private static CLIENTE_OUTRASEMP InjetarEmUsuarioDAO(EmpresaModel x)
        {
            if (x == null)
                return null;
            else
                return new CLIENTE_OUTRASEMP()
                {
                    IDCLI = x.Cliente.IdCliente,
                    EMAIL = x.Email,
                    EMPRESA = x.NomeEmpresa,
                    IDEMP = x.IdEmpresa,
                    NOMERESP = x.NomeResponsavel,
                    TELEFONE = x.Telefone
                };
        }

        private static ClienteModel injetarEmUsuarioModel(FormCollection form)
        {
            return new ClienteModel()
            {
                Bairro = string.IsNullOrEmpty(form["bairro"]) ? string.Empty : form["bairro"],
                CEP = string.IsNullOrEmpty(form["CEP"]) ? string.Empty : form["CEP"],
                Cidade = string.IsNullOrEmpty(form["cidade"]) ? string.Empty : form["cidade"],
                CNPJ = string.IsNullOrEmpty(form["CNPJ"]) ? string.Empty : form["CNPJ"],
                Contador = CadastroDeContador.InjetarEmUsuarioModel(ControleDeContador.buscarContadorPorID(string.IsNullOrEmpty(form["idContador"]) ? 0 : Convert.ToInt32(form["idContador"]))),
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

        private static EmpresaModel InjetarEmUsuarioModel(CLIENTE_OUTRASEMP x)
        {
            if (x == null)
                return null;
            else
                return new EmpresaModel()
                {
                    Cliente = new ClienteModel() { IdCliente = (int)x.IDCLI },
                    Email = x.EMAIL,
                    IdEmpresa = (int)x.IDEMP,
                    NomeResponsavel = x.NOMERESP,
                    NomeEmpresa = x.EMPRESA,
                    Telefone = x.TELEFONE
                };
        }

        private static EmpresaModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new EmpresaModel()
            {
                Cliente = RecuperarClientePorID(string.IsNullOrEmpty(form["codigoClienteEmpresa"]) ? 0 : Convert.ToInt32(form["codigoClienteEmpresa"])),
                Email = string.IsNullOrEmpty(form["emailEmpresa"]) ? null : form["emailEmpresa"],
                IdEmpresa = string.IsNullOrEmpty(form["codigoEmpresa"]) ? 0 : Convert.ToInt32(form["codigoEmpresa"]),
                NomeEmpresa = string.IsNullOrEmpty(form["nomeEmpresa"]) ? null : form["nomeEmpresa"],
                NomeResponsavel = string.IsNullOrEmpty(form["nomeResponsavel"]) ? null : form["nomeResponsavel"],
                Telefone = Util.ApenasNumeros(string.IsNullOrEmpty(form["telFixoEmpresa"]) ? null : form["telFixoEmpresa"])
            };
        }

        private static ClienteModel injetarEmUsuarioModelAJAX(CLIENTE x)
        {
            return new ClienteModel()
            {
                IdCliente = (int)x.IDCLI,
                Bairro = x.BAIRRO,
                CEP = x.CEP,
                Cidade = x.CIDADE,
                CNPJ = x.CPFCNPJ,

                ElaboradorDoPCMSO = CadastroDeElaboradorPCMSO.InjetarEmUsuarioModel(x.EPCMSO),
                ElaboradorDoPPRA = CadastroDeElaboradorPPRA.InjetarEmUsuarioModel(x.EPPRA),
                EnderecoCompleto = x.ENDERECO,
                NomeFantasia = x.NOMEFANTASIA,
                NumeroDeFuncionarios = x.NFUN,
                RazaoSocial = x.RAZAOSOCIAL,
                TipoEmpresa = getTipoCliente(x.TIPOCLIENTE),
                UF = x.UF,
                Observacoes = x.OBSERVACOES
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

        #endregion Private Methods
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Financeiro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.Code.Parametro;
using MediCloud.Code.Clientes;
using MediCloud.Code.Enum;
using MediCloud.Controllers;
using System.Web.Mvc;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeCrediarioCliente
    {
        internal static List<CrediarioClienteModel> RecuperarCrediariosDeGrupoDeClientes(int IdGrupoDeClientes)
        {
            List<CLIENTE_CREDIARIO> crediariosDeGrupo = ControleDeCrediarioCliente.RecuperarCrediariosDeGrupoDeClientes(IdGrupoDeClientes);
            List<CrediarioClienteModel> crediariosEncontrados = new List<CrediarioClienteModel>();

            crediariosDeGrupo.ForEach(x => 
            {
                crediariosEncontrados.Add(InjetarEmUsuarioModel(x));
            });

            return crediariosEncontrados;
        }

        internal static List<CrediarioClienteModel> RecuperarCrediarioClientePorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            List<CLIENTE_CREDIARIO> contadoresEncontrados = ControleDeCrediarioCliente.RecuperarCrediarioClientePorTermo(prefix);
            List<CrediarioClienteModel> resultados = new List<CrediarioClienteModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static void BloquearCrediario(CrediarioClienteController crediarioClienteController, int codigoDoCrediario, bool bloquear)
        {
            ControleDeCrediarioCliente.BloquearCrediario(codigoDoCrediario, bloquear);
        }

        private static CrediarioClienteModel InjetarEmUsuarioModel(CLIENTE_CREDIARIO x)
        {
            if (x == null)
                return null;
            else
                return new CrediarioClienteModel()
                {
                    Bairro = x.BAIRRO,
                    Bloqueado = string.IsNullOrEmpty(x.STATUS) ? false : x.STATUS == "S",
                    CEP = x.CEP,
                    Cidade = x.CIDADE,
                    CidadeEntrega = CadastroDeCidade.RecuperarCidadePorID(x.IDCID.HasValue ? (int)x.IDCID : 0),
                    Cliente = CadastroDeClientes.RecuperarClientePorID((int)x.IDCLI),
                    CNPJ = x.CPFCNPJ,
                    EmpresaSacado = x.SACADO,
                    Endereco = x.ENDERECO,
                    Estado = x.UF,
                    Fechamento = CadastroDeFechamento.RecuperarFechamentoPorID((int)x.IDFEC),
                    FormaPagamento = CadastroFormaPagamento.RecuperarFormaPagamentoPorID(x.IDFORPAG.HasValue ? (int)x.IDFORPAG : 0),
                    GrupoDeClientes = CadastroDeGrupoDeClientes.RecuperarGrupoDeCLientesPorID(x.IDCLIGRU.HasValue ? (int)x.IDCLIGRU : 0, false),
                    IdBB = x.IDBBCOBRANCA,
                    IdCrediarioCliente = (int)x.IDCRE,
                    Imprime = string.IsNullOrEmpty(x.IMPRIME) ? false : x.IMPRIME == "S",
                    ImprimeNotaFiscal = string.IsNullOrEmpty(x.NF) ? EnumFinanceiro.ImprimeNotaFiscal.vazio : (x.NF == "I" ? EnumFinanceiro.ImprimeNotaFiscal.Imprime : EnumFinanceiro.ImprimeNotaFiscal.NaoImprime),
                    InscricaoEstadual = x.INSCESTADUAL,
                    InscricaoMunicipal = x.INSCMUNICIPAL,
                    ModoDeDeEntrega = ConverterModoDeEntregaDeStringParaEnum(x.ENTREGA),
                    Observacao = x.OBSNF,
                    Tabela = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID((int)x.IDTAB, false),
                    TipoEmpresa = ConverterTipoEmpresaDeStringParaEnum(x.TIPOEMPRESA),
                    Usuario = x.USUARIO
                };
        }

        internal static void DeletarCrediarioCliente(int codigoCrediarioCliente)
        {
            ControleDeCrediarioCliente.ExcluirCrediarioCliente(codigoCrediarioCliente);
        }

        internal static CrediarioClienteModel RecuperarCrediarioClientePorID(int v)
        {
            if (v != 0)
            {
                CLIENTE_CREDIARIO referenteEncontrado = ControleDeCrediarioCliente.RecuperarCrediarioClientePorID(v);
                return InjetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        private static EnumCliente.tipoEmpresa ConverterTipoEmpresaDeStringParaEnum(string x)
        {
            switch (x)
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

        internal static CrediarioClienteModel SalvarCrediarioCliente(FormCollection form)
        {
            CrediarioClienteModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            CLIENTE_CREDIARIO cargoDAO = InjetarEmUsuarioDAO(usuarioModel);
            cargoDAO = ControleDeCrediarioCliente.SalvarCrediarioCliente(cargoDAO);

            usuarioModel = InjetarEmUsuarioModel(cargoDAO);

            return usuarioModel;
        }

        private static CLIENTE_CREDIARIO InjetarEmUsuarioDAO(CrediarioClienteModel x)
        {
            if (x == null)
                return null;
            else
                return new CLIENTE_CREDIARIO()
                {
                    BAIRRO = x.Bairro,
                    CEP = x.CEP,
                    CIDADE = x.Cidade,
                    CPFCNPJ = x.CNPJ,
                    ENDERECO = x.Endereco,
                    ENTREGA = ConverterModoDeEntregaDeStringParaEnum(x.ModoDeDeEntrega),
                    IDBBCOBRANCA = x.IdBB,
                    IDCID = x.CidadeEntrega?.IdCidade, 
                    IDCLI = x.Cliente.IdCliente,
                    IDCLIGRU = x.GrupoDeClientes?.IdGrupoCliente,
                    IDCRE = x.IdCrediarioCliente,
                    IDFEC = x.Fechamento.IdFechamento,
                    IDFORPAG = x.FormaPagamento?.IdFormaPagamento,
                    IDTAB = x.Tabela.IdTabela,
                    IMPRIME = x.Imprime.HasValue ? (x.Imprime.Value == true ? "S" : "N") : "N",
                    INSCESTADUAL = x.InscricaoEstadual,
                    INSCMUNICIPAL = x.InscricaoMunicipal,
                    NF = ConverterImprimeNotaFiscalDeStringParaEnum(x.ImprimeNotaFiscal),
                    OBSNF = x.Observacao,
                    SACADO = x.EmpresaSacado,
                    STATUS = x.Bloqueado.HasValue ? (x.Bloqueado.Value == true ? "S" : "N") : "N",
                    TIPOEMPRESA = ConverterTipoEmpresaDeStringParaEnum(x.TipoEmpresa),
                    UF = x.Estado,
                    USUARIO = x.Usuario
                };
        }

        private static CrediarioClienteModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new CrediarioClienteModel()
            {
                Bairro = string.IsNullOrEmpty(form["bairro"]) ? null : form["bairro"],
                CEP = string.IsNullOrEmpty(form["CEP"]) ? null : Util.ApenasNumeros(form["CEP"]),
                Cidade = string.IsNullOrEmpty(form["cidade"]) ? null : form["cidade"],
                CidadeEntrega = null,
                CNPJ = string.IsNullOrEmpty(form["CNPJ"]) ? null : Util.ApenasNumeros(form["CNPJ"]),
                Endereco = string.IsNullOrEmpty(form["endereco"]) ? null : form["endereco"],
                Estado = string.IsNullOrEmpty(form["UF"]) ? null : form["UF"],
                Fechamento = CadastroDeFechamento.RecuperarFechamentoPorID(string.IsNullOrEmpty(form["idFechamento"]) ? 0 : Convert.ToInt32(form["idFechamento"])),
                FormaPagamento = null,
                GrupoDeClientes = CadastroDeGrupoDeClientes.RecuperarGrupoDeCLientesPorID(string.IsNullOrEmpty(form["idGrupoDeCliente"]) ? 0 : Convert.ToInt32(form["idGrupoDeCliente"])),
                ImprimeNotaFiscal = EnumFinanceiro.ImprimeNotaFiscal.vazio,
                InscricaoEstadual = string.IsNullOrEmpty(form["inscricaoEstadual"]) ? null : form["inscricaoEstadual"],
                InscricaoMunicipal = string.IsNullOrEmpty(form["inscricaoMunicipal"]) ? null : form["inscricaoMunicipal"],
                TipoEmpresa = string.IsNullOrEmpty(form["tipoEmpresa"]) ? EnumCliente.tipoEmpresa.Vazio : (EnumCliente.tipoEmpresa)Convert.ToInt32(form["tipoEmpresa"]),
                Bloqueado = string.IsNullOrEmpty(form["bloqueado"]) ? false : Convert.ToBoolean(form["bloqueado"].ToLower() == "on"),
                Cliente = CadastroDeClientes.RecuperarClientePorID(string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"])),
                EmpresaSacado = string.IsNullOrEmpty(form["empresaSacado"]) ? null : form["empresaSacado"],
                IdBB = null,
                IdCrediarioCliente = string.IsNullOrEmpty(form["codigoCrediarioCliente"]) ? 0 : Convert.ToInt32(form["codigoCrediarioCliente"]),
                Imprime = string.IsNullOrEmpty(form["imprimeNF"]) ? false : Convert.ToBoolean(form["imprimeNF"].ToLower() == "on"),
                ModoDeDeEntrega = EnumFinanceiro.ModoDeEntrega.vazio,
                Observacao = null,
                Tabela = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID(string.IsNullOrEmpty(form["idTabela"]) ? 0 : Convert.ToInt32(form["idTabela"])),
                Usuario = null
            };
        }

        private static string ConverterTipoEmpresaDeStringParaEnum(EnumCliente.tipoEmpresa x)
        {
            switch (x)
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

        private static EnumFinanceiro.ModoDeEntrega ConverterModoDeEntregaDeStringParaEnum(string x)
        {
            switch (x)
            {
                case "E-MAIL":
                    return EnumFinanceiro.ModoDeEntrega.Email;
                case "CORREIO":
                    return EnumFinanceiro.ModoDeEntrega.Correio;
                case "MOTOBOY":
                    return EnumFinanceiro.ModoDeEntrega.Motoboy;
                case "LOCAL":
                    return EnumFinanceiro.ModoDeEntrega.BuscaNoLocal;
                default:
                    return EnumFinanceiro.ModoDeEntrega.vazio;
            }
        }

        private static string ConverterModoDeEntregaDeStringParaEnum(EnumFinanceiro.ModoDeEntrega x)
        {
            switch (x)
            {
                case EnumFinanceiro.ModoDeEntrega.Email:
                    return "E-MAIL";
                case EnumFinanceiro.ModoDeEntrega.Correio:
                    return "CORREIO";
                case EnumFinanceiro.ModoDeEntrega.Motoboy:
                    return "MOTOBOY";
                case EnumFinanceiro.ModoDeEntrega.BuscaNoLocal:
                    return "LOCAL";
                default:
                    return null;
            }
        }

        private static EnumFinanceiro.ImprimeNotaFiscal ConverterImprimeNotaFiscalDeStringParaEnum(string x)
        {
            switch (x)
            {
                case "S":
                    return EnumFinanceiro.ImprimeNotaFiscal.Imprime;
                case "N":
                    return EnumFinanceiro.ImprimeNotaFiscal.NaoImprime;
                case "E":
                    return EnumFinanceiro.ImprimeNotaFiscal.Exporta;
                default:
                    return EnumFinanceiro.ImprimeNotaFiscal.vazio;
            }
        }

        private static string ConverterImprimeNotaFiscalDeStringParaEnum(EnumFinanceiro.ImprimeNotaFiscal x)
        {
            switch (x)
            {
                case EnumFinanceiro.ImprimeNotaFiscal.Imprime:
                    return "S";
                case EnumFinanceiro.ImprimeNotaFiscal.NaoImprime:
                    return "N";
                case EnumFinanceiro.ImprimeNotaFiscal.Exporta:
                    return "E";
                default:
                    return null;
            }
        }
    }
}
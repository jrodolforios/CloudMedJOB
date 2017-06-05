using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Financeiro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.Code.Parametro;
using MediCloud.Code.Enum;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeGrupoDeClientes
    {
        internal static List<GrupoDeClientesModel> RecuperarSegmentoPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            return RecuperarSegmentoPorTermo(prefix);
        }

        internal static List<GrupoDeClientesModel> RecuperarSegmentoPorTermo(string prefix)
        {
            List<CLIENTE_GRUPO> contadoresEncontrados = ControleDeGrupoDeClientes.BuscarContadoresPorTermo(prefix);
            List<GrupoDeClientesModel> resultados = new List<GrupoDeClientesModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        private static GrupoDeClientesModel InjetarEmUsuarioModel(CLIENTE_GRUPO x, bool preencherClasses = false)
        {
            if (x == null)
                return null;
            else
                return new GrupoDeClientesModel()
                {
                    Bairro = x.BAIRRO,
                    CEP = x.CEP,
                    Cidade = x.CIDADE,
                    CidadeEntrega = CadastroDeCidade.RecuperarCidadePorID(x.IDCID == null ? 0 : (int)x.IDCID),
                    CNPJ = x.CPFCNPJ,
                    codigoBB = x.IDBBCOBRANCA,
                    Endereco = x.ENDERECO,
                    Estado = x.UF,
                    Fechamento = CadastroDeFechamento.RecuperarFechamentoPorID(x.IDFEC == null ? 0 : (int)x.IDFEC),
                    FormaPagamento = CadastroFormaPagamento.RecuperarFormaPagamentoPorID(x.IDFORPAG == null ? 0 : (int)x.IDFORPAG),
                    IdGrupoCliente = (int)x.IDCLIGRU,
                    ImprimeNotaFiscal = ConverterImprimeNotaFiscalDeStringParaEnum(x.IMPRIME),
                    InscricaoEstadual = x.INSCESTADUAL,
                    InscricaoMunicipal = x.INSCMUNICIPAL,
                    ModoDeEntrega = ConverterModoDeEntregaDeStringParaEnum(x.ENTREGA),
                    NomeFantasia = x.NOMEFANTASIA,
                    NomeGrupo = x.GRUPO,
                    Observacoes = x.OBSERVACOES,
                    ObservacoesNotaFiscal = x.OBSNF,
                    RotaDeEntrega = CadastroDeRotaDeEntrega.RecuperarRotaDeEntregaPorID(x.IDROTA == null ? 0 : (int)x.IDROTA),
                    Segmento = CadastroDeSegmento.buscarSegmentoPorID(x.IDSEG == null ? 0 : (int)x.IDSEG),
                    TipoEmpresa = ConverterTipoEmpresaDeStringParaEnum(x.TIPOEMPRESA),

                    CrediariosCliente = preencherClasses ? CadastroDeCrediarioCliente.RecuperarCrediariosDeGrupoDeClientes((int)x.IDCLIGRU) : new List<CrediarioClienteModel>()
                };
        }

        internal static GrupoDeClientesModel RecuperarGrupoDeCLientesPorID(int v, bool carregarClasses = true)
        {
            if (v != 0)
            {
                CLIENTE_GRUPO referenteEncontrado = ControleDeGrupoDeClientes.RecuperarGrupoDeCLientesPorID(v);
                return InjetarEmUsuarioModel(referenteEncontrado, carregarClasses);
            }
            else
                return null;
        }

        internal static void DeletarGrupoDeClientes(int codigoGrupoDeClientes)
        {
            ControleDeGrupoDeClientes.ExcluirGrupoDeCLientes(codigoGrupoDeClientes);
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

        internal static GrupoDeClientesModel SalvarGrupoDeClientes(FormCollection form)
        {
            GrupoDeClientesModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            CLIENTE_GRUPO GrupoClienteDAO = InjetarEmUsuarioDAO(usuarioModel);
            GrupoClienteDAO = ControleDeGrupoDeClientes.SalvarGrupoDeClientes(GrupoClienteDAO);

            usuarioModel = InjetarEmUsuarioModel(GrupoClienteDAO, true);

            return usuarioModel;
        }

        private static CLIENTE_GRUPO InjetarEmUsuarioDAO(GrupoDeClientesModel x)
        {
            if (x == null)
                return null;
            else
                return new CLIENTE_GRUPO()
                {
                    BAIRRO = x.Bairro,
                    CEP = x.CEP,
                    CIDADE = x.Cidade,
                    CPFCNPJ = x.CNPJ,
                    ENDERECO = x.Endereco,
                    ENTREGA = ConverterModoDeEntregaDeStringParaEnum(x.ModoDeEntrega),
                    GRUPO = x.NomeGrupo,
                    IDBBCOBRANCA = x.codigoBB,
                    IDCID = x.CidadeEntrega?.IdCidade,
                    IDCLIGRU = x.IdGrupoCliente,
                    IDFEC = x.Fechamento?.IdFechamento,
                    IDFORPAG = x.FormaPagamento?.IdFormaPagamento,
                    IDROTA = x.RotaDeEntrega?.IdRotaDeEntrega,
                    IDSEG = x.Segmento?.IdSegmento,
                    IMPRIME = ConverterImprimeNotaFiscalDeStringParaEnum(x.ImprimeNotaFiscal),
                    INSCESTADUAL = x.InscricaoEstadual,
                    INSCMUNICIPAL = x.InscricaoMunicipal,
                    NF = x.ImprimeNotaFiscal == EnumFinanceiro.ImprimeNotaFiscal.Imprime ? "I" : "N",
                    NOMEFANTASIA = x.NomeFantasia,
                    OBSERVACOES = x.Observacoes,
                    OBSNF = x.ObservacoesNotaFiscal,
                    TIPOCLIENTE = ConverterTipoEmpresaDeStringParaEnum(x.TipoEmpresa),
                    TIPOEMPRESA = ConverterTipoEmpresaDeStringParaEnum(x.TipoEmpresa),
                    UF = x.Estado
                };
        }

        internal static void BloquearCrediarioDeGrupo(int codigoDoGrupo)
        {
            ControleDeGrupoDeClientes.BloquearCrediarioDeGrupo(codigoDoGrupo);
        }

        private static GrupoDeClientesModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new GrupoDeClientesModel()
            {
                Bairro = string.IsNullOrEmpty(form["bairro"]) ? null : form["bairro"],
                CEP = string.IsNullOrEmpty(form["CEP"]) ? null : Util.ApenasNumeros(form["CEP"]),
                Cidade = string.IsNullOrEmpty(form["cidade"]) ? null : form["cidade"],
                CidadeEntrega = CadastroDeCidade.RecuperarCidadePorID(string.IsNullOrEmpty(form["idCidadeEntrega"]) ? 0 : Convert.ToInt32(form["idCidadeEntrega"])),
                CNPJ = string.IsNullOrEmpty(form["CNPJ"]) ? null : Util.ApenasNumeros(form["CNPJ"]),
                codigoBB = null,
                Endereco = string.IsNullOrEmpty(form["endereco"]) ? null : form["endereco"],
                Estado = string.IsNullOrEmpty(form["UF"]) ? null : form["UF"],
                Fechamento = CadastroDeFechamento.RecuperarFechamentoPorID(string.IsNullOrEmpty(form["idFechamento"]) ? 0 : Convert.ToInt32(form["idFechamento"])),
                FormaPagamento = CadastroFormaPagamento.RecuperarFormaPagamentoPorID(string.IsNullOrEmpty(form["idFormaPagamento"]) ? 0 : Convert.ToInt32(form["idFormaPagamento"])),
                IdGrupoCliente = string.IsNullOrEmpty(form["codigoGrupoDeClientes"]) ? 0 : Convert.ToInt32(form["codigoGrupoDeClientes"]),
                ImprimeNotaFiscal = string.IsNullOrEmpty(form["notaFiscal"]) ? EnumFinanceiro.ImprimeNotaFiscal.vazio : (EnumFinanceiro.ImprimeNotaFiscal)Convert.ToInt32(form["notaFiscal"]),
                InscricaoEstadual = string.IsNullOrEmpty(form["inscricaoEstadual"]) ? null : form["inscricaoEstadual"],
                InscricaoMunicipal = string.IsNullOrEmpty(form["inscricaoMunicipal"]) ? null : form["inscricaoMunicipal"],
                ModoDeEntrega = string.IsNullOrEmpty(form["modoEntrega"]) ? EnumFinanceiro.ModoDeEntrega.vazio : (EnumFinanceiro.ModoDeEntrega)Convert.ToInt32(form["modoEntrega"]),
                NomeFantasia = string.IsNullOrEmpty(form["nomeFantasia"]) ? null : form["nomeFantasia"],
                NomeGrupo = string.IsNullOrEmpty(form["nomeGrupo"]) ? null : form["nomeGrupo"],
                Observacoes = string.IsNullOrEmpty(form["observacoes"]) ? null : form["observacoes"],
                ObservacoesNotaFiscal = string.IsNullOrEmpty(form["observacoesNotaFiscal"]) ? null : form["observacoesNotaFiscal"],
                RotaDeEntrega = CadastroDeRotaDeEntrega.RecuperarRotaDeEntregaPorID(string.IsNullOrEmpty(form["idRotaDeEntrega"]) ? 0 : Convert.ToInt32(form["idRotaDeEntrega"])),
                Segmento = CadastroDeSegmento.buscarSegmentoPorID(string.IsNullOrEmpty(form["idSegmento"]) ? 0 : Convert.ToInt32(form["idSegmento"])),
                TipoEmpresa = string.IsNullOrEmpty(form["tipoEmpresa"]) ? EnumCliente.tipoEmpresa.Vazio : (EnumCliente.tipoEmpresa)Convert.ToInt32(form["tipoEmpresa"])
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
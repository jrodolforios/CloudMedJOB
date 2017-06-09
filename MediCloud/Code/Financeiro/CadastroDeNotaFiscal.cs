using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Financeiro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.Code.Parametro;
using MediCloud.Code.Clientes;
using MediCloud.Code.Enum;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeNotaFiscal
    {
        internal static List<NotaFiscalModel> RecuperarNotaFiscalPorTermo(string prefix)
        {
            List<NOTAFISCAL> contadoresEncontrados = ControleDeNotaFiscal.BuscarNotaFiscalPorTermo(prefix);
            List<NotaFiscalModel> resultados = new List<NotaFiscalModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x)); 
            });

            return resultados;
        }

        private static NotaFiscalModel InjetarEmUsuarioModel(NOTAFISCAL x)
        {
            if (x == null)
                return null;
            else
                return new NotaFiscalModel()
                {
                    Bairro = x.BAIRRO,
                    CEP = x.CEP,
                    Cidade = x.CIDADE,
                    CidadeCobranca = CadastroDeCidade.RecuperarCidadePorID((int?)x.IDCID ?? 0),
                    Cliente = CadastroDeClientes.RecuperarClientePorID((int?)x.IDCLI ?? 0),
                    CNPJ = x.CPFCNPJ,
                    DataEmissao = x.DATAEMISSAO,
                    DataVencimento = x.DATAVENCIMENTO,
                    Endereco = x.ENDERECO,
                    Estado = x.UF,
                    Faturamento = CadastroDeFaturamento.RecuperarFaturamentoPorID((int?)x.IDFAT ?? 0, false),
                    FormaDePagamento = CadastroFormaPagamento.RecuperarFormaPagamentoPorID((int?)x.IDFORPAG ?? 0),
                    GrupoDeCliente = CadastroDeGrupoDeClientes.RecuperarGrupoDeCLientesPorID((int?)x.IDCLIGRU ?? 0),
                    IdBB = x.IDBBCOBRANCA,
                    IdNotaFiscal = (int)x.IDNF,
                    Imprime = x.IMPRIME == null ? false : x.IMPRIME == "S",
                    ImprimeNotaFiscal = ConverterImprimeNotaFiscalDeStringParaEnum(x.NF),
                    InscricaoEstadual = x.INSCESTADUAL,
                    InscricaoMunicipal = x.INSCMUNICIPAL,
                    ModoEntrega = ConverterModoDeEntregaDeStringParaEnum(x.ENTREGA),
                    NumeroNotaFiscal = x.NUMNF,
                    ObservacaoNF = x.OBSNF,
                    RazaoSocial = x.RAZAOSOCIAL,
                    ValorDescontoPorPrazo = x.DESCONTONOPRAZO,
                    ValorIRRF = x.IRRFNF,
                    ValorISS = x.ISSNF,
                    ValorPISCONFINS = x.PISCOFINSCSSL,
                    ValorTotal = x.TOTALNOTA,

                    DetalhesNotaFiscal = RecuperarDetalhesDeNotaFiscal((int)x.IDNF)
                };
        }

        internal static void ExcluirNotaFiscal(int codigoDaNotaFiscal)
        {
            ControleDeNotaFiscal.ExcluirNotaFiscal(codigoDaNotaFiscal);
        }

        internal static List<NotaFiscalModel> RecuperarNotasFiscaisDeFaturamento(decimal idFaturamento)
        {
            List<NOTAFISCAL> detalheNotaFiscal = ControleDeNotaFiscal.RecuperarNotasFiscaisDeFaturamento(idFaturamento);
            List<NotaFiscalModel> resultados = new List<NotaFiscalModel>();

            detalheNotaFiscal.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        private static List<DetalheNotaFiscalModel> RecuperarDetalhesDeNotaFiscal(int idNF)
        {
            List<SLNOTAFISCAL> detalheNotaFiscal = ControleDeNotaFiscal.RecuperarDetalheDeNotaFiscal(idNF);
            List<DetalheNotaFiscalModel> resultados = new List<DetalheNotaFiscalModel>();

            detalheNotaFiscal.ForEach(x =>
            {
                resultados.Add(InjetarEmDetalheNotaFiscalModel(x));
            });

            return resultados;
        }

        private static DetalheNotaFiscalModel InjetarEmDetalheNotaFiscalModel(SLNOTAFISCAL x)
        {
            if (x == null)
                return null;
            else
                return new DetalheNotaFiscalModel()
                {
                    IdNotaFiscal = (int)x.IDNF,
                    Quantidade = (int?)x.QUANTIDADE,
                    SubGrupo = x.SUBGRUPO,
                    Total = x.TOTAL_ITEM,
                    ValorUnitario = x.VLR_UNITARIO
                };
        }

        internal static NotaFiscalModel RecuperarNotaFiscalPorID(int v)
        {
            if (v != 0)
            {
                NOTAFISCAL notaFiscalEncontrada = ControleDeNotaFiscal.RecuperarNotaFiscalPorID(v);
                return InjetarEmUsuarioModel(notaFiscalEncontrada);
            }
            else
                return null;
        }

        internal static NotaFiscalModel SalvarNotaFiscal(FormCollection form)
        {
            NotaFiscalModel notaFiscalModel = injetarEmUsuarioModel(form);
            notaFiscalModel.validar();

            NOTAFISCAL notaFiscalDAO = injetarEmUsuarioDAO(notaFiscalModel);
            notaFiscalDAO = ControleDeNotaFiscal.SalvarNotaFiscal(notaFiscalDAO);

            notaFiscalModel = InjetarEmUsuarioModel(notaFiscalDAO);

            return notaFiscalModel;
        }

        private static NOTAFISCAL injetarEmUsuarioDAO(NotaFiscalModel x)
        {
            return new NOTAFISCAL()
            {
                BAIRRO = x.Bairro,
                CEP = x.CEP,
                CIDADE = x.Cidade,
                CPFCNPJ = x.CNPJ,
                DATAEMISSAO = x.DataEmissao,
                DATAVENCIMENTO = x.DataVencimento,
                DESCONTONOPRAZO = x.ValorDescontoPorPrazo,
                ENDERECO = x.Endereco,
                ENTREGA = ConverterModoDeEntregaDeStringParaEnum(x.ModoEntrega),
                IDBBCOBRANCA = x.IdBB,
                IDCID = x.CidadeCobranca?.IdCidade,
                IDCLI = x.Cliente?.IdCliente,
                IDCLIGRU = x.GrupoDeCliente?.IdGrupoCliente,
                IDFAT = x.Faturamento?.IdFaturamento,
                IDFORPAG = x.FormaDePagamento?.IdFormaPagamento,
                IDNF = x.IdNotaFiscal,
                IMPRIME = x.Imprime ? "S" : "N",
                INSCESTADUAL = x.InscricaoEstadual,
                INSCMUNICIPAL = x.InscricaoMunicipal,
                IRRFNF = x.ValorIRRF,
                ISSNF = x.ValorISS,
                NF = ConverterImprimeNotaFiscalDeStringParaEnum(x.ImprimeNotaFiscal),
                NUMNF = x.NumeroNotaFiscal,
                OBSNF = x.ObservacaoNF,
                PISCOFINSCSSL = x.ValorPISCONFINS,
                RAZAOSOCIAL = x.RazaoSocial,
                TOTALNOTA = x.ValorTotal,
                UF = x.Estado
            };
        }

        private static NotaFiscalModel injetarEmUsuarioModel(FormCollection form)
        {
            return new NotaFiscalModel()
            {
                Bairro = string.IsNullOrEmpty(form["bairro"]) ? null : form["bairro"],
                CEP = string.IsNullOrEmpty(form["CEP"]) ? null : Util.ApenasNumeros(form["CEP"]),
                Cidade = string.IsNullOrEmpty(form["cidade"]) ? null : form["cidade"],
                CidadeCobranca = CadastroDeCidade.RecuperarCidadePorID(string.IsNullOrEmpty(form["idCidadeCobranca"]) ? 0 : Convert.ToInt32(form["idCidadeCobranca"])),
                Cliente = CadastroDeClientes.RecuperarClientePorID(string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"])),
                CNPJ = string.IsNullOrEmpty(form["cpf"]) ? null : Util.ApenasNumeros(form["cpf"]),
                DataEmissao = string.IsNullOrEmpty(form["dataEmissao"]) ? null : (DateTime?)Convert.ToDateTime(form["dataEmissao"]),
                DataVencimento = string.IsNullOrEmpty(form["dataVencimento"]) ? null : (DateTime?)Convert.ToDateTime(form["dataVencimento"]),
                Endereco = string.IsNullOrEmpty(form["endereco"]) ? null : form["endereco"],
                Estado = string.IsNullOrEmpty(form["estado"]) ? null : form["estado"],
                Faturamento = CadastroDeFaturamento.RecuperarFaturamentoPorID(string.IsNullOrEmpty(form["codigoFaturamentoNotaFiscal"]) ? 0 : Convert.ToInt32(form["codigoFaturamentoNotaFiscal"])),
                FormaDePagamento = CadastroFormaPagamento.RecuperarFormaPagamentoPorID(string.IsNullOrEmpty(form["idFormaPagamento"]) ? 0 : Convert.ToInt32(form["idFormaPagamento"])),
                GrupoDeCliente = CadastroDeGrupoDeClientes.RecuperarGrupoDeCLientesPorID(string.IsNullOrEmpty(form["idGrupoClientes"]) ? 0 : Convert.ToInt32(form["idGrupoClientes"])),
                IdBB = null,
                IdNotaFiscal = string.IsNullOrEmpty(form["codigoNotaFiscal"]) ? 0 : Convert.ToInt32(form["codigoNotaFiscal"]),
                Imprime = string.IsNullOrEmpty(form["imprimeNF"]) ? false : Convert.ToBoolean(form["imprimeNF"].ToLower() == "on"),
                ImprimeNotaFiscal = string.IsNullOrEmpty(form["imprimeNotaFiscal"]) ? EnumFinanceiro.ImprimeNotaFiscal.vazio : (EnumFinanceiro.ImprimeNotaFiscal)Convert.ToInt32(form["imprimeNotaFiscal"]),
                InscricaoEstadual = string.IsNullOrEmpty(form["InscricaoEstadual"]) ? null : form["InscricaoEstadual"],
                InscricaoMunicipal = string.IsNullOrEmpty(form["InscricaoMunicipal"]) ? null : form["InscricaoMunicipal"],
                ModoEntrega = string.IsNullOrEmpty(form["modoEntrega"]) ? EnumFinanceiro.ModoDeEntrega.vazio : (EnumFinanceiro.ModoDeEntrega)Convert.ToInt32(form["modoEntrega"]),
                NumeroNotaFiscal = string.IsNullOrEmpty(form["numeroNF"]) ? null : form["numeroNF"],
                ObservacaoNF = string.IsNullOrEmpty(form["observacao"]) ? null : form["observacao"],
                RazaoSocial = string.IsNullOrEmpty(form["razaoSocial"]) ? null : form["razaoSocial"],
                ValorDescontoPorPrazo = string.IsNullOrEmpty(form["descontoASO"]) ? null : (decimal?)Convert.ToDecimal(form["descontoASO"]),
                ValorIRRF = string.IsNullOrEmpty(form["descontoIRRF"]) ? null : (decimal?)Convert.ToDecimal(form["descontoIRRF"]),
                ValorISS = string.IsNullOrEmpty(form["descontoISS"]) ? null : (decimal?)Convert.ToDecimal(form["descontoISS"]),
                ValorPISCONFINS = string.IsNullOrEmpty(form["descontoPISCONFINS"]) ? null : (decimal?)Convert.ToDecimal(form["descontoPISCONFINS"]),
                ValorTotal = string.IsNullOrEmpty(form["valorTotal"]) ? null : (decimal?)Convert.ToDecimal(form["valorTotal"])
            };
        }

        internal static List<NotaFiscalModel> RecuperarNotaFiscalPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            return RecuperarNotaFiscalPorTermo(prefix);
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
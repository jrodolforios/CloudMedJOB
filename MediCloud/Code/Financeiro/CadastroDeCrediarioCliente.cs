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
                    GrupoDeClientes = new GrupoDeClientesModel() {IdGrupoCliente = x.IDCLIGRU.HasValue ? (int)x.IDCLIGRU : 0 },
                    IdBB = x.IDBBCOBRANCA,
                    IdCrediarioCliente = (int)x.IDCRE,
                    Imprime = string.IsNullOrEmpty(x.IMPRIME) ? false : x.IMPRIME == "S",
                    ImprimeNotaFiscal = string.IsNullOrEmpty(x.NF) ? EnumFinanceiro.ImprimeNotaFiscal.vazio : (x.NF == "I" ? EnumFinanceiro.ImprimeNotaFiscal.Imprime : EnumFinanceiro.ImprimeNotaFiscal.NaoImprime),
                    InscricaoEstadual = x.INSCESTADUAL,
                    InscricaoMUnicipal = x.INSCMUNICIPAL,
                    ModoDeDentrega = ConverterModoDeEntregaDeStringParaEnum(x.ENTREGA),
                    Observacao = x.OBSNF,
                    Tabela = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID((int)x.IDTAB),
                    TipoEmpresa = ConverterTipoEmpresaDeStringParaEnum(x.TIPOEMPRESA),
                    Usuario = x.USUARIO
                };
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
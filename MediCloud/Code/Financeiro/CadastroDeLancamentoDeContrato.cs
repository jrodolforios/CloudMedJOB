using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Financeiro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.Code.Fornecedor;
using MediCloud.Code.Enum;
using MediCloud.Code.Clientes;
using MediCloud.Code.Parametro.GrupoProcedimento;
using MediCloud.Code.Parametro;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeLancamentoDeContrato
    {
        internal static List<LancamentoDeContratoModel> RecuperarLancamentoPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            List<CONTRATO_FIXO> contadoresEncontrados = ControleDeLancamentoDeContratoFixo.BuscarLancamentoPorTermo(prefix);
            List<LancamentoDeContratoModel> resultados = new List<LancamentoDeContratoModel>();

            contadoresEncontrados.ForEach((Action<CONTRATO_FIXO>)(x =>
            {
                resultados.Add(CadastroDeLancamentoDeContrato.InjetarEmUsuarioModel((CONTRATO_FIXO)x));
            }));

            return resultados;
        }

        private static LancamentoDeContratoModel InjetarEmUsuarioModel(CONTRATO_FIXO x, bool carregarClasses = false)
        {
            if (x == null)
                return null;
            else
                return new LancamentoDeContratoModel()
                {
                    Data = x.DATA,
                    DiaDeFechamento = Convert.ToInt32(x.DIA),
                    FornecedorContrato = CadastroDeFornecedor.RecuperarFornecedorPorID(x.IDFOR),
                    IdLancamentoContrato = (int)x.IDLAN,
                    Quantidade = x.QUANTIDADE,
                    SituacaoContrato = ConverterDeStringParaEnum(x.SITUACAO),
                    Total = x.TOTAL,
                    Usuario = x.USUARIO,

                    DetalhesContrato = carregarClasses ? CarregarDetalhesDoContrato((int)x.IDLAN) : new List<DetalheContratoModel>()
                };
        }

        private static List<DetalheContratoModel> CarregarDetalhesDoContrato(int idLan)
        {
            List<CONTRATO_FIXO_DET> contadoresEncontrados = ControleDeLancamentoDeContratoFixo.BuscarDetalhesDeLancamento(idLan);
            List<DetalheContratoModel> resultados = new List<DetalheContratoModel>();

            contadoresEncontrados.ForEach((Action<CONTRATO_FIXO_DET>)(x =>
            {
                resultados.Add(InjetarEmUsuarioModel((CONTRATO_FIXO_DET)x));
            }));

            return resultados;
        }

        private static DetalheContratoModel InjetarEmUsuarioModel(CONTRATO_FIXO_DET x, bool carregarASO = false)
        {
            if (x == null)
                return null;
            else
                return new DetalheContratoModel()
                {
                    ASO = carregarASO ? CadastroDeASO.RecuperarASOPorID((int)x.IDMOV) : new Models.Cliente.ASOModel() {IdASO = (int)x.IDMOV },
                    Cliente = CadastroDeClientes.RecuperarClientePorID((int)x.IDCLI),
                    Contrato = new LancamentoDeContratoModel() { IdLancamentoContrato = (int)x.IDLAN },
                    IdDetalheContrato = (int)x.IDLANCONTFIX,
                    Procedimento = CadastroDeProcedimentos.RecuperarProcedimentoPorID((int)x.IDPRO),
                    Tabela = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID((int)x.IDTAB),
                    Valor = x.VALOR
                };
        }

        internal static LancamentoDeContratoModel RecuperarLancamentoPorID(int? v)
        {
            if (v.HasValue && v != 0)
            {
                CONTRATO_FIXO faturamentoEncontrado = ControleDeLancamentoDeContratoFixo.BuscarLancamentoPorID(v);
                return InjetarEmUsuarioModel(faturamentoEncontrado, true);
            }
            else
                return null;
        }

        internal static LancamentoDeContratoModel SalvarLancamentoDeContrato(FormCollection form, string usuario)
        {
            LancamentoDeContratoModel lancamentoModel = InjetarEmUsuarioModel(form);
            ConfigurarValoreParaNovoLancamento(lancamentoModel, usuario);
            lancamentoModel.validar();

            CONTRATO_FIXO contratoFixoDAO = InjetarEmUsuarioDAO(lancamentoModel);
            contratoFixoDAO = ControleDeLancamentoDeContratoFixo.SalvarLancamentoDeContrato(contratoFixoDAO);

            lancamentoModel = InjetarEmUsuarioModel(contratoFixoDAO);

            return lancamentoModel;
        }

        private static void ConfigurarValoreParaNovoLancamento(LancamentoDeContratoModel lancamentoModel, string usuario)
        {
            if (lancamentoModel.IdLancamentoContrato <= 0)
            {
                lancamentoModel.Quantidade = 0;
                lancamentoModel.Usuario = usuario;
                lancamentoModel.Data = DateTime.Now;
                lancamentoModel.SituacaoContrato = EnumFinanceiro.SituacaoContrato.Aberto;
            }
        }

        internal static void lancarMovimentos(int codigoDoLancamentoDeContrato)
        {
            ControleDeLancamentoDeContratoFixo.LancarMovimentos(codigoDoLancamentoDeContrato);
        }

        private static LancamentoDeContratoModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new LancamentoDeContratoModel()
            {
                Data = string.IsNullOrEmpty(form["Data"]) ? null : (DateTime?)Convert.ToDateTime(form["Data"]),
                DiaDeFechamento = string.IsNullOrEmpty(form["diaFechamento"]) ? 0 : Convert.ToInt32(form["diaFechamento"]),
                FornecedorContrato = CadastroDeFornecedor.RecuperarFornecedorPorID(string.IsNullOrEmpty(form["idFornecedor"]) ? 0 : Convert.ToInt32(form["idFornecedor"])),
                IdLancamentoContrato = string.IsNullOrEmpty(form["codigoLancamentoDeContrato"]) ? 0 : Convert.ToInt32(form["codigoLancamentoDeContrato"]),
                Quantidade = string.IsNullOrEmpty(form["Quantidade"]) ? 0 : Convert.ToInt32(form["Quantidade"]),
                SituacaoContrato = string.IsNullOrEmpty(form["Situacao"]) ? EnumFinanceiro.SituacaoContrato.vazio : (EnumFinanceiro.SituacaoContrato)Convert.ToInt32(form["Situacao"]),
                Total = string.IsNullOrEmpty(form["Quantidade"]) ? null : (Int32?)Convert.ToInt32(form["Quantidade"]),
                Usuario = string.IsNullOrEmpty(form["Usuario"]) ? null : form["Usuario"]
            };
        }

        internal static void RevisarDetalhes(int codigoDoLancamentoDeContrato)
        {
            ControleDeLancamentoDeContratoFixo.RevisarDetalhes(codigoDoLancamentoDeContrato);
        }

        private static CONTRATO_FIXO InjetarEmUsuarioDAO(LancamentoDeContratoModel lancamentoModel)
        {
            if (lancamentoModel == null)
                return null;
            else
                return new CONTRATO_FIXO()
                {
                    DATA = lancamentoModel.Data.Value,
                    DIA = lancamentoModel.DiaDeFechamento.Value.ToString(),
                    IDFOR = lancamentoModel.FornecedorContrato.IdFornecedor,
                    IDLAN = lancamentoModel.IdLancamentoContrato,
                    QUANTIDADE = lancamentoModel.Quantidade,
                    SITUACAO = ConverterDeEnumParaString(lancamentoModel.SituacaoContrato),
                    TOTAL = lancamentoModel.Total,
                    USUARIO = lancamentoModel.Usuario
                };
        }

        private static EnumFinanceiro.SituacaoContrato ConverterDeStringParaEnum(string situacao)
        {
            switch (situacao)
            {
                case "ABE":
                    return EnumFinanceiro.SituacaoContrato.Aberto;
                case "CON":
                    return EnumFinanceiro.SituacaoContrato.Conferencia;
                case "LAN":
                    return EnumFinanceiro.SituacaoContrato.Lancado;
                default:
                    return EnumFinanceiro.SituacaoContrato.vazio;
            }
        }

        private static string ConverterDeEnumParaString(EnumFinanceiro.SituacaoContrato situacao)
        {
            switch (situacao)
            {
                case EnumFinanceiro.SituacaoContrato.Aberto:
                    return "ABE";
                case EnumFinanceiro.SituacaoContrato.Conferencia:
                    return "CON";
                case EnumFinanceiro.SituacaoContrato.Lancado:
                    return "LAN";
                default:
                    return null;
            }
        }
    }
}
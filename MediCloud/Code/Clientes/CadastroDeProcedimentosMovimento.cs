using MediCloud.BusinessProcess.Cliente;
using MediCloud.Code.Financeiro;
using MediCloud.Code.Fornecedor;
using MediCloud.Code.Parametro;
using MediCloud.Code.Parametro.GrupoProcedimento;
using MediCloud.DatabaseModels;
using MediCloud.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Controllers;
using System.Web.Mvc;
using System.Globalization;

namespace MediCloud.Code.Clientes
{
    public class CadastroDeProcedimentosMovimento
    {
        internal static List<ProcedimentoMovimentoModel> BuscarProcedimentosDeMovimentoPorIDMovimento(decimal IdMov)
        {
            List<ProcedimentoMovimentoModel> listaDeModels = new List<ProcedimentoMovimentoModel>();

            List<MOVIMENTO_PROCEDIMENTO> usuarioDoBanco = ControleDeProcedimentosMovimento.buscarProcedimentosMovimentoPorIdMovimento(IdMov);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static int ContagemDeConvocacoesNoMes()
        {
            return ControleDeProcedimentosMovimento.ContagemDeConvocacoesNoMes();
        }

        internal static int ContagemProcedimentosNoMes()
        {
            return ControleDeProcedimentosMovimento.ContagemProcedimentosNoMes();
        }

        private static ProcedimentoMovimentoModel injetarEmUsuarioModel(MOVIMENTO_PROCEDIMENTO x, bool materializarMovimento = false, bool materializarClassesDoMovimento = true)
        {
            if (x == null)
                return null;
            else
                return new ProcedimentoMovimentoModel()
                {
                    DataExame = x.DATAEXAME,
                    DataRealizado = x.DATAREALIZADO,
                    Desconto = x.DESCONTO,
                    IdFechamentoCaixa = (int?)x.IDFCX,
                    IdMovimentoProcedimento = (int)x.IDMOVPRO,
                    Movimento = materializarMovimento ? CadastroDeASO.RecuperarASOPorID((int)x.IDMOV, materializarClassesDoMovimento) : new ASOModel() { IdASO = (int)x.IDMOV },
                    Total = x.TOTAL,
                    Usuario = x.USUARIO,
                    UsuarioRealizado = x.USUARIOREALIZADO,
                    Valor = x.VALOR,
                    observacao = x.OBSMOVTO,
                    DataProxExame = x.PROXEXAME,

                    Faturamento = CadastroDeFaturamento.RecuperarFaturamentoPorID(x.IDFAT, false),
                    Fornecedor = CadastroDeFornecedor.RecuperarFornecedorPorID(x.IDFOR, materializarClassesDoMovimento),
                    Procedimento = CadastroDeProcedimentos.RecuperarProcedimentoPorID((int)(x.IDPRO.HasValue ? x.IDPRO.Value : 0)),
                    Profissional = CadastroDeProfissional.GetProfissionalPorID(x.IDPRF)

                };
        }

        internal static void DeletarProcedimentoMovimento(ASOController aSOController, int codigoProcedimento)
        {
            ControleDeProcedimentosMovimento.DeletarProcedimento(codigoProcedimento);
        }

        private static ProcedimentoMovimentoModel injetarEmUsuarioModel(FormCollection form)
        {
            if (form == null)
                return null;
            else
                return new ProcedimentoMovimentoModel()
                {
                    DataExame = string.IsNullOrEmpty(form["dataExame"]) ? null : (DateTime?)Convert.ToDateTime(form["dataExame"]),
                    DataRealizado = string.IsNullOrEmpty(form["dataRealizado"]) ? null : (DateTime?)Convert.ToDateTime(form["dataRealizado"]),
                    Desconto = string.IsNullOrEmpty(form["desconto"]) ? 0 : Convert.ToDecimal(form["desconto"], new CultureInfo("en-US")),
                    Valor = string.IsNullOrEmpty(form["valor"]) ? 0 : Convert.ToDecimal(form["valor"], new CultureInfo("en-US")),
                    Faturamento = CadastroDeFaturamento.RecuperarFaturamentoPorID(string.IsNullOrEmpty(form["codigoFaturamento"]) ? 0 : Convert.ToInt32(form["codigoFaturamento"]),false),
                    Fornecedor = CadastroDeFornecedor.RecuperarFornecedorPorID(string.IsNullOrEmpty(form["idFornecedor"]) ? 0 : Convert.ToInt32(form["idFornecedor"]),false),
                    IdFechamentoCaixa = string.IsNullOrEmpty(form["codigoFechamentoCaixa"]) ? 0 : Convert.ToInt32(form["codigoFechamentoCaixa"]),
                    IdMovimentoProcedimento = string.IsNullOrEmpty(form["codigoProcedimento"]) ? 0 : Convert.ToInt32(form["codigoProcedimento"]),
                    Movimento = new ASOModel() { IdASO = string.IsNullOrEmpty(form["codigoASOProcedimento"]) ? 0 : Convert.ToInt32(form["codigoASOProcedimento"]) },
                    observacao = string.IsNullOrEmpty(form["observacoesProcedimento"]) ? null : form["observacoesProcedimento"],
                    Procedimento = CadastroDeProcedimentos.RecuperarProcedimentoPorID(string.IsNullOrEmpty(form["idProcedimento"]) ? 0 : Convert.ToInt32(form["idProcedimento"])),
                    Profissional = CadastroDeProfissional.GetProfissionalPorID(string.IsNullOrEmpty(form["idProfissional"]) ? null : form["idProfissional"]),
                    Total = string.IsNullOrEmpty(form["total"]) ? 0 : Convert.ToDecimal(form["total"], new CultureInfo("en-US")),
                    Usuario = string.IsNullOrEmpty(form["usuarioProcedimento"]) ? null : form["usuarioProcedimento"],
                    UsuarioRealizado = string.IsNullOrEmpty(form["usuarioProcedimentoRealizado"]) ? null : form["usuarioProcedimentoRealizado"],
                    DataProxExame = string.IsNullOrEmpty(form["dataProxExame"]) ? null : (DateTime?)Convert.ToDateTime(form["dataProxExame"])
                };
        }

        internal static List<ProcedimentoMovimentoModel> BuscarProcedimentoDeMovimentoPorIDASO(int idASO)
        {
            List<MOVIMENTO_PROCEDIMENTO> contadoresEncontrados = ControleDeProcedimentosMovimento.buscarProcedimentosMovimentoPorIdMovimento(idASO);
            List<ProcedimentoMovimentoModel> resultados = new List<ProcedimentoMovimentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModelParaAjax(x));
            });

            return resultados;
        }

        internal static void SalvarProcedimentoMovimento(FormCollection form)
        {
            ProcedimentoMovimentoModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            MOVIMENTO_PROCEDIMENTO ProcedimentoMovimentoDAO = injetarEmUsuarioDAO(usuarioModel);
            ProcedimentoMovimentoDAO = ControleDeProcedimentosMovimento.SalvarProcedimentoMovimento(ProcedimentoMovimentoDAO);
        }

        private static MOVIMENTO_PROCEDIMENTO injetarEmUsuarioDAO(ProcedimentoMovimentoModel x)
        {
            if (x == null)
                return null;
            else
                return new MOVIMENTO_PROCEDIMENTO()
                {
                    DATAEXAME = x.DataExame,
                    DATAREALIZADO = x.DataRealizado,
                    DESCONTO = x.Desconto,
                    IDFAT = x.Faturamento?.IdFaturamento,
                    IDFCX = x.IdFechamentoCaixa,
                    IDFOR = x.Fornecedor?.IdFornecedor,
                    IDMOV = x.Movimento?.IdASO,
                    IDMOVPRO = x.IdMovimentoProcedimento,
                    IDPRF = x.Profissional?.IdProfissional,
                    IDPRO = x.Procedimento?.IdProcedimento,
                    OBSMOVTO = x.observacao,
                    OBSREALIZADO = x.observacao,
                    PROXEXAME = x.DataProxExame,
                    TOTAL = x.Total,
                    USUARIO = x.Usuario,
                    USUARIOREALIZADO = x.UsuarioRealizado,
                    VALOR = x.Valor,
                };
        }

        internal static ProcedimentoMovimentoModel BuscarProcedimentoDeMovimentoPorID(int codigoDoProcedimentoMovimento, bool materializarMovimento = false, bool materializarClassesDoMovimento = true)
        {
            return injetarEmUsuarioModel(ControleDeProcedimentosMovimento.buscarProcedimentoMovimentoPorId(codigoDoProcedimentoMovimento), materializarMovimento, materializarClassesDoMovimento);
        }

        internal static List<ProcedimentoMovimentoModel> RecuperarProcedimentoMovimentoPorTermo(string prefix, bool materializarObjetos = true)
        {
            List<MOVIMENTO_PROCEDIMENTO> contadoresEncontrados = ControleDeProcedimentosMovimento.buscarProcedimentoMovimento(prefix);
            List<ProcedimentoMovimentoModel> resultados = new List<ProcedimentoMovimentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModelParaAjax(x));
            });

            return resultados;
        }

        internal static List<ProcedimentoMovimentoModel> RecuperarProcedimentoMovimentoPorTermoELaudoAudio(string prefix, int IdFuncionario, bool materializarObjetos = true)
        {
            List<MOVIMENTO_PROCEDIMENTO> contadoresEncontrados = ControleDeProcedimentosMovimento.buscarProcedimentoMovimentoLaudoAudio(prefix, IdFuncionario);
            List<ProcedimentoMovimentoModel> resultados = new List<ProcedimentoMovimentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModelParaAjax(x));
            });

            return resultados;
        }

        private static ProcedimentoMovimentoModel injetarEmUsuarioModelParaAjax(MOVIMENTO_PROCEDIMENTO x)
        {
            if (x == null)
                return new ProcedimentoMovimentoModel();
            else
                return new ProcedimentoMovimentoModel()
                {
                    IdMovimentoProcedimento = (int)x.IDMOVPRO,
                    Procedimento = new Models.Parametro.GrupoProcedimento.ProcedimentoModel() { IdProcedimento = x.IDPRO.HasValue ? (int)x.IDPRO : 0, Nome = x.PROCEDIMENTO?.PROCEDIMENTO1 },
                    DataExame = x.DATAEXAME,
                    DataRealizado = x.DATAREALIZADO,
                    Profissional = x.PROFISSIONAIS != null ? new Models.Parametro.ProfissionalModel() { IdProfissional = x.PROFISSIONAIS.PROFISSIONAL, NomeProfissional = x.PROFISSIONAIS.PROFISSIONAL } : new Models.Parametro.ProfissionalModel(),
                    Total = x.TOTAL.HasValue ? x.TOTAL.Value : 0
                };
        }
    }
}
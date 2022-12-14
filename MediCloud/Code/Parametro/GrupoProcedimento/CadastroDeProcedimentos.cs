using MediCloud.BusinessProcess.Parametro.GrupoProcedimento;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro.GrupoProcedimento;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Parametro.GrupoProcedimento
{
    public class CadastroDeProcedimentos
    {
        #region Public Methods

        public static ProcedimentoModel injetarEmUsuarioModel(PROCEDIMENTO x, bool carregarClasses = true)
        {
            if (x == null)
                return null;
            else
                return new ProcedimentoModel()
                {
                    CODNEXO = x.CODNEXO,
                    Complemento = x.COMPLEMENTO,
                    confirmaAutomaticamente = x.CONFIRMARAUTOMATICO,
                    IdProcedimento = (int)x.IDPRO,
                    Nome = x.PROCEDIMENTO1,
                    Sigla = x.ABREVIADO,
                    ZeraAutomaticamente = x.ZERAAUTOMATICO,

                    Profissional = carregarClasses ? CadastroDeProfissional.GetProfissionalPorID(x.IDPRF) : new Models.Parametro.ProfissionalModel(),
                    SubGrupo = carregarClasses ? CadastroDeSubGrupo.GetSubGrupoPorID((int)x.IDSUBGRUPRO) : new SubGrupoModel()
                };
        }

        #endregion Public Methods

        #region Internal Methods

        internal static List<ProcedimentoModel> buscarProcedimento(FormCollection form)
        {
            string prefix = form["keywords"];

            List<PROCEDIMENTO> contadoresEncontrados = ControleDeProcedimentos.buscarProcedimentoPorTermo(prefix);
            List<ProcedimentoModel> resultados = new List<ProcedimentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static decimal BuscarValorProcedimentoPorIDFornecedor(int procedimento, int fornecedor, int tabela)
        {
            return ControleDeProcedimentos.BuscarValorProcedimentoPorIDFornecedor(procedimento, fornecedor, tabela);
        }

        internal static void DeletarProcedimento(ProcedimentoController procedimentoController, int codigoProcedimento)
        {
            ControleDeProcedimentos.DeletarProcedimento(codigoProcedimento);
        }

        internal static List<ProcedimentoModel> RecuperarContadorPorTermoEFornecedor(string prefix, int fornecedor, int tabela)
        {
            List<PROCEDIMENTO> contadoresEncontrados = ControleDeProcedimentos.buscarCargosPorTermoEFornecedor(prefix, fornecedor, tabela);
            List<ProcedimentoModel> resultados = new List<ProcedimentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x, false));
            });

            return resultados;
        }

        internal static ProcedimentoModel RecuperarProcedimentoPorID(int IdPro)
        {
            if (IdPro != 0)
            {
                PROCEDIMENTO usuarioencontrado = ControleDeProcedimentos.recuperarProcedimentoPorID(IdPro);
                return injetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        internal static List<ProcedimentoModel> RecuperarProcedimentoPorTermo(string prefix)
        {
            List<PROCEDIMENTO> contadoresEncontrados = ControleDeProcedimentos.buscarProcedimentoPorTermo(prefix);
            List<ProcedimentoModel> resultados = new List<ProcedimentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static ProcedimentoModel SalvarProcedimento(FormCollection form)
        {
            ProcedimentoModel procedimentoModel = injetarEmUsuarioModel(form);
            procedimentoModel.validar();

            PROCEDIMENTO procedimentoDAO = injetarEmUsuarioDAO(procedimentoModel);
            procedimentoDAO = ControleDeProcedimentos.SalvarProcedimento(procedimentoDAO);

            procedimentoModel = injetarEmUsuarioModel(procedimentoDAO);

            return procedimentoModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static PROCEDIMENTO injetarEmUsuarioDAO(ProcedimentoModel x)
        {
            if (x == null)
                return null;
            else
                return new PROCEDIMENTO()
                {
                    ABREVIADO = x.Sigla,
                    CODNEXO = x.CODNEXO,
                    COMPLEMENTO = x.Complemento,
                    CONFIRMARAUTOMATICO = x.confirmaAutomaticamente,
                    IDPRF = x.Profissional?.IdProfissional,
                    IDPRO = x.IdProcedimento,
                    IDSUBGRUPRO = x.SubGrupo.IdSubGrupo,
                    PROCEDIMENTO1 = x.Nome,
                    ZERAAUTOMATICO = x.ZeraAutomaticamente
                };
        }

        private static ProcedimentoModel injetarEmUsuarioModel(FormCollection form)
        {
            return new ProcedimentoModel()
            {
                CODNEXO = string.IsNullOrEmpty(form["codigoNEXO"]) ? null : form["codigoNEXO"],
                Complemento = string.IsNullOrEmpty(form["complemento"]) ? null : form["complemento"],
                confirmaAutomaticamente = string.IsNullOrEmpty(form["confirmarAutomaticamente"]) ? false : Convert.ToBoolean(form["confirmarAutomaticamente"].ToLower() == "on"),
                IdProcedimento = string.IsNullOrEmpty(form["codigoProcedimento"]) ? 0 : Convert.ToInt32(form["codigoProcedimento"]),
                Nome = string.IsNullOrEmpty(form["nomeProcedimento"]) ? null : form["nomeProcedimento"],
                Profissional = CadastroDeProfissional.GetProfissionalPorID(string.IsNullOrEmpty(form["idProfissional"]) ? string.Empty : form["idProfissional"]),
                Sigla = string.IsNullOrEmpty(form["sigla"]) ? null : form["sigla"],
                SubGrupo = CadastroDeSubGrupo.GetSubGrupoPorID(string.IsNullOrEmpty(form["idSubGrupo"]) ? 0 : Convert.ToInt32(form["idSubGrupo"])),
                ZeraAutomaticamente = string.IsNullOrEmpty(form["zerarAutomaticamente"]) ? false : Convert.ToBoolean(form["zerarAutomaticamente"].ToLower() == "on")
            };
        }

        #endregion Private Methods
    }
}
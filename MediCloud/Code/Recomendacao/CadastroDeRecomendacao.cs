using MediCloud.BusinessProcess.Recomendacao;
using MediCloud.Code.Clientes;
using MediCloud.Code.Parametro.GrupoProcedimento;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Cliente;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.Models.Recomendacao;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Recomendacao
{
    public class CadastroDeRecomendacao
    {
        #region Public Methods

        public static RecomendacaoModel InjetarEmUsuarioModel(RECOMENDACAO x, bool materializarClasses = false)
        {
            if (x == null)
                return null;
            else
                return new RecomendacaoModel()
                {
                    Cargo = materializarClasses ? CadastroDeCargo.RecuperarCargoPorID((int)x.IDCGO) : new CargoModel() { IdCargo = (int)x.IDCGO },
                    Cliente = materializarClasses ? CadastroDeClientes.RecuperarClientePorID((int)x.IDCLI) : new ClienteModel() { IdCliente = (int)x.IDCLI },
                    IdRecomendacao = (int)x.IDREC,
                    Riscos = CadastroDeRiscoNatureza.BuscarRiscosPorIDRecomendacao((int)x.IDREC),
                    Setor = materializarClasses ? CadastroDeSetor.buscarSetorPorID((int)x.IDSETOR) : new SetorModel() { IdSetor = (int)x.IDSETOR },

                    ReferenciasProcedimentos = RecuperarReferenciasEProcedimentosDeRecomendacao(x.IDREC)
                };
        }

        #endregion Public Methods

        #region Internal Methods

        internal static void AdicionarProcedimento(int codigoRecomendacao, int codigoProcedimento, int codigoReferente)
        {
            ControleDeRecomendacao.AdicionarProcedimento(codigoRecomendacao, codigoProcedimento, codigoReferente);
        }

        internal static void AdicionarReferencia(int codigoRecomendacao, int codigoReferencia)
        {
            ControleDeRecomendacao.AdicionarReferencia(codigoRecomendacao, codigoReferencia);
        }

        internal static void AdicionarRisco(int codigoRecomendacao, int codigoRisco)
        {
            ControleDeRecomendacao.AdicionarRisco(codigoRecomendacao, codigoRisco);
        }

        internal static void AlterarPeriodicidade(int idProcedimento, int idRecomendacao, int idReferencia, int periodicidade)
        {
            ControleDeRecomendacao.AlterarPeriodicidade(idProcedimento, idRecomendacao, idReferencia, periodicidade);
        }

        internal static List<RecomendacaoModel> BuscarRecomendacaoMaterializandoClasses(FormCollection form)
        {
            string termo = form["keywords"];
            List<RecomendacaoModel> listaDeModels = new List<RecomendacaoModel>();

            List<RECOMENDACAO> usuarioDoBanco = ControleDeRecomendacao.buscarRecomendacaoPorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmUsuarioModel(x, true));
            });

            return listaDeModels;
        }

        internal static void DeletarProcedimentoDeRecomendacao(int codigoRecomendacao, int codigoReferencia, int codigoprocedimento)
        {
            ControleDeRecomendacao.DeletarProcedimento(codigoRecomendacao, codigoReferencia, codigoprocedimento);
        }

        internal static void DeletarRecomendacao(RecomendacaoController recomendacaoController, int codigoDaRecomendacao)
        {
            ControleDeRecomendacao.DeletarRecomendacao(codigoDaRecomendacao);
        }

        internal static void DeletarReferencia(int codigoRecomendacao, int codigoReferencia)
        {
            ControleDeRecomendacao.DeletarReferenciaDeRecomendacao(codigoRecomendacao, codigoReferencia);
        }

        internal static void DeletarRiscoDeRecomendacao(int codigoDoRecomendacao, int codigoRisco)
        {
            ControleDeRecomendacao.DeletarRisco(codigoDoRecomendacao, codigoRisco);
        }

        internal static int? recuperarPeriodicidadeDeProcedimento(int idProcedimento, int idRecomendacao, int idReferencia)
        {
            return ControleDeRecomendacao.recuperarPeriodicidadeDeProcedimento(idProcedimento, idRecomendacao, idReferencia);
        }

        internal static RecomendacaoModel RecuperarRecomendacaoPorIDMaterializandoClasses(int IdRef)
        {
            if (IdRef != 0)
            {
                RECOMENDACAO recomendacaoEncontrada = ControleDeRecomendacao.BuscarRecomendacaoProID(IdRef);
                return InjetarEmUsuarioModel(recomendacaoEncontrada, true);
            }
            else
                return null;
        }

        internal static RecomendacaoModel SalvarRecomendacao(FormCollection form)
        {
            RecomendacaoModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            RECOMENDACAO cargoDAO = InjetarEmUsuarioDAO(usuarioModel);
            cargoDAO = ControleDeRecomendacao.SalvarRecomendacao(cargoDAO);

            usuarioModel = InjetarEmUsuarioModel(cargoDAO, true);

            return usuarioModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static RECOMENDACAO InjetarEmUsuarioDAO(RecomendacaoModel x)
        {
            if (x == null)
                return null;
            else
                return new RECOMENDACAO()
                {
                    IDCGO = x.Cargo.IdCargo,
                    IDCLI = x.Cliente.IdCliente,
                    IDREC = x.IdRecomendacao,
                    IDSETOR = x.Setor.IdSetor
                };
        }

        private static RecomendacaoModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new RecomendacaoModel()
            {
                Cargo = CadastroDeCargo.RecuperarCargoPorID(string.IsNullOrEmpty(form["idCargo"]) ? 0 : Convert.ToInt32(form["idCargo"])),
                Cliente = CadastroDeClientes.RecuperarClientePorID(string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"])),
                IdRecomendacao = string.IsNullOrEmpty(form["codigoRecomendacao"]) ? 0 : Convert.ToInt32(form["codigoRecomendacao"]),
                Setor = CadastroDeSetor.RecuperarSetorPorID(string.IsNullOrEmpty(form["idSetor"]) ? 0 : Convert.ToInt32(form["idSetor"]))
            };
        }

        private static Dictionary<ReferenteModel, List<ProcedimentoModel>> RecuperarReferenciasEProcedimentosDeRecomendacao(decimal IdRec)
        {
            Dictionary<MOVIMENTO_REFERENTE, List<PROCEDIMENTO>> ReferenciasProcedimentos = ControleDeRecomendacao.RecuperarReferenciasProcedimentosDeRecomendacao(IdRec);
            Dictionary<ReferenteModel, List<ProcedimentoModel>> ReferenciasProcedimentosTratados = new Dictionary<ReferenteModel, List<ProcedimentoModel>>();

            foreach (var item in ReferenciasProcedimentos)
            {
                List<ProcedimentoModel> procedimentos = new List<ProcedimentoModel>();

                item.Value.ForEach(x =>
                {
                    procedimentos.Add(CadastroDeProcedimentos.injetarEmUsuarioModel(x));
                });

                ReferenciasProcedimentosTratados.Add(CadastroDeReferente.InjetarEmUsuarioModel(item.Key), procedimentos);
            }

            return ReferenciasProcedimentosTratados;
        }

        #endregion Private Methods
    }
}
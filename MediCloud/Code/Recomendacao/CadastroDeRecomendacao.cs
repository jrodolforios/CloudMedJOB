using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Recomendacao;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Recomendacao;
using MediCloud.Code.Clientes;
using MediCloud.Models.Cliente;
using MediCloud.Code.Parametro.GrupoProcedimento;
using MediCloud.Controllers;
using MediCloud.Models.Parametro.GrupoProcedimento;

namespace MediCloud.Code.Recomendacao
{
    public class CadastroDeRecomendacao
    {
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
                    Setor = materializarClasses ? CadastroDeSetor.buscarSetorPorID((int)x.IDSETOR) : new SetorModel() { IdSetor = (int)x.IDSETOR},

                    ReferenciasProcedimentos = RecuperarReferenciasEProcedimentosDeRecomendacao(x.IDREC)
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

        internal static void DeletarProcedimentoDeRecomendacao(int codigoRecomendacao, int codigoReferencia, int codigoprocedimento)
        {
            ControleDeRecomendacao.DeletarProcedimento(codigoRecomendacao, codigoReferencia, codigoprocedimento);
        }

        internal static void DeletarRecomendacao(RecomendacaoController recomendacaoController, int codigoDaRecomendacao)
        {
            ControleDeRecomendacao.DeletarRecomendacao(codigoDaRecomendacao);
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

        internal static void DeletarRiscoDeRecomendacao(int codigoDoRecomendacao, int codigoRisco)
        {
            ControleDeRecomendacao.DeletarRisco(codigoDoRecomendacao, codigoRisco);
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

        internal static void DeletarReferencia(int codigoRecomendacao, int codigoReferencia)
        {
            ControleDeRecomendacao.DeletarReferenciaDeRecomendacao(codigoRecomendacao, codigoReferencia);
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

        internal static void AdicionarRisco(int codigoRecomendacao, int codigoRisco)
        {
            ControleDeRecomendacao.AdicionarRisco(codigoRecomendacao, codigoRisco);
        }

        internal static void AdicionarProcedimento(int codigoRecomendacao, int codigoProcedimento, int codigoReferente)
        {
            ControleDeRecomendacao.AdicionarProcedimento(codigoRecomendacao, codigoProcedimento, codigoReferente);
        }

        internal static void AdicionarReferencia(int codigoRecomendacao, int codigoReferencia)
        {
            ControleDeRecomendacao.AdicionarReferencia(codigoRecomendacao, codigoReferencia);
        }
    }
}
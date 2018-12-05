using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Cliente;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Cliente;
using MediCloud.Code.Financeiro;
using MediCloud.Code.Funcionario;
using MediCloud.Code.Recomendacao;
using MediCloud.Code.Parametro;
using MediCloud.Controllers;
using MediCloud.Models.Seguranca;

namespace MediCloud.Code.Clientes
{
    public class CadastroDeASO
    {
        internal static List<ASOModel> buscarASO(FormCollection form)
        {
            string termo = form["keywords"];
            List<ASOModel> listaDeModels = new List<ASOModel>();

            List<MOVIMENTO> usuarioDoBanco = ControleDeASO.buscarASO(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x, false));
            });

            return listaDeModels;
        }

        internal static List<MOVIMENTO> buscarASOMOV(FormCollection form)
        {
            string termo = form["keywords"];

            List<MOVIMENTO> usuarioDoBanco = ControleDeASO.buscarASO(termo);

            return usuarioDoBanco;
        }

        internal static List<ASOModel> UltimosASOS()
        {
            List<ASOModel> listaDeModels = new List<ASOModel>();

            List<MOVIMENTO> usuarioDoBanco = ControleDeASO.UltimosASOS();

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x, false));
            });

            return listaDeModels;
        }

        internal static Dictionary<decimal, int> GraficoASOs()
        {
            return ControleDeASO.GraficoASOs();
        }

        internal static int ContagemASOsNoMes()
        {
            return ControleDeASO.ContagemASOsNoMes();
        }

        internal static int ContagemDeASOsNaoFaturados()
        {
            return ControleDeASO.ContagemDeASOsNaoFaturados();
        }

        public static ASOModel injetarEmUsuarioModel(MOVIMENTO x, bool carregarClasses = true)
        {
            if (x == null)
                return null;
            else
                return new ASOModel()
                {
                    Cargo = CadastroDeCargo.RecuperarCargoPorID((int)x.IDCGO),
                    Cliente = CadastroDeClientes.RecuperarClientePorID((int)x.IDCLI, carregarClasses),
                    Data = x.DATA,
                    FormaPagamento = carregarClasses ? CadastroFormaPagamento.RecuperarFormaPagamentoPorID((int)x.IDFORPAG) : new Models.Financeiro.FormaPagamentoModel() {IdFormaPagamento = (int)x.IDFORPAG },
                    Funcionario = CadastroDeFuncionario.RecuperarFuncionarioPorID((int)x.IDFUN),
                    IdASO = (int)x.IDMOV,
                    Observacao = x.OBSERVACAO,
                    Referente = CadastroDeReferente.RecuperarReferentePorID((int)x.IDREF),
                    Setor = carregarClasses ? CadastroDeSetor.RecuperarSetorPorID((int)x.IDSETOR) : new Models.Recomendacao.SetorModel() {IdSetor = (int)x.IDSETOR },
                    Tabela = carregarClasses ? CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID((int)x.IDTAB, false) : new Models.Parametro.GrupoProcedimento.TabelaPrecoModel() { IdTabela = (int)x.IDTAB },
                    Status = x.STATUS,
                    Usuario = x.USUARIO,
                    CaixaPendente = x.CAIXAPENDENTE.HasValue ? x.CAIXAPENDENTE.Value : false,
                    IdFechamentoCaixa = x.IDFCX,
                    Faturamento = carregarClasses ? CadastroDeFaturamento.RecuperarFaturamentoPorID(x.IDFAT, false) : (x.IDFAT.HasValue ? new Models.Financeiro.FaturamentoModel() { IdFaturamento = (int)x.IDFAT} : new Models.Financeiro.FaturamentoModel()),

                    ProcedimentosMovimento = carregarClasses ? CadastroDeProcedimentosMovimento.BuscarProcedimentoDeMovimentoPorIDASO((int)x.IDMOV) : new List<ProcedimentoMovimentoModel>(),

                    AnexosMovimento = CarregarArquivosDeASOSemBinarios(x.IDMOV)

                };
        }

        internal static ASOModel AtualizarProcedimentos(ASOModel model)
        {
            model.ProcedimentosMovimento = CadastroDeProcedimentosMovimento.BuscarProcedimentoDeMovimentoPorIDASO(model.IdASO);

            return model;
        }

        private static List<ArquivoMovimentoModel> CarregarArquivosDeASOSemBinarios(decimal iDMOV)
        {
            List<ArquivoMovimentoModel> listaDeModels = new List<ArquivoMovimentoModel>();

            List<MOVIMENTO_ARQUIVOS> usuarioDoBanco = ControleDeASO.CarregarArquivosSemBinarios(iDMOV);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModelArquivoComBinarios(x));
            });

            return listaDeModels;
        }

        private static ArquivoMovimentoModel injetarEmUsuarioModelArquivoComBinarios(MOVIMENTO_ARQUIVOS x)
        {
            if (x == null)
                return null;
            else
                return new ArquivoMovimentoModel()
                {
                    Arquivo = x.ARQUIVO,
                    DataEnvio = x.DATAENVIO,
                    IdArquivo = (int)x.IDARQUIVO,
                    Movimento = new ASOModel() { IdASO = (int)x.IDMOV},
                    NomeArquivo = x.NOMEARQUIVO
                };
        }

        internal static void MarcarComoEntregue(ASOController aSOController, int codigoASO)
        {
            ControleDeASO.MarcarASOComoEntregue(codigoASO);
        }

        private static ArquivoMovimentoModel injetarEmUsuarioModelArquivo(MOVIMENTO_ARQUIVOS x)
        {
            if (x == null)
                return null;
            else
                return new ArquivoMovimentoModel()
                {
                    Arquivo = null,
                    DataEnvio = x.DATAENVIO,
                    IdArquivo = (int)x.IDARQUIVO,
                    Movimento = new ASOModel() { IdASO = (int)x.IDMOV },
                    NomeArquivo = x.NOMEARQUIVO
                };
        }

        internal static ASOModel RecuperarASOPorID(int idASO, bool materializarClassesDoMovimento = true)
        {

            MOVIMENTO ASOEncontrada = ControleDeASO.buscarASOPorId(idASO);

            return injetarEmUsuarioModel(ASOEncontrada, materializarClassesDoMovimento);
        }

        internal static MOVIMENTO RecuperarASOPorIDMOV(int idASO)
        {

            MOVIMENTO ASOEncontrada = ControleDeASO.buscarASOPorId(idASO);

            return ASOEncontrada;
        }

        internal static ASOModel SalvarASO(FormCollection form, bool gerarProcedimentosAutomaticamente = false)
        {
            ASOModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            MOVIMENTO ASODAO = injetarEmUsuarioDAO(usuarioModel);
            ASODAO = ControleDeASO.SalvarASO(ASODAO);

            if(gerarProcedimentosAutomaticamente)
            {
                ControleDeASO.CriarProcedimentosAPartirDeRecomendacao((int)ASODAO.IDMOV);
            }

            usuarioModel = injetarEmUsuarioModel(ASODAO);

            return usuarioModel;
        }

        internal static MOVIMENTO SalvarASOMOV(FormCollection form, bool gerarProcedimentosAutomaticamente = false)
        {
            ASOModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            MOVIMENTO ASODAO = injetarEmUsuarioDAO(usuarioModel);
            ASODAO = ControleDeASO.SalvarASO(ASODAO);

            if (gerarProcedimentosAutomaticamente)
            {
                ControleDeASO.CriarProcedimentosAPartirDeRecomendacao((int)ASODAO.IDMOV);
            }

            return ASODAO;
        }

        private static MOVIMENTO injetarEmUsuarioDAO(ASOModel x)
        {
            if (x == null)
                return null;
            else
                return new MOVIMENTO()
                {
                    DATA = x.Data.Value,
                    IDCGO = x.Cargo.IdCargo,
                    IDCLI = x.Cliente.IdCliente,
                    IDFORPAG = x.FormaPagamento.IdFormaPagamento,
                    IDFUN = x.Funcionario.IdFuncionario,
                    IDMOV = x.IdASO,
                    IDREF = x.Referente.IdReferencia,
                    IDSETOR = x.Setor.IdSetor,
                    IDTAB = x.Tabela.IdTabela,
                    OBSERVACAO = x.Observacao,
                    STATUS = x.Status,
                    USUARIO = x.Usuario,
                    CAIXAPENDENTE = x.CaixaPendente,
                    IDFCX = x.IdFechamentoCaixa,
                    IDFAT = x.Faturamento?.IdFaturamento,


                    TIPO = "ASO",
                    FATURA = (decimal?)0.00, //No banco está sempre guardando este valor.
                    DATAMOV = DateTime.Now //Sempre está guardando a data do momento da criação do registro no Banco
                };
        }


        private static ASOModel injetarEmUsuarioModel(FormCollection form)
        {
            return new ASOModel()
            {
                Cargo = CadastroDeCargo.RecuperarCargoPorID(string.IsNullOrEmpty(form["idCargo"]) ? 0 : Convert.ToInt32(form["idCargo"])),
                Cliente = CadastroDeClientes.RecuperarClientePorID(string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"])),
                Data = string.IsNullOrEmpty(form["data"]) ? null : (DateTime?)Convert.ToDateTime(form["data"]),
                FormaPagamento = CadastroFormaPagamento.RecuperarFormaPagamentoPorID(string.IsNullOrEmpty(form["formaPagamento"]) ? 0 : Convert.ToInt32(form["formaPagamento"])),
                Funcionario = CadastroDeFuncionario.RecuperarFuncionarioPorID(string.IsNullOrEmpty(form["idFuncionario"]) ? 0 : Convert.ToInt32(form["idFuncionario"])),
                IdASO = string.IsNullOrEmpty(form["codigoASO"]) ? 0 : Convert.ToInt32(form["codigoASO"]),
                Observacao = string.IsNullOrEmpty(form["observacoes"]) ? null : form["observacoes"],
                Referente = CadastroDeReferente.RecuperarReferentePorID(string.IsNullOrEmpty(form["referente"]) ? 0 : Convert.ToInt32(form["referente"])),
                Setor = CadastroDeSetor.RecuperarSetorPorID(string.IsNullOrEmpty(form["idSetor"]) ? 0 : Convert.ToInt32(form["idSetor"])),
                Status = string.IsNullOrEmpty(form["entregue"]) ? "PENDENTE" : (Convert.ToBoolean(form["entregue"].ToLower() == "on") ? "ENTREGUE" : "PENDENTE"),
                Tabela = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID(string.IsNullOrEmpty(form["tabela"]) ? 0 : Convert.ToInt32(form["tabela"])),
                Usuario = string.IsNullOrEmpty(form["usuario"]) ? null : form["usuario"],
                CaixaPendente = string.IsNullOrEmpty(form["caixaPendente"]) ? false : Convert.ToBoolean(form["caixaPendente"]),
                IdFechamentoCaixa = string.IsNullOrEmpty(form["fechamentoCaixa"]) ? null : (int?)Convert.ToInt32(form["fechamentoCaixa"]),
                Faturamento = CadastroDeFaturamento.RecuperarFaturamentoPorID(string.IsNullOrEmpty(form["faturamento"]) ? 0 : Convert.ToInt32(form["faturamento"])),

                AnexosMovimento = new List<ArquivoMovimentoModel>(),
                ProcedimentosMovimento = new List<ProcedimentoMovimentoModel>()
            };
        }

        internal static void uploadDeArquivo(byte[] fileData, string fileName, int codigoASO)
        {
            ControleDeASO.SalvarArquivo(fileData, fileName, codigoASO);
        }

        internal static ArquivoMovimentoModel downloadDeArquivo(int codigoArquivo)
        {
            return injetarEmUsuarioModelArquivoComBinarios(ControleDeASO.recuperarBinarioDeArquivo(codigoArquivo));
        }

        internal static void DeletarArquivoMovimento(ASOController aSOController, int codigoArquivo)
        {
            ControleDeASO.DeletarArquivo(codigoArquivo);
        }

        internal static byte[] ImprimirASOComMedCoord(int codigoASO)
        {
            return ControleDeASO.ImprimirASOComMedCoord(codigoASO);
        }

        internal static byte[] ImprimirReciboASO(int codigoASO)
        {
            return ControleDeASO.ImprimirReciboASO(codigoASO);
        }

        internal static byte[] ImprimirASOSemMedCoord(int codigoASO)
        {
            return ControleDeASO.ImprimirASOSemMedCoord(codigoASO);
        }

        internal static byte[] ImprimirListaDeProcedimentos(int codigoASO)
        {
            return ControleDeASO.ImprimirListaDeProcedimentos(codigoASO);
        }

        internal static byte[] ImprimirFichaClinica(int codigoASO)
        {
            return ControleDeASO.ImprimirFichaClinica(codigoASO);
        }

        internal static void ConfirmarExame(SessaoUsuarioModel currentUser, int codigoDoProcedimentoMovimento)
        {
            ControleDeProcedimentosMovimento.ConfirmarExame(currentUser.login, codigoDoProcedimentoMovimento);
        }

        internal static void ConfirmarASO(SessaoUsuarioModel currentUser, int codigoDoMovimento)
        {
            ControleDeASO.ConfirmarASO(currentUser.login, codigoDoMovimento);
        }

        internal static byte[] ImprimirOrdemDeServico(int codigoASO)
        {
            return ControleDeASO.ImprimirOrdemDeServico(codigoASO);
        }
    }
}
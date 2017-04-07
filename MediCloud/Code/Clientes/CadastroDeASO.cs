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

namespace MediCloud.Code.Clientes
{
    public class CadastroDeASO
    {
        internal static List<ASOModel> buscarCargo(FormCollection form)
        {
            string termo = form["keywords"];
            List<ASOModel> listaDeModels = new List<ASOModel>();

            List<MOVIMENTO> usuarioDoBanco = ControleDeASO.buscarCliente(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        private static ASOModel injetarEmUsuarioModel(MOVIMENTO x)
        {
            if (x == null)
                return null;
            else
                return new ASOModel()
                {
                    Cargo = CadastroDeCargo.RecuperarCargoPorID((int)x.IDCGO),
                    Cliente = CadastroDeClientes.RecuperarClientePorID((int)x.IDCLI),
                    Data = x.DATA,
                    FormaPagamento = CadastroFormaPagamento.RecuperarFormaPagamentoPorID((int)x.IDFORPAG),
                    Funcionario = CadastroDeFuncionario.RecuperarFuncionarioPorID((int)x.IDFUN),
                    IdASO = (int)x.IDMOV,
                    Observacao = x.OBSERVACAO,
                    Referente = CadastroDeReferente.RecuperarReferentePorID((int)x.IDREF),
                    Setor = CadastroDeSetor.RecuperarSetorPorID((int)x.IDSETOR),
                    Tabela = CadastroDeTabelaDePreco.RecuperarTabelaDePrecoPorID((int)x.IDTAB),
                    Status = x.STATUS,
                    Usuario = x.USUARIO,
                    CaixaPendente = x.CAIXAPENDENTE.HasValue ? x.CAIXAPENDENTE.Value : false,
                    IdFechamentoCaixa = x.IDFCX,
                    Faturamento = CadastroDeFaturamento.RecuperarFaturamentoPorID(x.IDFAT),

                    AnexosMovimento = new List<object>(),
                    ProcedimentosMovimento = new List<object>()

                };
        }

        internal static ASOModel RecuperarASOPorID(int idASO)
        {

            MOVIMENTO ASOEncontrada = ControleDeASO.buscarASOPorId(idASO);

            return injetarEmUsuarioModel(ASOEncontrada);
        }

        internal static ASOModel SalvarASO(FormCollection form)
        {
            ASOModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            MOVIMENTO ASODAO = injetarEmUsuarioDAO(usuarioModel);
            ASODAO = ControleDeASO.SalvarASO(ASODAO);

            usuarioModel = injetarEmUsuarioModel(ASODAO);

            return usuarioModel;
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

                AnexosMovimento = new List<object>(),
                ProcedimentosMovimento = new List<object>()
            };
        }
    }
}
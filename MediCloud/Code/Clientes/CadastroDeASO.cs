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
                    ProcedimentosMovimento = new List<object>()
                    
                };
        }

        internal static ASOModel RecuperarASOPorID(int idASO)
        {

            MOVIMENTO ASOEncontrada = ControleDeASO.buscarASOPorId(idASO);

            return injetarEmUsuarioModel(ASOEncontrada);
        }
    }
}
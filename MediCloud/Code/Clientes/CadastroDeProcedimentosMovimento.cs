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

        private static ProcedimentoMovimentoModel injetarEmUsuarioModel(MOVIMENTO_PROCEDIMENTO x)
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
                    Movimento = new ASOModel() { IdASO = (int)x.IDMOV},
                    Total = x.TOTAL,
                    Usuario = x.USUARIO,
                    UsuarioRealizado = x.USUARIOREALIZADO,
                    Valor = x.VALOR,
                    observacao = x.OBSMOVTO,

                    Faturamento = CadastroDeFaturamento.RecuperarFaturamentoPorID(x.IDFAT),
                    Fornecedor = CadastroDeFornecedor.RecuperarFornecedorPorID(x.IDFOR),
                    Procedimento = CadastroDeProcedimentos.RecuperarProcedimentoPorID((int)(x.IDPRO.HasValue ? x.IDPRO.Value : 0)),
                    Profissional = CadastroDeProfissional.GetProfissionalPorID(x.IDPRF)

                };
        }

        internal static void DeletarProcedimentoMovimento(ASOController aSOController, int codigoProcedimento)
        {
            ControleDeProcedimentosMovimento.DeletarProcedimento(codigoProcedimento);
        }
    }
}
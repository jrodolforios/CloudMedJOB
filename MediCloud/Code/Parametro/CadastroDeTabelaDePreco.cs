using MediCloud.BusinessProcess.Parametro;
using MediCloud.BusinessProcess.Recomendacao;
using MediCloud.Code.Enum;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.Models.Recomendacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Controllers;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeTabelaDePreco
    {
        internal static TabelaPrecoModel RecuperarTabelaDePrecoPorID(int IdRef)
        {
            if (IdRef != 0)
            {
                TABELA referenteEncontrado = ControleDeTabelaPreco.buscarTabelaPorID(IdRef);
                return injetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        internal static List<TabelaPrecoModel> RecuperarTabelaDePrecoPorTermo(FormCollection form)
        {
            string termo = form["keywords"];
            List<TabelaPrecoModel> listaDeModels = new List<TabelaPrecoModel>();

            List<TABELA> usuarioDoBanco = ControleDeTabelaPreco.buscarTabelaPorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        private static TabelaPrecoModel injetarEmUsuarioModel(TABELA referenteEncontrado)
        {
            if (referenteEncontrado == null)
                return null;
            else
                return new TabelaPrecoModel()
                {
                    IdTabela = (int)referenteEncontrado.IDTAB,
                    NomeTabela = referenteEncontrado.TABELA1,
                    TipoPagamento = getEnumPorString(referenteEncontrado.TIPOPAGTO),
                    Status = referenteEncontrado.STATUS == "A"                    
                };
        }

        private static EnumFinanceiro.TipoPagamento getEnumPorString(string TIpoPagamento)
        {
            switch (TIpoPagamento)
            {
                case "V":
                    return EnumFinanceiro.TipoPagamento.AVista;
                case "P":
                    return EnumFinanceiro.TipoPagamento.APrazo;
                default:
                    return EnumFinanceiro.TipoPagamento.Vazio;
            }
        }

        internal static void DeletarTabelaDePreco(TabelaDePrecoController tabelaDePrecoController, int codigoTabelaDePreco)
        {
            ControleDeTabelaPreco.DeletarTabelaDePreco(codigoTabelaDePreco);
        }

        private static string getStringPorEnum(EnumFinanceiro.TipoPagamento TIpoPagamento)
        {
            switch (TIpoPagamento)
            {
                case EnumFinanceiro.TipoPagamento.AVista:
                    return "V";
                case EnumFinanceiro.TipoPagamento.APrazo:
                    return "P";
                default:
                    return null;
            }
        }

        internal static List<TabelaPrecoModel> RecuperarTodos()
        {
            List<TABELA> referenteEncontrado = ControleDeTabelaPreco.RecuperarTodos();

            List<TabelaPrecoModel> encontrados = new List<TabelaPrecoModel>();

            referenteEncontrado.ForEach(x =>
            {
                encontrados.Add(injetarEmUsuarioModel(x));
            });

            return encontrados;
        }

        internal static TABELA injetarEmUsuarioDAO(TabelaPrecoModel x)
        {
            if (x == null)
                return null;
            else
                return new TABELA()
                {
                    IDTAB = x.IdTabela,
                    TABELA1 = x.NomeTabela,
                    STATUS = x.Status ? "A" : "I",
                    TIPOPAGTO = getStringPorEnum(x.TipoPagamento)
                    
                };
        }

        internal static TabelaPrecoModel SalvarTabela(FormCollection form)
        {
            TabelaPrecoModel usuarioModel = injetarEmUsuarioModel(form);
            usuarioModel.validar();

            TABELA tabelaDePrecoDAO = injetarEmUsuarioDAO(usuarioModel);
            tabelaDePrecoDAO = ControleDeTabelaPreco.SalvarTabela(tabelaDePrecoDAO);

            usuarioModel = injetarEmUsuarioModel(tabelaDePrecoDAO);

            return usuarioModel;
        }

        private static TabelaPrecoModel injetarEmUsuarioModel(FormCollection form)
        {
            return new TabelaPrecoModel()
            {
                IdTabela = string.IsNullOrEmpty(form["idTabela"]) ? 0 : Convert.ToInt32(form["idTabela"]),
                NomeTabela = string.IsNullOrEmpty(form["nomeTabela"]) ? null : form["nomeTabela"],
                TipoPagamento = string.IsNullOrEmpty(form["tipoPagamento"]) ? EnumFinanceiro.TipoPagamento.Vazio : (EnumFinanceiro.TipoPagamento)Convert.ToInt32(form["tipoPagamento"]),
                Status = true
            };
        }

    }
}
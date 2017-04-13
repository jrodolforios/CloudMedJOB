﻿using MediCloud.BusinessProcess.Parametro;
using MediCloud.BusinessProcess.Recomendacao;
using MediCloud.Code.Enum;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro;
using MediCloud.Models.Recomendacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeTabelaDePreco
    {
        internal static TabelaPrecoModel RecuperarTabelaDePrecoPorID(int IdRef)
        {
            if (IdRef != 0)
            {
                TABELA referenteEncontrado = ControleDeTabelaPreco.buscarSetorPorID(IdRef);
                return injetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
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
            switch (TIpoPagamento.ToUpper())
            {
                case "V":
                    return EnumFinanceiro.TipoPagamento.AVista;
                case "P":
                    return EnumFinanceiro.TipoPagamento.APrazo;
                default:
                    return EnumFinanceiro.TipoPagamento.Nenhum;
            }
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
    }
}
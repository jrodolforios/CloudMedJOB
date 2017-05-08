using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.Models.Financeiro;
using MediCloud.DatabaseModels;
using MediCloud.Code.Enum;

namespace MediCloud.Code.Financeiro
{
    public class CadastroFormaPagamento
    {
        internal static FormaPagamentoModel RecuperarFormaPagamentoPorID(int IdFormPag)
        {
            if (IdFormPag != 0)
            {
                FORMADEPAGAMENTO usuarioencontrado = ControleDeFormaDePagamento.buscarFormaDePagamento(IdFormPag);
                return injetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        private static FormaPagamentoModel injetarEmUsuarioModel(FORMADEPAGAMENTO x)
        {
            if (x == null)
                return null;
            else
                return new FormaPagamentoModel()
                {
                    IdFormaPagamento = (int)x.IDFORPAG,
                    NomeFormaPagamento = x.FORMADEPAGAMENTO1,
                    TipoPagamento = getEnumPorString(x.TIPOPAGTO)
                };
        }

        private static EnumFinanceiro.TipoPagamento getEnumPorString(string TIpoPagamento)
        {
            switch(TIpoPagamento.ToUpper())
            {
                case "V":
                    return EnumFinanceiro.TipoPagamento.AVista;
                case "P":
                    return EnumFinanceiro.TipoPagamento.APrazo;
                default:
                    return EnumFinanceiro.TipoPagamento.Vazio;
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

        internal static List<FormaPagamentoModel> RecuperarTodos()
        {
            List<FORMADEPAGAMENTO> referenteEncontrado = ControleDeFormaDePagamento.RecuperarTodos();

            List<FormaPagamentoModel> encontrados = new List<FormaPagamentoModel>();

            referenteEncontrado.ForEach(x =>
            {
                encontrados.Add(injetarEmUsuarioModel(x));
            });

            return encontrados;
        }

        internal static FORMADEPAGAMENTO injetarEmUsuarioDAO(FormaPagamentoModel x)
        {
            if (x == null)
                return null;
            else
                return new FORMADEPAGAMENTO()
                {
                    FORMADEPAGAMENTO1 = x.NomeFormaPagamento,
                    IDFORPAG = x.IdFormaPagamento,
                    TIPOPAGTO = getStringPorEnum(x.TipoPagamento)
                };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.BusinessProcess.Financeiro;
using MediCloud.Models.Financeiro;
using MediCloud.DatabaseModels;
using MediCloud.Code.Enum;
using System.Web.Mvc;
using MediCloud.Controllers;

namespace MediCloud.Code.Financeiro
{
    public class CadastroFormaPagamento
    {
        internal static FormaPagamentoModel RecuperarFormaPagamentoPorID(int IdFormPag)
        {
            if (IdFormPag != 0)
            {
                FORMADEPAGAMENTO usuarioencontrado = ControleDeFormaDePagamento.buscarFormaDePagamento(IdFormPag);
                return InjetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        private static FormaPagamentoModel InjetarEmUsuarioModel(FORMADEPAGAMENTO x)
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

        internal static List<FormaPagamentoModel> RecuperarFormaPagamentoPorTermo(FormCollection form) 
        {
            string prefix = form["keywords"];
            return RecuperarFormaPagamentoPorTermo(prefix);
        }

        internal static List<FormaPagamentoModel> RecuperarFormaPagamentoPorTermo(string prefix)
        {
            List<FORMADEPAGAMENTO> formasEncotnradas = ControleDeFormaDePagamento.RecuperarFormaDePagamentoPorTermo(prefix);
            List<FormaPagamentoModel> resultados = new List<FormaPagamentoModel>();

            formasEncotnradas.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
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

        internal static void DeletarFormaPagamento(FormaPagamentoController formaPagamentoController, int codigoFormaPagamento)
        {
            ControleDeFormaDePagamento.DeletarFormaPagamento(codigoFormaPagamento);
        }

        internal static List<FormaPagamentoModel> RecuperarTodos()
        {
            List<FORMADEPAGAMENTO> referenteEncontrado = ControleDeFormaDePagamento.RecuperarTodos();

            List<FormaPagamentoModel> encontrados = new List<FormaPagamentoModel>();

            referenteEncontrado.ForEach(x =>
            {
                encontrados.Add(InjetarEmUsuarioModel(x));
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

        internal static FormaPagamentoModel SalvarFormaPagamento(FormCollection form)
        {
            FormaPagamentoModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            FORMADEPAGAMENTO formaPagamentoDAO = InjetarEmUsuarioDAO(usuarioModel);
            formaPagamentoDAO = ControleDeFormaDePagamento.SalvarFormaPagamento(formaPagamentoDAO);

            usuarioModel = InjetarEmUsuarioModel(formaPagamentoDAO);

            return usuarioModel;
        }

        private static FORMADEPAGAMENTO InjetarEmUsuarioDAO(FormaPagamentoModel x)
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

        private static FormaPagamentoModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new FormaPagamentoModel()
            {
                IdFormaPagamento = string.IsNullOrEmpty(form["codigoFormaPagamento"]) ? 0 : Convert.ToInt32(form["codigoFormaPagamento"]),
                NomeFormaPagamento = string.IsNullOrEmpty(form["nomeFormaPagamento"]) ? null : form["nomeFormaPagamento"],
                TipoPagamento = string.IsNullOrEmpty(form["tipoPagamento"]) ? EnumFinanceiro.TipoPagamento.Vazio : (EnumFinanceiro.TipoPagamento)Convert.ToInt32(form["tipoPagamento"])
            };
        }
    }
}
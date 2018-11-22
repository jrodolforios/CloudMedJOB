using MediCloud.BusinessProcess.Parametro;
using MediCloud.Code.Enum;
using MediCloud.Code.Fornecedor;
using MediCloud.Code.Parametro.GrupoProcedimento;
using MediCloud.Controllers;
using MediCloud.DatabaseModels;
using MediCloud.Models.Parametro.GrupoProcedimento;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeTabelaDePreco
    {
        #region Internal Methods

        internal static List<TabelaPrecoModel> BuscarTabelasDeCliente(int idCliente)
        {
            List<TABELA> referenteEncontrado = ControleDeTabelaPreco.RecuperarTabelasDeCLiente(idCliente);

            List<TabelaPrecoModel> encontrados = new List<TabelaPrecoModel>();

            referenteEncontrado.ForEach(x =>
            {
                encontrados.Add(injetarEmUsuarioModel(x, false));
            });

            return encontrados;
        }

        internal static ValorTabelaDePrecoModel buscarValorDeTabela(int codigoDoValorTabela)
        {
            TABELAXFORNECEDORXPROCEDIMENTO valorTabela = ControleDeTabelaPreco.buscarValorDeTabela(codigoDoValorTabela);

            return injetarEmValoresModel(valorTabela);
        }

        internal static void DeletarTabelaDePreco(TabelaDePrecoController tabelaDePrecoController, int codigoTabelaDePreco)
        {
            ControleDeTabelaPreco.DeletarTabelaDePreco(codigoTabelaDePreco);
        }

        internal static void DeletarValorTabela(int codigoValorTabela)
        {
            ControleDeTabelaPreco.DeletarValorTabela(codigoValorTabela);
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

        internal static TabelaPrecoModel RecuperarTabelaDePrecoPorID(int IdRef, bool carregarLista = true)
        {
            if (IdRef != 0)
            {
                TABELA referenteEncontrado = ControleDeTabelaPreco.buscarTabelaPorID(IdRef);
                return injetarEmUsuarioModel(referenteEncontrado, carregarLista);
            }
            else
                return null;
        }

        internal static List<TabelaPrecoModel> RecuperarTabelaDePrecoPorTermo(string prefix)
        {
            List<TabelaPrecoModel> listaDeModels = new List<TabelaPrecoModel>();

            List<TABELA> usuarioDoBanco = ControleDeTabelaPreco.buscarTabelaPorTermo(prefix);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(injetarEmUsuarioModel(x, false));
            });

            return listaDeModels;
        }

        internal static List<TabelaPrecoModel> RecuperarTabelaDePrecoPorTermo(FormCollection form)
        {
            string termo = form["keywords"];

            return RecuperarTabelaDePrecoPorTermo(termo);
        }

        internal static List<TabelaPrecoModel> RecuperarTodos()
        {
            List<TABELA> referenteEncontrado = ControleDeTabelaPreco.RecuperarTodos();

            List<TabelaPrecoModel> encontrados = new List<TabelaPrecoModel>();

            referenteEncontrado.ForEach(x =>
            {
                encontrados.Add(injetarEmUsuarioModel(x, false));
            });

            return encontrados;
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

        internal static ValorTabelaDePrecoModel SalvarValorTabela(FormCollection form)
        {
            ValorTabelaDePrecoModel valorTabelaModel = InjetarEmValorTabelaModel(form);
            valorTabelaModel.validar();

            TABELAXFORNECEDORXPROCEDIMENTO tabelaDePrecoDAO = injetarEmValorTabelaDAO(valorTabelaModel);
            tabelaDePrecoDAO = ControleDeTabelaPreco.SalvarValorTabela(tabelaDePrecoDAO);

            valorTabelaModel = injetarEmValoresModel(tabelaDePrecoDAO);

            return valorTabelaModel;
        }

        #endregion Internal Methods



        #region Private Methods

        private static List<TabelaFornecedorModel> BuscarFornecedorDeTabela(decimal idTab)
        {
            List<TabelaFornecedorModel> listaDeModels = new List<TabelaFornecedorModel>();

            List<TABELAXFORNECEDORXPROCEDIMENTO> tabelaFornecedorEncontrado = ControleDeTabelaPreco.buscarTabelaFornecedorPorIDTabela(idTab);

            tabelaFornecedorEncontrado.ForEach(x =>
            {
                listaDeModels.Add(injetarEmTabelaFornecedorModel(x));
            });

            return listaDeModels;
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

        private static TabelaFornecedorModel injetarEmTabelaFornecedorModel(TABELAXFORNECEDORXPROCEDIMENTO x, bool carregarClasses = false)
        {
            if (x == null)
                return null;
            else
                return new TabelaFornecedorModel()
                {
                    Faturamento = x.FATURAMENTO,
                    Fornecedor = CadastroDeFornecedor.RecuperarFornecedorPorID(x.IDFOR),
                    Procedimento = CadastroDeProcedimentos.RecuperarProcedimentoPorID((int)x.IDPRO),
                    Tabela = carregarClasses ? RecuperarTabelaDePrecoPorID((int)x.IDTAB) : new TabelaPrecoModel() { IdTabela = (int)x.IDTAB }
                };
        }

        private static TabelaPrecoModel injetarEmUsuarioModel(TABELA tabelaEncontrada, bool materializarClasses = true)
        {
            if (tabelaEncontrada == null)
                return null;
            else
                return new TabelaPrecoModel()
                {
                    IdTabela = (int)tabelaEncontrada.IDTAB,
                    NomeTabela = tabelaEncontrada.TABELA1,
                    TipoPagamento = getEnumPorString(tabelaEncontrada.TIPOPAGTO),
                    Status = tabelaEncontrada.STATUS == "A",

                    ValorTabelaPreco = materializarClasses ? recuperarValoresTabelaDePreco((int)tabelaEncontrada.IDTAB) : new List<ValorTabelaDePrecoModel>()
                };
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

        private static ValorTabelaDePrecoModel injetarEmValoresModel(TABELAXFORNECEDORXPROCEDIMENTO x)
        {
            if (x == null)
                return null;
            else
                return new ValorTabelaDePrecoModel()
                {
                    Fornecedor = new Models.Fornecedor.FornecedorModel() { IdFornecedor = (int)x.IDFOR, RazaoSocial = x.FORNECEDOR.RAZAOSOCIAL },
                    Procedimento = new ProcedimentoModel() { IdProcedimento = (int)x.IDPRO, Nome = x.PROCEDIMENTO.PROCEDIMENTO1 },
                    Tabela = new TabelaPrecoModel() { IdTabela = (int)x.IDTAB },
                    Valor = x.FATURAMENTO
                };
        }

        private static TABELAXFORNECEDORXPROCEDIMENTO injetarEmValorTabelaDAO(ValorTabelaDePrecoModel valorTabelaModel)
        {
            if (valorTabelaModel == null)
                return null;
            else
                return new TABELAXFORNECEDORXPROCEDIMENTO()
                {
                    IDFOR = valorTabelaModel.Fornecedor.IdFornecedor,
                    IDPRO = valorTabelaModel.Procedimento.IdProcedimento,
                    IDTAB = valorTabelaModel.Tabela.IdTabela,
                    FATURAMENTO = valorTabelaModel.Valor
                };
        }

        private static ValorTabelaDePrecoModel InjetarEmValorTabelaModel(FormCollection form)
        {
            return new ValorTabelaDePrecoModel()
            {
                Fornecedor = CadastroDeFornecedor.RecuperarFornecedorPorID(string.IsNullOrEmpty(form["idFornecedor"]) ? 0 : Convert.ToInt32(form["idFornecedor"])),
                Procedimento = CadastroDeProcedimentos.RecuperarProcedimentoPorID(string.IsNullOrEmpty(form["idProcedimento"]) ? 0 : Convert.ToInt32(form["idProcedimento"])),
                Tabela = new TabelaPrecoModel() { IdTabela = string.IsNullOrEmpty(form["codigoTabela"]) ? 0 : Convert.ToInt32(form["codigoTabela"]) },
                Valor = string.IsNullOrEmpty(form["valor"]) ? 0 : Convert.ToDecimal(form["valor"])
            };
        }

        private static List<ValorTabelaDePrecoModel> recuperarValoresTabelaDePreco(int idTabela)
        {
            List<TABELAXFORNECEDORXPROCEDIMENTO> valoresEncontrados = ControleDeTabelaPreco.recuperarValoresTabelaDePreco(idTabela);
            List<ValorTabelaDePrecoModel> listaDeModels = new List<ValorTabelaDePrecoModel>();

            valoresEncontrados.ForEach(x =>
            {
                listaDeModels.Add(injetarEmValoresModel(x));
            });

            return listaDeModels;
        }

        #endregion Private Methods
    }
}
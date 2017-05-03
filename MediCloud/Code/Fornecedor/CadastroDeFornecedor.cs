using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Fornecedor;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Fornecedor;
using MediCloud.Code.Enum;
using MediCloud.Models.Financeiro;
using MediCloud.BusinessProcess.Funcionario;
using System.Web.Mvc;
using MediCloud.Controllers;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code.Parametro.GrupoProcedimento;

namespace MediCloud.Code.Fornecedor
{
    public class CadastroDeFornecedor
    {
        internal static FornecedorModel RecuperarFornecedorPorID(decimal? IdFor, bool materializarListas = true)
        {
            if (IdFor.HasValue)
            {
                FORNECEDOR usuarioDoBanco = ControleDeFornecedor.buscarProcedimentosMovimentoPorIdMovimento((int)IdFor);

                return InjetarEmUsuarioModel(usuarioDoBanco, materializarListas);
            }
            else
                return null;
        }

        internal static List<FornecedorModel> RecuperarContadorPorTermo(string prefix)
        {
            List<FORNECEDOR> contadoresEncontrados = ControleDeFornecedor.buscarFornecedorPorTermo(prefix);
            List<FornecedorModel> resultados = new List<FornecedorModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        public static FornecedorModel InjetarEmUsuarioModel(FORNECEDOR x, bool materializarListas = true)
        {
            if (x == null)
                return null;
            else
                return new FornecedorModel()
                {
                    CNPJ = x.CNPJ,
                    CodigoAgencia = x.CTAAGENCIA,
                    CodigoBanco = x.CTABANCO,
                    ContaCorrente = x.CTACORRENTE,
                    FornecedorDeProcedimentos = x.TIPOFORNECEDOR,
                    IdFornecedor = (int)x.IDFOR,
                    NomeFantasia = x.NOMEFANTASIA,
                    RazaoSocial = x.RAZAOSOCIAL,
                    TipoConta = tipoContaStringParaEnum(x.TIPOCONTA),

                    ContatosFornecedor = materializarListas ? CadastroDeContato.RecuperarListaDeContatoFornecedorPorIdFornecedor((int)x.IDFOR) : new List<ContatoFornecedorModel>(),
                    ProcedimentosFornecedor = materializarListas ? RecuperarProcedimentosDeFornecedor((int)x.IDFOR) : new List<FornecedorProcedimento>()
                };
        }

        private static List<FornecedorProcedimento> RecuperarProcedimentosDeFornecedor(int IdFor)
        {
            if (IdFor != 0)
            {
                List<FORNECEDORXPROCEDIMENTO> usuarioencontrado = ControleDeFornecedor.recuperarProcedimentosDeFornecedor(IdFor);
                return injetarEmFornecedorProcedimentoModel(usuarioencontrado);
            }
            else
                return null;
        }

        private static List<FornecedorProcedimento> injetarEmFornecedorProcedimentoModel(List<FORNECEDORXPROCEDIMENTO> usuarioencontrado)
        { 
            List<FornecedorProcedimento> listaTratada = new List<FornecedorProcedimento>();

            usuarioencontrado.ForEach(x => 
            {
                listaTratada.Add(injetarEmFornecedorProcedimento(x));
            });

            return listaTratada;
        }

        private static FornecedorProcedimento injetarEmFornecedorProcedimento(FORNECEDORXPROCEDIMENTO x)
        {
            if (x == null)
                return null;
            else
                return new FornecedorProcedimento()
                {
                    Fornecedor = RecuperarFornecedorPorID(x.IDFOR, false),
                    Procedimento = CadastroDeProcedimentos.RecuperarProcedimentoPorID((int)x.IDPRO),
                    Valor = x.CUSTO
                };
        }

        internal static List<FornecedorModel> BuscarFornecedor(FormCollection form)
        {
            string termo = form["keywords"];
            List<FornecedorModel> listaDeModels = new List<FornecedorModel>();

            List<FORNECEDOR> usuarioDoBanco = ControleDeFornecedor.buscarFornecedorPorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmUsuarioModel(x, false));
            });

            return listaDeModels;
        }

        private static string tipoContaEnumParaString(EnumFornecedor.TipoContaFornecedor X)
        {
            switch (X)
            {
                case EnumFornecedor.TipoContaFornecedor.Poupanca:
                    return "P";
                case EnumFornecedor.TipoContaFornecedor.Corrente:
                    return "C";
                default:
                    return null;
            }
        }

        private static EnumFornecedor.TipoContaFornecedor tipoContaStringParaEnum(string X)
        {
            switch (X)
            {
                case "P":
                    return EnumFornecedor.TipoContaFornecedor.Poupanca;
                case "C":
                    return EnumFornecedor.TipoContaFornecedor.Corrente;
                default:
                    return EnumFornecedor.TipoContaFornecedor.vazio;
            }
        }

        internal static void DeletarFornecedor(FornecedorController fornecedorController, int codigoFornecedor)
        {
            ControleDeFornecedor.DeletarFornecedor(codigoFornecedor);
        }

        internal static FornecedorModel SalvarFornecedor(FormCollection form)
        {
            FornecedorModel fornecedorModel = InjetarEmUsuarioModel(form);
            fornecedorModel.validar();

            FORNECEDOR fornecedorDAO = InjetarEmUsuarioDAO(fornecedorModel);
            fornecedorDAO = ControleDeFornecedor.SalvarFornecedor(fornecedorDAO);

            fornecedorModel = InjetarEmUsuarioModel(fornecedorDAO);

            return fornecedorModel;
        }

        private static FORNECEDOR InjetarEmUsuarioDAO(FornecedorModel x)
        {
            if (x == null)
                return null;
            else
                return new FORNECEDOR()
                {
                    CNPJ = x.CNPJ,
                    CTAAGENCIA = x.CodigoAgencia,
                    CTABANCO = x.CodigoBanco,
                    CTACORRENTE = x.ContaCorrente,
                    IDFOR = x.IdFornecedor,
                    NOMEFANTASIA = x.NomeFantasia,
                    RAZAOSOCIAL = x.RazaoSocial,
                    TIPOCONTA = tipoContaEnumParaString(x.TipoConta),
                    TIPOFORNECEDOR = x.FornecedorDeProcedimentos
                };
        }

        private static FornecedorModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new FornecedorModel()
            {
                CNPJ = string.IsNullOrEmpty(form["CNPJ"]) ? null : Util.ApenasNumeros(form["CNPJ"]),
                CodigoAgencia = string.IsNullOrEmpty(form["codigoAgencia"]) ? null : form["codigoAgencia"],
                CodigoBanco = string.IsNullOrEmpty(form["codigoBanco"]) ? null : form["codigoBanco"],
                ContaCorrente = string.IsNullOrEmpty(form["contaCorrente"]) ? null : form["contaCorrente"],
                FornecedorDeProcedimentos = string.IsNullOrEmpty(form["fornecedorDeProcedimentos"]) ? false : Convert.ToBoolean(form["fornecedorDeProcedimentos"].ToLower() == "on"),
                IdFornecedor = string.IsNullOrEmpty(form["codigoFornecedor"]) ? 0 : Convert.ToInt32(form["codigoFornecedor"]),
                NomeFantasia = string.IsNullOrEmpty(form["nomeFantasia"]) ? null : form["nomeFantasia"],
                RazaoSocial = string.IsNullOrEmpty(form["razaoSocial"]) ? null : form["razaoSocial"],
                TipoConta = string.IsNullOrEmpty(form["tipoConta"]) ? EnumFornecedor.TipoContaFornecedor.vazio : (EnumFornecedor.TipoContaFornecedor)Convert.ToInt32(form["tipoConta"])
            };
        }

        internal static FornecedorProcedimento salvarProcedimentoFornecedor(FormCollection form)
        {
            FornecedorProcedimento fornecedorModel = InjetarEmFornecedorProcedimentoModel(form);
            fornecedorModel.validar();

            FORNECEDORXPROCEDIMENTO fornecedorDAO = InjetarEmFornecedorProcedimentoDAO(fornecedorModel);
            fornecedorDAO = ControleDeFornecedor.SalvarFornecedorProcedimento(fornecedorDAO);

            fornecedorModel = injetarEmFornecedorProcedimento(fornecedorDAO);

            return fornecedorModel;
        }

        private static FORNECEDORXPROCEDIMENTO InjetarEmFornecedorProcedimentoDAO(FornecedorProcedimento x)
        {
            if (x == null)
                return null;
            else
                return new FORNECEDORXPROCEDIMENTO()
                {
                    CUSTO = x.Valor.HasValue ? x.Valor.Value : 0,
                    IDFOR = x.Fornecedor.IdFornecedor,
                    IDPRO = x.Procedimento.IdProcedimento
                };
        }

        private static FornecedorProcedimento InjetarEmFornecedorProcedimentoModel(FormCollection form)
        {
            return new FornecedorProcedimento()
            {
                Fornecedor = RecuperarFornecedorPorID(string.IsNullOrEmpty(form["codigoFornecedorProcedimento"]) ? 0 : Convert.ToInt32(form["codigoFornecedorProcedimento"])),
                Procedimento = CadastroDeProcedimentos.RecuperarProcedimentoPorID(string.IsNullOrEmpty(form["idProcedimento"]) ? 0 : Convert.ToInt32(form["idProcedimento"])),
                Valor = string.IsNullOrEmpty(form["valorProcedimento"]) ? null : (decimal?)Convert.ToDecimal(form["valorProcedimento"])
            };
        }

        internal static void DeletarProcedimentoFornecedor(int codigoDoProcedimentoFornecedor, int codigoFornecedor)
        {
            ControleDeFornecedor.DeletarProcedimentoFornecedor(codigoDoProcedimentoFornecedor, codigoFornecedor);
        }

        internal static FornecedorProcedimento recuperarFornecedorProcedimentoPorID(int codigoDoProcedimentoFornecedor, int codigoFornecedor)
        {
            if (codigoDoProcedimentoFornecedor > 0)
            {
                FORNECEDORXPROCEDIMENTO procedimentoBanco = ControleDeFornecedor.recuperarFornecedorProcedimentoPorID(codigoDoProcedimentoFornecedor, codigoFornecedor);

                return injetarEmFornecedorProcedimento(procedimentoBanco);
            }
            else
                return null;
        }
    }
}

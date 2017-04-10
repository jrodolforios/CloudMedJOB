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

namespace MediCloud.Code.Fornecedor
{
    public class CadastroDeFornecedor
    {
        internal static FornecedorModel RecuperarFornecedorPorID(decimal? IdFor)
        {
            if (IdFor.HasValue)
            {
                FORNECEDOR usuarioDoBanco = ControleDeFornecedor.buscarProcedimentosMovimentoPorIdMovimento((int)IdFor);

                return injetarEmUsuarioModel(usuarioDoBanco);
            }
            else
                return null;
        }

        internal static List<FornecedorModel> RecuperarContadorPorTermo(string prefix)
        {
            List<FORNECEDOR> contadoresEncontrados = ControleDeFornecedor.buscarCargosPorTermo(prefix);
            List<FornecedorModel> resultados = new List<FornecedorModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        public static FornecedorModel injetarEmUsuarioModel(FORNECEDOR x)
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
                    TipoConta = tipoContaEnumParaString(x.TIPOCONTA)
                };
        }

        private static EnumFornecedor.TipoContaFornecedor tipoContaEnumParaString(string X)
        {
            switch (X)
            {
                case "p":
                    return EnumFornecedor.TipoContaFornecedor.Poupanca;
                case "C":
                    return EnumFornecedor.TipoContaFornecedor.Corrente;
                default:
                    return EnumFornecedor.TipoContaFornecedor.vazio;
            }
        }
    }
}

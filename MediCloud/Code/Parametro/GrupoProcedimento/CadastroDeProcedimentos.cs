using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Parametro.GrupoProcedimento;

namespace MediCloud.Code.Parametro.GrupoProcedimento
{
    public class CadastroDeProcedimentos
    {
        internal static ProcedimentoModel RecuperarProcedimentoPorID(int IdPro)
        {
            if (IdPro != 0)
            {
                PROCEDIMENTO usuarioencontrado = ControleDeProcedimentos.recuperarProcedimentoPorID(IdPro);
                return injetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        internal static List<ProcedimentoModel> RecuperarContadorPorTermo(string prefix)
        {
            List<PROCEDIMENTO> contadoresEncontrados = ControleDeProcedimentos.buscarCargosPorTermo(prefix);
            List<ProcedimentoModel> resultados = new List<ProcedimentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static decimal BuscarValorProcedimentoPorIDFornecedor(int procedimento, int fornecedor)
        {
            return ControleDeProcedimentos.BuscarValorProcedimentoPorIDFornecedor(procedimento, fornecedor);
        }

        internal static List<ProcedimentoModel> RecuperarContadorPorTermoEFornecedor(string prefix, int fornecedor)
        {
            List<PROCEDIMENTO> contadoresEncontrados = ControleDeProcedimentos.buscarCargosPorTermoEFornecedor(prefix, fornecedor);
            List<ProcedimentoModel> resultados = new List<ProcedimentoModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        public static ProcedimentoModel injetarEmUsuarioModel(PROCEDIMENTO x)
        {
            if (x == null)
                return null;
            else
                return new ProcedimentoModel()
                {
                    CODNEXO = x.CODNEXO,
                    Complemento = x.COMPLEMENTO,
                    confirmaAutomaticamente = x.CONFIRMARAUTOMATICO, 
                    IdProcedimento = (int)x.IDPRO,
                    Nome = x.PROCEDIMENTO1,
                    Sigla = x.ABREVIADO,
                    ZeraAutomaticamente = x.ZERAAUTOMATICO,

                    Profissional = CadastroDeProfissional.GetProfissionalPorID(x.IDPRF),
                    SubGrupo = CadastroDeSubGrupo.GetSubGrupoPorID((int)x.IDSUBGRUPRO)
                };
        }
    }
}
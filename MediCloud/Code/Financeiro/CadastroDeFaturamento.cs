using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.DatabaseModels;
using MediCloud.Models.Financeiro;
using MediCloud.BusinessProcess.Financeiro;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeFaturamento
    {
        internal static FaturamentoModel RecuperarFaturamentoPorID(decimal? idFat)
        {
            if (idFat.HasValue && idFat != 0)
            {
                FATURAMENTO faturamentoEncontrado = ControleDeFaturamento.buscarCargoPorID(idFat);
                return injetarEmUsuarioModel(faturamentoEncontrado);
            }
            else
                return null;
        }

        private static FaturamentoModel injetarEmUsuarioModel(FATURAMENTO x)
        {
            if (x == null)
                return null;
            else
                return new FaturamentoModel()
                {
                    Ano = (int)x.ANO,
                    Data = x.DATA,
                    Dia = Convert.ToInt32(x.DIA),
                    IdFaturamento = (int)x.IDFAT,
                    DataLimite = x.DATALIMITE,
                    Mes = x.MES,
                    Usuario = x.USUARIO,
                    Valor = x.VALOR
                };
        }

        internal static FATURAMENTO injetarEmUsuarioDAO(FaturamentoModel faturamento)
        {
            if (faturamento == null)
                return null;
            else
                return new FATURAMENTO()
                {
                    ANO = faturamento.Ano,
                    DATA = faturamento.Data,
                    DATALIMITE = faturamento.DataLimite,
                    DIA = faturamento.Dia.ToString(),
                    IDCLI_FIN = faturamento.IdClienteFim,
                    IDCLI_INI = faturamento.IdClienteInicio,
                    IDFAT = faturamento.IdFaturamento,
                    MES = faturamento.Mes,
                    USUARIO = faturamento.Usuario,
                    VALOR = faturamento.Valor
                };
        }
    }
}
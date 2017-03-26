using MediCloud.BusinessProcess.Financeiro;
using MediCloud.DatabaseModels;
using MediCloud.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Code.Financeiro
{
    public class CadastroDeContador
    {


        public static ContadorModel injetarEmUsuarioModel(CONTADOR usuarioDoBanco)
        {
            if (usuarioDoBanco == null)
                return null;
            else
                return new ContadorModel()
                {
                    IdContador = (int)usuarioDoBanco.IDCONT,
                    NomeContador = usuarioDoBanco.CONTADOR1
                };
        }

        internal static List<ContadorModel> RecuperarContadorPorTermo(string prefix)
        {
            List<CONTADOR> contadoresEncontrados = ControleDeContador.BuscarContadoresPorTermo(prefix);
            List<ContadorModel> resultados = new List<ContadorModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }
    }
}
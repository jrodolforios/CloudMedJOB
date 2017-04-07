using MediCloud.BusinessProcess.Recomendacao;
using MediCloud.DatabaseModels;
using MediCloud.Models.Recomendacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Code.Recomendacao
{
    public class CadastroDeSetor
    {
        internal static SetorModel RecuperarSetorPorID(int IdRef)
        {
            if (IdRef != 0)
            {
                SETOR referenteEncontrado = ControleDeSetor.buscarSetorPorID(IdRef);
                return injetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        private static SetorModel injetarEmUsuarioModel(SETOR referenteEncontrado)
        {
            if (referenteEncontrado == null)
                return null;
            else
                return new SetorModel()
                {
                    IdSetor = (int)referenteEncontrado.IDSETOR,
                    NomeSetor = referenteEncontrado.SETOR1
                };
        }

        internal static List<SetorModel> RecuperarSetorPorTermo(string prefix)
        {
            List<SETOR> contadoresEncontrados = ControleDeSetor.buscarSetorPorTermo(prefix);
            List<SetorModel> resultados = new List<SetorModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static SETOR injetarEmUsuarioDAO(SetorModel x)
        {
            if (x == null)
                return null;
            else
                return new SETOR()
                {
                    IDSETOR = x.IdSetor,
                    SETOR1 = x.NomeSetor
                };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Cliente;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Cliente;

namespace MediCloud.Code.Clientes
{
    public class CadastroDeReferente
    {
        internal static ReferenteModel RecuperarReferentePorID(int IdRef)
        {
            if (IdRef != 0)
            {
                MOVIMENTO_REFERENTE referenteEncontrado = ControleDeReferente.buscarFormaDePagamento(IdRef);
                return injetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        private static ReferenteModel injetarEmUsuarioModel(MOVIMENTO_REFERENTE referenteEncontrado)
        {
            if (referenteEncontrado == null)
                return null;
            else
                return new ReferenteModel()
                {
                    IdReferencia = (int)referenteEncontrado.IDREF,
                    NomeReferencia = referenteEncontrado.NOMEREFERENCIA
                };
        }

        internal static List<ReferenteModel> RecuperarTodos()
        {
            List<MOVIMENTO_REFERENTE> referenteEncontrado = ControleDeReferente.RecuperarTodos();

            List<ReferenteModel> encontrados = new List<ReferenteModel>();

            referenteEncontrado.ForEach(x =>
            {
                encontrados.Add(injetarEmUsuarioModel(x));
            });

            return encontrados;
        }
    }
}
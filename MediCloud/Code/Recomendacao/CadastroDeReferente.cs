using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Cliente;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Cliente;
using MediCloud.Models.Recomendacao;
using System.Web.Mvc;
using MediCloud.BusinessProcess.Recomendacao;

namespace MediCloud.Code.Recomendacao
{
    public class CadastroDeReferente
    {
        internal static ReferenteModel RecuperarReferentePorID(int IdRef)
        {
            if (IdRef != 0)
            {
                MOVIMENTO_REFERENTE referenteEncontrado = ControleDeReferente.buscarFormaDePagamento(IdRef);
                return InjetarEmUsuarioModel(referenteEncontrado);
            }
            else
                return null;
        }

        internal static ReferenteModel InjetarEmUsuarioModel(MOVIMENTO_REFERENTE referenteEncontrado)
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

        internal static void DeletarReferencia(int codigoReferencia)
        {
            ControleDeReferente.DeletarReferencia(codigoReferencia);
        }

        internal static List<ReferenteModel> BuscarReferentePorTermo(string prefix)
        {
            List<ReferenteModel> listaDeModels = new List<ReferenteModel>();

            List<MOVIMENTO_REFERENTE> usuarioDoBanco = ControleDeReferente.buscarReferentePorTermo(prefix);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static List<ReferenteModel> RecuperarTodos()
        {
            List<MOVIMENTO_REFERENTE> referenteEncontrado = ControleDeReferente.RecuperarTodos();

            List<ReferenteModel> encontrados = new List<ReferenteModel>();

            referenteEncontrado.ForEach(x =>
            {
                encontrados.Add(InjetarEmUsuarioModel(x));
            });

            return encontrados;
        }

        internal static MOVIMENTO_REFERENTE InjetarEmUsuarioDAO(ReferenteModel x)
        {
            if (x == null)
                return null;
            else
                return new MOVIMENTO_REFERENTE()
                {
                    IDREF = x.IdReferencia,
                    NOMEREFERENCIA = x.NomeReferencia
                };
        }

        internal static List<ReferenteModel> buscarReferencia(FormCollection form)
        {
            string termo = form["keywords"];
            List<ReferenteModel> listaDeModels = new List<ReferenteModel>();

            List<MOVIMENTO_REFERENTE> usuarioDoBanco = ControleDeReferente.buscarReferentePorTermo(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        internal static ReferenteModel SalvarReferencia(FormCollection form)
        {
            ReferenteModel referenteModel = InjetarEmUsuarioModel(form);
            referenteModel.validar();

            MOVIMENTO_REFERENTE referenteDAO = InjetarEmUsuarioDAO(referenteModel);
            referenteDAO = ControleDeReferente.SalvarReferencia(referenteDAO);

            referenteModel = InjetarEmUsuarioModel(referenteDAO);

            return referenteModel;
        }

        internal static ReferenteModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new ReferenteModel()
            {
                IdReferencia = string.IsNullOrEmpty(form["codigoReferencia"]) ? 0 : Convert.ToInt32(form["codigoReferencia"]),
                NomeReferencia = string.IsNullOrEmpty(form["nomeReferencia"]) ? null : form["nomeReferencia"]
            };
        }
    }
}
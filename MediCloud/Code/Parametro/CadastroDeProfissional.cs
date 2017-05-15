using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Parametro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Parametro;
using System.Web.Mvc;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeProfissional
    {
        internal static ProfissionalModel GetProfissionalPorID(string IdPro)
        {
            if (!string.IsNullOrEmpty(IdPro))
            {
                PROFISSIONAIS usuarioencontrado = ControleDeProfissional.recuperarProfissionalPorID(IdPro);
                return InjetarEmUsuarioModel(usuarioencontrado);
            }
            else
                return null;
        }

        internal static List<ProfissionalModel> RecuperarContadorPorTermo(string prefix)
        {
            List<PROFISSIONAIS> contadoresEncontrados = ControleDeProfissional.buscarCargosPorTermo(prefix);
            List<ProfissionalModel> resultados = new List<ProfissionalModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        internal static List<ProfissionalModel> RecuperarContadorPorTermo(FormCollection form)
        {
            string prefix = form["keywords"];

            List<PROFISSIONAIS> contadoresEncontrados = ControleDeProfissional.buscarCargosPorTermo(prefix);
            List<ProfissionalModel> resultados = new List<ProfissionalModel>();

            contadoresEncontrados.ForEach(x =>
            {
                resultados.Add(InjetarEmUsuarioModel(x));
            });

            return resultados;
        }

        public static ProfissionalModel InjetarEmUsuarioModel(PROFISSIONAIS x)
        {
            if (x == null)
                return null;
            else
                return new ProfissionalModel()
                {
                    Ativo = x.STATUS == "A",
                    IdProfissional = x.IDPRF,
                    NomeProfissional = x.PROFISSIONAL
                };
        }

        internal static void DeletarProfissional(string codigoDoProfissional)
        {
            ControleDeProfissional.DeletarProfissional(codigoDoProfissional);
        }

        internal static ProfissionalModel SalvarProfissional(FormCollection form)
        {
            ProfissionalModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            PROFISSIONAIS profissionalDAO = InjetarEmUsuarioDAO(usuarioModel);
            profissionalDAO = ControleDeProfissional.SalvarProfissional(profissionalDAO);

            usuarioModel = InjetarEmUsuarioModel(profissionalDAO);

            return usuarioModel;
        }

        private static PROFISSIONAIS InjetarEmUsuarioDAO(ProfissionalModel usuarioModel)
        {
            if (usuarioModel == null)
                return null;
            else
                return new PROFISSIONAIS()
                {
                    IDPRF = usuarioModel.IdProfissional,
                    PROFISSIONAL = usuarioModel.NomeProfissional,
                    STATUS = usuarioModel.Ativo.HasValue ? (usuarioModel.Ativo.Value ? "A" : "I") : "A"
                };
        }

        private static ProfissionalModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new ProfissionalModel()
            {
                Ativo = string.IsNullOrEmpty(form["inativo"]) ? true : !Convert.ToBoolean(form["inativo"].ToLower() == "on"),
                IdProfissional = string.IsNullOrEmpty(form["codigoProfissional"]) ? (string.IsNullOrEmpty(form["idProfissional"]) ? null : form["idProfissional"]) : form["codigoProfissional"],
                NomeProfissional = string.IsNullOrEmpty(form["nomeProfissional"]) ? null : form["nomeProfissional"]
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Models.Parametro;
using MediCloud.DatabaseModels;
using MediCloud.BusinessProcess.Parametro;

namespace MediCloud.Code.Parametro
{
    public class CadastroDeProfissional
    {
        internal static ProfissionalModel GetProfissionalPorID(string IdPro)
        {
            if (!string.IsNullOrEmpty(IdPro))
            {
                PROFISSIONAIS usuarioencontrado = ControleDeProfissional.recuperarProfissionalPorID(IdPro);
                return injetarEmUsuarioModel(usuarioencontrado);
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
                resultados.Add(injetarEmUsuarioModel(x));
            });

            return resultados;
        }

        public static ProfissionalModel injetarEmUsuarioModel(PROFISSIONAIS x)
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
    }
}
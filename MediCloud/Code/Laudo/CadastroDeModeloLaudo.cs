using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.DatabaseModels;
using MediCloud.Models.Laudo;

namespace MediCloud.Code.Laudo
{
    public class CadastroDeModeloLaudo
    {
        internal static ModeloLaudoModel InjetarEmUsuarioModel(MODELOLAUDO x)
        {
            if (x == null)
                return null;
            else
                return new ModeloLaudoModel()
                {
                    Conclusao = x.CONCLUSAO,
                    CorpoModelo = x.LAUDO,
                    IdModeloLaudo = (int)x.IDMODELO,
                    NomeModelo = x.MODELO,
                    Rodape = x.RODAPE
                };
        }
    }
}
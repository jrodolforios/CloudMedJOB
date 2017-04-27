using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCloud.Models.Laudo;
using MediCloud.DatabaseModels;
using MediCloud.Code.Clientes;
using MediCloud.Code.Funcionario;
using MediCloud.Code.Enum;
using MediCloud.BusinessProcess.Laudo;
using MediCloud.Controllers;

namespace MediCloud.Code.Laudo
{
    public class CadastroDeLaudoVisao
    {
        internal static List<LaudoVisaoModel> buscarLaudoVisao(FormCollection form)
        {
            string termo = form["keywords"];
            List<LaudoVisaoModel> listaDeModels = new List<LaudoVisaoModel>();

            List<LAUDOAV> usuarioDoBanco = ControleDeLaudoVisao.buscarLaudoAudio(termo);

            usuarioDoBanco.ForEach(x =>
            {
                listaDeModels.Add(InjetarEmUsuarioModel(x));
            });

            return listaDeModels;
        }

        private static LaudoVisaoModel InjetarEmUsuarioModel(LAUDOAV x)
        {
            if (x == null)
                return null;
            else
                return new LaudoVisaoModel()
                {
                    Cargo = CadastroDeCargo.injetarEmUsuarioModel(x.CARGO),
                    Cliente = CadastroDeClientes.injetarEmUsuarioModel(x.CLIENTE),
                    COD = x.COD,
                    COE = x.COE,
                    Conclusao = x.CONCLUSAO,
                    Correcao = ConverterCorrecaoParaEnum(x.CORRECAO),
                    DataLaudo = x.DATALAUDO,
                    Estrabismo = ConverterEstrabismoParaEnum(x.ESTRABISMO),
                    Funcionario = CadastroDeFuncionario.injetarEmUsuarioModel(x.FUNCIONARIO),
                    IdLaudo = (int)x.IDLAUDO,
                    OD = x.OD,
                    OE = x.OE,
                    VisaoCromatica = ConverterVisaoCromaticaParaEnum(x.VISAOCROMATICA)
                };
        }

        internal static void DeletarLaudoVisao(LaudoVisaoController laudoVisaoController, int codigoLaudoVisao)
        {
            ControleDeLaudoVisao.ExcluirLaudoVisao(codigoLaudoVisao);
        }

        private static DefaultEnum.EnumSimNao ConverterEstrabismoParaEnum(string x)
        {
            switch (x)
            {
                case "SIM":
                    return DefaultEnum.EnumSimNao.Sim;
                case "NAO":
                    return DefaultEnum.EnumSimNao.Nao;
                default:
                    return DefaultEnum.EnumSimNao.vazio;
            }
        }

        private static EnumLaudo.EnumVisaoCromatica ConverterVisaoCromaticaParaEnum(string x)
        {
            switch (x)
            {
                case "NORMAL":
                    return EnumLaudo.EnumVisaoCromatica.Normal;
                case "DISCROMATOPSIA":
                    return EnumLaudo.EnumVisaoCromatica.Discromatopsia;
                default:
                    return EnumLaudo.EnumVisaoCromatica.vazio;
            }
        }

        private static EnumLaudo.CorrecaoAcuidadeVisual ConverterCorrecaoParaEnum(string x)
        {
            switch (x)
            {
                case "SEM CORREÇÃO":
                    return EnumLaudo.CorrecaoAcuidadeVisual.SemCorrecao;
                case "COM CORREÇÃO":
                    return EnumLaudo.CorrecaoAcuidadeVisual.ComCorrecao;
                default:
                    return EnumLaudo.CorrecaoAcuidadeVisual.vazio;
            }
        }
    }
}
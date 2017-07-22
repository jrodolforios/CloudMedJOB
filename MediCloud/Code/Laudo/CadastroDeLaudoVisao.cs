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

        internal static LaudoVisaoModel recuperarLaudoVisaoPorID(int v)
        {
            LAUDOAV laudoVisaoEncontrado = ControleDeLaudoVisao.buscarLaudoVisaoPorId(v);

            return InjetarEmUsuarioModel(laudoVisaoEncontrado);
        }

        private static LaudoVisaoModel InjetarEmUsuarioModel(LAUDOAV x)
        {
            if (x == null)
                return null;
            else
                return new LaudoVisaoModel()
                {
                    Cargo = CadastroDeCargo.RecuperarCargoPorID((int)x.IDCGO),
                    Cliente = CadastroDeClientes.RecuperarClientePorID((int)x.IDCLI),
                    COD = x.COD,
                    COE = x.COE,
                    Conclusao = x.CONCLUSAO,
                    Correcao = ConverterCorrecaoParaEnum(x.CORRECAO),
                    DataLaudo = x.DATALAUDO,
                    Estrabismo = ConverterEstrabismoParaEnum(x.ESTRABISMO),
                    Funcionario = CadastroDeFuncionario.RecuperarFuncionarioPorID((int)x.IDFUN),
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
                case "NÃO":
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

        private static string ConverterCorrecaoParaString(EnumLaudo.CorrecaoAcuidadeVisual x)
        {
            switch (x)
            {
                case EnumLaudo.CorrecaoAcuidadeVisual.SemCorrecao:
                    return "SEM CORREÇÃO";
                case EnumLaudo.CorrecaoAcuidadeVisual.ComCorrecao:
                    return "COM CORREÇÃO";
                default:
                    return null;
            }
        }

        private static string ConverterEstrabismoParaString(DefaultEnum.EnumSimNao x)
        {
            switch (x)
            {
                case DefaultEnum.EnumSimNao.Sim:
                    return "SIM";
                case DefaultEnum.EnumSimNao.Nao:
                    return "NÃO";
                default:
                    return null;
            }
        }

        private static string ConverterVisaoCromaticaParaString(EnumLaudo.EnumVisaoCromatica x)
        {
            switch (x)
            {
                case EnumLaudo.EnumVisaoCromatica.Normal:
                    return "NORMAL";
                case EnumLaudo.EnumVisaoCromatica.Discromatopsia:
                    return "DISCROMATOPSIA";
                default:
                    return null;
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

        internal static byte[] ImprimirLaudo(int codigoLaudo)
        {
            return ControleDeLaudoVisao.ImprimirLaudo(codigoLaudo);
        }

        internal static LaudoVisaoModel SalvarLaudoVisao(FormCollection form)
        {
            LaudoVisaoModel usuarioModel = InjetarEmUsuarioModel(form);
            usuarioModel.validar();

            LAUDOAV laudoVisaoDAO = InjetarEmUsuarioModelDAO(usuarioModel);
            laudoVisaoDAO = ControleDeLaudoVisao.SalvarLaudoVisao(laudoVisaoDAO);

            usuarioModel = InjetarEmUsuarioModel(laudoVisaoDAO);

            return usuarioModel;
        }

        private static LAUDOAV InjetarEmUsuarioModelDAO(LaudoVisaoModel x)
        {
            if (x == null)
                return null;
            else
                return new LAUDOAV()
                {
                    COD = x.COD,
                    COE = x.COE,
                    CONCLUSAO = x.Conclusao,
                    CORRECAO = ConverterCorrecaoParaString(x.Correcao),
                    DATALAUDO = x.DataLaudo.Value,
                    ESTRABISMO = ConverterEstrabismoParaString(x.Estrabismo),
                    IDCGO = x.Cargo?.IdCargo,
                    IDCLI = x.Cliente?.IdCliente,
                    IDFUN = x.Funcionario?.IdFuncionario,
                    IDLAUDO = x.IdLaudo,
                    OD = x.OD,
                    OE = x.OE,
                    VISAOCROMATICA = ConverterVisaoCromaticaParaString (x.VisaoCromatica),
                };
        }

        private static LaudoVisaoModel InjetarEmUsuarioModel(FormCollection form)
        {
            return new LaudoVisaoModel()
            {
                Cargo = CadastroDeCargo.RecuperarCargoPorID(string.IsNullOrEmpty(form["idCargo"]) ? 0: Convert.ToInt32(form["idCargo"])),
                Cliente = CadastroDeClientes.RecuperarClientePorID(string.IsNullOrEmpty(form["idCliente"]) ? 0 : Convert.ToInt32(form["idCliente"])),
                Funcionario = CadastroDeFuncionario.RecuperarFuncionarioPorID(string.IsNullOrEmpty(form["idFuncionario"]) ? 0 : Convert.ToInt32(form["idFuncionario"])),

                COD = string.IsNullOrEmpty(form["COD"]) ? null: form["COD"],
                COE = string.IsNullOrEmpty(form["COE"]) ? null : form["COE"],
                Conclusao = string.IsNullOrEmpty(form["Conclusao"]) ? null : form["Conclusao"],
                Correcao = string.IsNullOrEmpty(form["correcao"]) ? EnumLaudo.CorrecaoAcuidadeVisual.vazio : (EnumLaudo.CorrecaoAcuidadeVisual)Convert.ToInt32(form["correcao"]),
                DataLaudo = string.IsNullOrEmpty(form["DataLaudo"]) ? null : (DateTime?)Convert.ToDateTime(form["DataLaudo"]),
                Estrabismo = string.IsNullOrEmpty(form["estrabismo"]) ? DefaultEnum.EnumSimNao.vazio : (DefaultEnum.EnumSimNao)Convert.ToInt32(form["estrabismo"]),
                IdLaudo = string.IsNullOrEmpty(form["codigoLaudoVisao"]) ? 0 : Convert.ToInt32(form["codigoLaudoVisao"]),
                OD = string.IsNullOrEmpty(form["OD"]) ? null : form["OD"],
                OE = string.IsNullOrEmpty(form["OE"]) ? null : form["OE"],
                VisaoCromatica = string.IsNullOrEmpty(form["visaoCromatica"]) ? EnumLaudo.EnumVisaoCromatica.vazio: (EnumLaudo.EnumVisaoCromatica)Convert.ToInt32(form["visaoCromatica"])
            };
        }
    }
}
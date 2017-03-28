using MediCloud.DatabaseModels;
using MediCloud.Models.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Controllers;
using MediCloud.BusinessProcess.Fornecedor;
using System.Web.Mvc;
using MediCloud.Code.Enum;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.Code.Fornecedor
{
    public class CadastroDeContato
    {
        public static List<ContatoModel> injetarEmUsuarioModel(List<CLIENTE_CONTATO> usuarioDoBanco)
        {
            List<ContatoModel> listaInjetada = new List<ContatoModel>();

            usuarioDoBanco.ForEach(x =>
            {
                listaInjetada.Add(CadastroDeContato.injetarEmUsuarioModel(x));
            });

            return listaInjetada;
        }

        public static ContatoModel injetarEmUsuarioModel(CLIENTE_CONTATO usuarioDoBanco)
        {
            if (usuarioDoBanco == null)
                return null;
            else
                return new ContatoModel()
                {
                    DataNascimento = usuarioDoBanco.NASCIMENTO,
                    Email = usuarioDoBanco.EMAIL,
                    Funcao = usuarioDoBanco.FUNCAO,
                    IdContato = (int)usuarioDoBanco.IDCON,
                    NomeContato = usuarioDoBanco.NOME,
                    Observacao = usuarioDoBanco.OBS,
                    TelefoneFixo = usuarioDoBanco.FONEFIXO,
                    TelfoneMovel = usuarioDoBanco.FONEMOVEL
                };
        }

        private static ContatoModel injetarEmUsuarioModel(FormCollection form)
        {
            return new ContatoModel()
            {
                DataNascimento = string.IsNullOrEmpty(form["dataNascimento"]) ? null : (DateTime?)Convert.ToDateTime(form["dataNascimento"]),
                Departamento = string.IsNullOrEmpty(form["dataNascimento"]) ? EnumContato.tipoDepartamento.Vazio : GetDepartamento(form["departamento"]),
                Email = string.IsNullOrEmpty(form["email"]) ? string.Empty : form["email"],
                Funcao = string.IsNullOrEmpty(form["funcao"]) ? string.Empty : form["funcao"],
                IdContato = Convert.ToInt32(form["codigoContato"]),
                IdCliente = Convert.ToInt32(form["codigoClienteContato"]),
                NomeContato = string.IsNullOrEmpty(form["nomeContato"]) ? string.Empty : form["nomeContato"],
                Observacao = string.IsNullOrEmpty(form["observacoesContato"]) ? string.Empty : form["observacoesContato"],
                TelefoneFixo = string.IsNullOrEmpty(form["telFixo"]) ? string.Empty : Util.ApenasNumeros(form["telFixo"]),
                TelfoneMovel = string.IsNullOrEmpty(form["telMovel"]) ? string.Empty : Util.ApenasNumeros(form["telMovel"])
            };
        }

        private static EnumContato.tipoDepartamento GetDepartamento(string v)
        {
            EnumContato.tipoDepartamento tipoDepartamento = EnumContato.tipoDepartamento.Vazio;

            switch (v)
            {
                case "CON":
                    tipoDepartamento = EnumContato.tipoDepartamento.CON;
                    break;
                case "DIR":
                    tipoDepartamento = EnumContato.tipoDepartamento.DIR;
                    break;
                case "COB":
                    tipoDepartamento = EnumContato.tipoDepartamento.COB;
                    break;
                case "OUT":
                    tipoDepartamento = EnumContato.tipoDepartamento.OUT;
                    break;
                case "FIN":
                    tipoDepartamento = EnumContato.tipoDepartamento.FIN;
                    break;
                case "JUR":
                    tipoDepartamento = EnumContato.tipoDepartamento.JUR;
                    break;
                case "COM":
                    tipoDepartamento = EnumContato.tipoDepartamento.COM;
                    break;
                case "ADM":
                    tipoDepartamento = EnumContato.tipoDepartamento.ADM;
                    break;
                default:
                    tipoDepartamento = EnumContato.tipoDepartamento.Vazio;
                    break;
            }

            return tipoDepartamento;
        }

        private static string GetDepartamento(EnumContato.tipoDepartamento v)
        {
            string tipoDepartamento =null;

            switch (v)
            {
                case EnumContato.tipoDepartamento.CON:
                    tipoDepartamento = "CON";
                    break;
                case EnumContato.tipoDepartamento.DIR:
                    tipoDepartamento = "DIR";
                    break;
                case EnumContato.tipoDepartamento.COB:
                    tipoDepartamento = "COB";
                    break;
                case EnumContato.tipoDepartamento.OUT:
                    tipoDepartamento = "OUT";
                    break;
                case EnumContato.tipoDepartamento.FIN:
                    tipoDepartamento = "FIN";
                    break;
                case EnumContato.tipoDepartamento.JUR:
                    tipoDepartamento ="JUR";
                    break;
                case EnumContato.tipoDepartamento.COM:
                    tipoDepartamento = "COM";
                    break;
                case EnumContato.tipoDepartamento.ADM:
                    tipoDepartamento = "ADM";
                    break;
                default:
                    tipoDepartamento = null;
                    break;
            }

            return tipoDepartamento;
        }



        internal static ContatoModel salvarContato(FormCollection form)
        {
            ContatoModel contatoModel = injetarEmUsuarioModel(form);
            contatoModel.validar();

            CLIENTE_CONTATO contatoDAO = injetarEmUsuarioDAO(contatoModel);
            contatoDAO = ControleDeContato.SalvarContato(contatoDAO);

            contatoModel = injetarEmUsuarioModel(contatoDAO);

            return contatoModel;
        }

        private static CLIENTE_CONTATO injetarEmUsuarioDAO(ContatoModel x)
        {
            if (x == null)
                return null;
            else
                return new CLIENTE_CONTATO()
                {
                    DEPARTAMENTO = GetDepartamento(x.Departamento),
                    EMAIL = x.Email,
                    FONEFIXO = x.TelefoneFixo,
                    FONEMOVEL = x.TelfoneMovel,
                    FUNCAO = x.Funcao,
                    IDCLI = x.IdCliente,
                    IDCON = x.IdContato,
                    NASCIMENTO = x.DataNascimento,
                    NOME = x.NomeContato,
                    OBS = x.Observacao
                };
        }

        internal static void DeletarContato(ContatoController contatoController, int codigoDoContato)
        {
            ControleDeContato.ExcluirContato(codigoDoContato);
        }
    }
}
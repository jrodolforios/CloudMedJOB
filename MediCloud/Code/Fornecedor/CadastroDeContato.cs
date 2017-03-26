using MediCloud.DatabaseModels;
using MediCloud.Models.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediCloud.Controllers;
using MediCloud.BusinessProcess.Fornecedor;

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

        internal static void DeletarContato(ContatoController contatoController, int codigoDoContato)
        {
            ControleDeContato.ExcluirContato(codigoDoContato);
        }
    }
}
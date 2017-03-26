using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Seguranca
{
    public class SessaoUsuarioModel : IModel
    {
        public int codigoDoUsuario { get; set; }
        public string NomeDoUsuario { get; set; }
        public string login { get; set; }
        public string senhaMD5 { get; set; }
        public DateTime? dataUltimoLogin { get; set; }
        public DateTime? dataUltimaAteracaoSenha { get; set; }
        public bool bloqueado { get; set; }
        public bool trocaSenhaNoProximoLogon { get; set; }

        public string toString()
        {
            return $"{NomeDoUsuario} | {login}";
        }

        public void validar()
        {
            //void
        }
    }
}
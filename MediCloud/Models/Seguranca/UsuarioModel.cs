using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Seguranca
{
    public class UsuarioModel
    {
        public int Codigo { get; set; }
        public string nomeUsuario { get; set; }
        public string loginUsuario { get; set; }
        public bool acessoBloqueado { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Code.Enum
{
    public class EnumCliente
    {
        public enum tipoEmpresa
        {
            Vazio = 0,
            PessoaFisica = 1,
            PessoaJuridica = 2,
            CEI = 3
        }
    }
}
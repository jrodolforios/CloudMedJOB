using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Code.Enum
{
    public class EnumLaudo
    {
        public enum StatusLiberadoLaudo
        {
            vazio = 0,
            pendente = 1,
            liberado = 2
        }

        public enum CorrecaoAcuidadeVisual
        {
            vazio = 0,
            SemCorrecao = 1,
            ComCorrecao = 2
        }

        public enum EnumVisaoCromatica
        {
            vazio = 0,
            Normal = 1,
            Discromatopsia = 2
        }
    }
}
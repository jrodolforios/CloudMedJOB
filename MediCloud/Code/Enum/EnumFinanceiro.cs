using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Code.Enum
{
    public class EnumFinanceiro
    {
        public enum TipoPagamento
        {
            Vazio = 0,
            AVista = 1,
            APrazo = 2
        }

        public enum SituacaoContrato
        {
            vazio = 0,
            Aberto = 1,
            Conferencia = 2,
            Lancado = 3
        }

        public enum ImprimeNotaFiscal
        {
            vazio = 0,
            Imprime = 1,
            NaoImprime = 2,
            Exporta = 3
        }

        public enum ModoDeEntrega
        {
            vazio = 0,
            Email = 1,
            Motoboy = 2,
            Correio = 3,
            BuscaNoLocal = 4
        }
    }
}
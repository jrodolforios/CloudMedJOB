using MediCloud.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediCloud.Models.Seguranca
{
    public class IndexModel
    {
        public int MovimentosNaoFaturados { get; set; }
        public int MovimentosNoMês { get; set; }
        public int ProcedimentosNoMes { get; set; }
        public int ConvocacoesNoMes { get; set; }
        public List<ASOModel> ASOS { get; set; }
        public Dictionary<decimal, int> GraficoASOs { get; set; }
        public List<string> FaturamentoUltimos8Meses { get; set; }
        public decimal FaturamentoMesAtual { get; set; }
    }
}
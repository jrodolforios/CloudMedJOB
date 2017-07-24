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
    }
}
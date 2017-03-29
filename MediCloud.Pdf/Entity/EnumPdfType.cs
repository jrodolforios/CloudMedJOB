using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediCLoud.Pdf.Entity
{
    public enum EnumPdfType
    {
        iTextSharp,
        TuesPechkin,
    }

    public enum TipoOrientacaoPdf : int
    {
        Retrato = 1,
        Paisagem = 2
    }
}

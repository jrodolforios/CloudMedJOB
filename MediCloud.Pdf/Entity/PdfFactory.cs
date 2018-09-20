using System;

namespace MediCLoud.Pdf.Entity
{
    public abstract class PdfFactory
    {
        #region Public Methods

        public static IPdfWriter create(EnumPdfType pdfType)
        {
            IPdfWriter pdfWriter;

            if (pdfType == EnumPdfType.iTextSharp)
                pdfWriter = new PdfiTextSharp();
            else if (pdfType == EnumPdfType.TuesPechkin)
                pdfWriter = new PdfTuesPechkin();
            else
                throw new InvalidOperationException(string.Format(@"Tipo de PDF [{0}] não suportado", pdfType));

            return pdfWriter;
        }

        #endregion Public Methods
    }
}
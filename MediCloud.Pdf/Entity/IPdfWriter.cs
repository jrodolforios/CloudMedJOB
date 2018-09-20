using TuesPechkin;

namespace MediCLoud.Pdf.Entity
{
    public interface IPdfWriter
    {
        #region Public Methods

        byte[] Parse(string html);

        byte[] Parse(string html, double marginTop, double marginRight, double marginBottom, double marginLeft, Unit unit);

        byte[] ParseCupomFiscal(string html);

        byte[] ParseOrientacao(string html, TipoOrientacaoPdf orientacao);

        byte[] ParseOrientacaoFooterFixo(string html, TipoOrientacaoPdf orientacao, string footer);

        byte[] ParseTipoPapel(string html, string largura, string altura, double marginTop, double marginRight, double marginBottom, double marginLeft, Unit unit);

        byte[] ParseTipoPapel(string html, string largura, string altura, double marginTop, double marginRight, double marginBottom, double marginLeft, Unit unit, TipoOrientacaoPdf orientacao);

        #endregion Public Methods
    }
}
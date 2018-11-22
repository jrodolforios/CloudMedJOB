using iTextSharp2.text;
using iTextSharp2.text.html.simpleparser;
using iTextSharp2.text.pdf;
using System.Drawing.Printing;
using System.IO;
using TuesPechkin;

namespace MediCLoud.Pdf.Entity
{
    public class PdfiTextSharp : IPdfWriter
    {
        //Testando aplicação de estilos
        //public static Document Parse(string html, Stream stream)
        //{
        //    Document document = new Document(PageSize.A4, 5f, 5f, 5f, 5f);
        //    PdfWriter.GetInstance(document, stream);
        //    document.Open();
        //    HTMLWorker worker = new HTMLWorker(document);
        //    StyleSheet styles = new StyleSheet();
        //    //styles.LoadStyle("textoCampo", "font-weight", "bold");
        //    //styles.LoadStyle("textoCampo", "font-size", "8px");
        //    //styles.LoadStyle("textoCampo", "font-family", "Verdana");

        //    //worker.SetStyleSheet(styles);
        //    worker.Parse(new StringReader(html));

        //    document.Close();
        //    return document;
        //}



        #region Public Methods

        public byte[] Parse(string html)
        {
            return Parse(html, 5f, 5f, 5f, 5f);
        }

        public byte[] Parse(string html, double marginTop, double marginRight, double marginBottom, double marginLeft, TuesPechkin.Unit unit)
        {
            return Parse(html, (float)marginLeft, (float)marginRight, (float)marginTop, (float)marginBottom);
        }

        public byte[] Parse(string html, float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            byte[] bytes = new byte[] { };

            //1: Cria o Documento objeto
            using (Document document = new Document(PageSize.A4, marginLeft, marginRight, marginTop, marginBottom))
            {
                using (MemoryStream msOutput = new MemoryStream())
                {
                    //2: Associa o documento ao writer
                    using (PdfWriter writer = PdfWriter.GetInstance(document, msOutput))
                    {
                        //3: Associar parser ao documento criado
                        HTMLWorker worker = new HTMLWorker(document);

                        //4: Abre o documento para gravação
                        document.Open();
                        document.AddAuthor("CloudMe");
                        document.AddCreator("CloudMe");

                        worker.StartDocument();

                        //5: Realiza o Parser
                        worker.Parse(new StringReader(html));

                        //6: Finaliza os objetos
                        worker.EndDocument();
                        worker.Close();
                    }

                    bytes = msOutput.ToArray();
                }
                document.Close();
            }

            return bytes;
        }

        public byte[] ParseCupomFiscal(string html)
        {
            MemoryStream memoryStream = new MemoryStream();
            return memoryStream.ToArray();
        }

        public byte[] ParseOrientacao(string html, TipoOrientacaoPdf orientacao)
        {
            MemoryStream memoryStream = new MemoryStream();
            return memoryStream.ToArray();
        }

        public byte[] ParseOrientacaoFooterFixo(string html, TipoOrientacaoPdf orientacao, string footer)
        {
            HtmlToPdfDocument document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    //DocumentTitle = "Pretty Websites",/
                    PaperSize = PaperKind.A4, // Implicit conversion to PechkinPaperSize
                    Margins =
                    {
                        All = 0.5,
                        Unit = Unit.Centimeters
                    },
                    Orientation = PdfTuesPechkin.CreateOrientacao(orientacao)
                },
                Objects = {
                    new ObjectSettings {
                        HtmlText = html,
                        ProduceExternalLinks = true,
                        HeaderSettings = {
                        },
                        FooterSettings = {
                            HtmlUrl = footer,
                        },
                        LoadSettings = {
                            ZoomFactor = 0,
                        },
                        WebSettings = {
                             LoadImages = true,
                             PrintBackground= true,
                             PrintMediaType = true,
                        }
                    }
                }
            };
            return TuesPechkin.Factory.Create().Convert(document);
        }

        public byte[] ParseTipoPapel(string html, string largura, string altura, double marginTop, double marginRight, double marginBottom, double marginLeft, TuesPechkin.Unit unit)
        {
            MemoryStream memoryStream = new MemoryStream();
            return memoryStream.ToArray();
        }

        public byte[] ParseTipoPapel(string html, string largura, string altura, double marginTop, double marginRight, double marginBottom, double marginLeft, Unit unit, TipoOrientacaoPdf orientacao)
        {
            float paperWidth = 240.0f;
            float paperHeight = 190.0f;

            byte[] bytes = new byte[] { };

            //1: Cria o Documento objeto
            using (Document document = new Document(new Rectangle(paperWidth, paperHeight), (float)marginLeft, (float)marginRight, (float)marginTop, (float)marginBottom))
            {
                using (MemoryStream msOutput = new MemoryStream())
                {
                    //2: Associa o documento ao writer
                    using (PdfWriter writer = PdfWriter.GetInstance(document, msOutput))
                    {
                        //3: Associar parser ao documento criado
                        HTMLWorker worker = new HTMLWorker(document);

                        //4: Abre o documento para gravação
                        document.Open();
                        document.AddAuthor("CloudMe");
                        document.AddCreator("CLoudMe");

                        worker.StartDocument();

                        //5: Realiza o Parser
                        worker.Parse(new StringReader(html));

                        //6: Finaliza os objetos
                        worker.EndDocument();
                        worker.Close();
                    }

                    bytes = msOutput.ToArray();
                }
                document.Close();
            }

            return bytes;
        }

        #endregion Public Methods
    }
}
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Web;
using TuesPechkin;

namespace MediCLoud.Pdf.Entity
{
    public class PdfTuesPechkin : IPdfWriter
    {
        public static GlobalSettings.PaperOrientation CreateOrientacao(TipoOrientacaoPdf orientecao)
        {
            GlobalSettings.PaperOrientation orientation;

            switch (orientecao)
            {
                case TipoOrientacaoPdf.Retrato: orientation = GlobalSettings.PaperOrientation.Portrait;
                    break;
                case TipoOrientacaoPdf.Paisagem: orientation = GlobalSettings.PaperOrientation.Landscape;
                    break;
                default: orientation = GlobalSettings.PaperOrientation.Portrait;
                    break;
            }

            return orientation;
        }

        public byte[] Parse(string html)
        {
            HtmlToPdfDocument document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    //DocumentTitle = "Pretty Websites",/
                    PaperSize = PaperKind.A4, // Implicit conversion to PechkinPaperSize
                    //Margins =
                    //{
                    //    All = 0.5,
                    //    Unit = Unit.Centimeters
                    //}
                },
                Objects = {
                    new ObjectSettings {
                        HtmlText = html,
                        ProduceExternalLinks = true,
                        HeaderSettings = { 
                        },
                        FooterSettings = {
                        },
                        LoadSettings = {
                            ZoomFactor = 1.5,
                        },
                        WebSettings={
                             LoadImages = true,
                             PrintBackground= true,
                             PrintMediaType = true,
                        }
                        
                    }
                }
            };
            return TuesPechkin.Factory.Create().Convert(document);
        }
        public byte[] Parse(string html, double marginTop, double marginRight, double marginBottom, double marginLeft, Unit unit)
        {
            HtmlToPdfDocument document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    Margins =
                    {
                        Top = marginTop,
                        Right = marginRight,
                        Bottom = marginBottom,
                        Left = marginLeft,
                        Unit = unit
                    }
                },
                Objects = {
                    new ObjectSettings {
                        HtmlText = html,
                        ProduceExternalLinks = true,
                        HeaderSettings = { 
                        },
                        FooterSettings = {
                        },
                        LoadSettings = {
                            ZoomFactor = 1.5,
                        },
                        WebSettings={
                             LoadImages = true,
                             PrintBackground= true,
                             PrintMediaType = true,
                        }
                        
                    }
                }
            };

            return TuesPechkin.Factory.Create().Convert(document);
        }

        public byte[] ParseOrientacao(string html, TipoOrientacaoPdf orientacao)
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
                        },
                        LoadSettings = {
                            ZoomFactor = 1.5,
                        },
                        WebSettings={
                             LoadImages = true,
                             PrintBackground= true,
                             PrintMediaType = true,
                        }
                        
                    }
                }
            };
            return TuesPechkin.Factory.Create().Convert(document);
        }
        public byte[] ParseTipoPapel(string html, string largura, string altura, double marginTop, double marginRight, double marginBottom, double marginLeft, Unit unit)
        {
            HtmlToPdfDocument document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    DocumentTitle = "Cupom Fiscal",
                    PaperSize = new TuesPechkin.PechkinPaperSize(largura, altura),
                    Margins =
                    {
                        Top = marginTop,
                        Right = marginRight,
                        Bottom = marginBottom,
                        Left = marginLeft,
                        Unit = unit
                    }
                },
                Objects = {
                    new ObjectSettings {
                        HtmlText = html,
                        ProduceExternalLinks = true,
                        HeaderSettings = { 
                        },
                        FooterSettings = {
                        },
                        LoadSettings = {
                            ZoomFactor = 1.5,
                        },
                        WebSettings={
                             LoadImages = true,
                             PrintBackground= true,
                             PrintMediaType = true,
                        }
                        
                    }
                }
            };

            return TuesPechkin.Factory.Create().Convert(document);
        }
        public byte[] ParseCupomFiscal(string html)
        {
            HtmlToPdfDocument document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    DocumentTitle = "Cupom Fiscal"
                },
                Objects = {
                    new ObjectSettings {
                        HtmlText = html,
                        ProduceExternalLinks = true,
                        HeaderSettings = { 
                        },
                        FooterSettings = {
                        },
                        LoadSettings = {
                            ZoomFactor = 1.5,
                        },
                        WebSettings={
                             LoadImages = true,
                             PrintBackground= true,
                             PrintMediaType = true,
                        }
                        
                    }
                }
            };

            return TuesPechkin.Factory.Create().Convert(document);
        }

        public byte[] ParseTipoPapel(string html, string largura, string altura, double marginTop, double marginRight, double marginBottom, double marginLeft, Unit unit, TipoOrientacaoPdf orientacao)
        {
            HtmlToPdfDocument document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    DocumentTitle = "CloudMe",
                    PaperSize = new TuesPechkin.PechkinPaperSize(largura, altura),
                    Margins =
                    {
                        Top = marginTop,
                        Right = marginRight,
                        Bottom = marginBottom,
                        Left = marginLeft,
                        Unit = unit
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
                        },
                        LoadSettings = {
                            ZoomFactor = 1.5,
                        },
                        WebSettings={
                             LoadImages = true,
                             PrintBackground= true,
                             PrintMediaType = true,
                        }

                    }
                }
            };

            return TuesPechkin.Factory.Create().Convert(document);
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
                        Bottom = 3.5,
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
                            ZoomFactor = 1.5,
                        },
                        WebSettings={
                             LoadImages = true,
                             PrintBackground= true,
                             PrintMediaType = true,
                        }
                        
                    }
                }
            };
            return TuesPechkin.Factory.Create().Convert(document);
        }
    }    
}

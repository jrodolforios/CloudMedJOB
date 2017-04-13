using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCLoud.Pdf.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MediCloud.BusinessProcess.Util.Enum.Cliente;

namespace MediCloud.BusinessProcess.Cliente.Reports
{
    public class ASOReports
    {
        MOVIMENTO _movimento = null;
        ASOReportEnum _tipoASOReport = ASOReportEnum.indefinido;
        public ASOReports(MOVIMENTO movimento, ASOReportEnum tipoASOReport)
        {
            _movimento = movimento;
            _tipoASOReport = tipoASOReport;
        }

        public byte[] generate()
        {
            byte[] retorno = null;
            PdfTuesPechkin PDFGen = new PdfTuesPechkin();
            string template = ReportUtil.GetASOTemplate(_tipoASOReport);

            switch (_tipoASOReport)
            {
                case ASOReportEnum.imprimirComMedCoord:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(template);
                    break;
                default:
                    retorno = null;
                    break;
            }

            return retorno;
        }
    }
}

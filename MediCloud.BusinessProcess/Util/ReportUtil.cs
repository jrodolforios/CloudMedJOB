using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.BusinessProcess.Util.Enum;
using static MediCloud.BusinessProcess.Util.Enum.Cliente;
using System.IO;
using System.Configuration;
using static MediCloud.BusinessProcess.Util.Enum.Laudo;

namespace MediCloud.BusinessProcess.Util
{
    public class ReportUtil
    {
        internal static string GetASOTemplate(ASOReportEnum tipoASOReport)
        {
            string path = ConfigurationManager.AppSettings["TemplatesPath"] + "\\ASO\\";

            switch (tipoASOReport)
            {
                case ASOReportEnum.imprimirComMedCoord:
                    return recoverTemplateByFileName(path + tipoASOReport.ToString() + ".html");
                case ASOReportEnum.imprimirSemMedCoord:
                    return recoverTemplateByFileName(path + tipoASOReport.ToString() + ".html");
                case ASOReportEnum.imprimirReciboASO:
                    return recoverTemplateByFileName(path + tipoASOReport.ToString() + ".html");
                case ASOReportEnum.imprimirListaDeProcedimentos:
                    return recoverTemplateByFileName(path + tipoASOReport.ToString() + ".html");
                case ASOReportEnum.imprimirFichaClinica:
                    return recoverTemplateByFileName(path + tipoASOReport.ToString() + ".html");
                default:
                    return string.Empty;
            }
        }

        internal static string GetLaudoTemplate(Enum.Laudo.LaudoReportEnum tipoLaudoReport)
        {
            string path = ConfigurationManager.AppSettings["TemplatesPath"] + "\\Laudo\\";

            switch (tipoLaudoReport)
            {
                case LaudoReportEnum.imprimirLaudo:
                    return recoverTemplateByFileName(path + tipoLaudoReport.ToString() + ".html");
                default:
                    return string.Empty;
            }
        }

        private static string recoverTemplateByFileName(string fileName)
        {
            string template = null;

            string path = fileName;

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = string.Empty;
                File.WriteAllText(path, createText);
            }

            // Open the file to read from.
            template = File.ReadAllText(path);
            Console.WriteLine(template);

            return template;
        }
    }
}

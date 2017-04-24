using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCLoud.Pdf.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MediCloud.BusinessProcess.Util.Enum.Cliente;
using MediCloud.BusinessProcess.Util.Enum;
using static MediCloud.BusinessProcess.Util.Enum.Laudo;

namespace MediCloud.BusinessProcess.Laudo.Reports
{
    public class LaudoReports
    {
        LAUDORX _laudoRX = null;
        LaudoReportEnum _tipoLaudoReport = LaudoReportEnum.indefinido;
        INFORMACOES_CLINICA _infoClinica = null;

        public LaudoReports(LAUDORX laudoRX, LaudoReportEnum tipoLaudoReport, INFORMACOES_CLINICA infoClinica)
        {
            _laudoRX = laudoRX;
            _tipoLaudoReport = tipoLaudoReport;
            _infoClinica = infoClinica;
        }

        public byte[] generate(params string[] args)
        {
            byte[] retorno = null;
            PdfTuesPechkin PDFGen = new PdfTuesPechkin();
            string template = ReportUtil.GetLaudoTemplate(_tipoLaudoReport);

            switch (_tipoLaudoReport)
            {
                case LaudoReportEnum.imprimirLaudo:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosLaudo(template));
                    break;
                default:
                    retorno = null;
                    break;
            }

            return retorno;
        }

        #region imprimirLaudo
        private string substituirParametrosLaudo(string template)
        {
            template = template.Replace("[%DadosEmpresaCabecalho%]", _infoClinica.DADOSCABECALHOREL);
            template = template.Replace("[%CidadeEstadoClinica%]", _infoClinica.CIDADEESTADOCLINICA);
            template = template.Replace("[%EnderecoClinica%]", _infoClinica.ENDERECOCLINICA);
            template = template.Replace("[%TelefoneClinica%]", _infoClinica.TELEFONECLINICA);
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);


            return template;
        }
        #endregion

    }
}

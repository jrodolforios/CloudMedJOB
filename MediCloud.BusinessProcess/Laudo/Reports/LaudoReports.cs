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
            template = template.Replace("[%InformacoesClinica%]", _infoClinica.DADOSCABECALHOREL);
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);

            template = template.Replace("[%Rodape%]", _laudoRX.RODAPE);
            template = template.Replace("[%Conclusao%]", _laudoRX.CONCLUSAO);
            template = template.Replace("[%CorpoLaudo%]", _laudoRX.LAUDO);

            template = template.Replace("[%IdMovPRO%]", ((int)_laudoRX.IDMOVPRO).ToString());
            template = template.Replace("[%Idade%]", _laudoRX.IDADE);
            template = template.Replace("[%DataLaudo%]", _laudoRX.DATA.ToShortDateString());
            template = template.Replace("[%RGPaciente%]", _laudoRX.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.FUNCIONARIO.RG);
            template = template.Replace("[%Paciente%]", _laudoRX.PACIENTE);
            template = template.Replace("[%NomeProcedimento%]", _laudoRX.MOVIMENTO_PROCEDIMENTO.PROCEDIMENTO?.PROCEDIMENTO1);

            return template;
        }
        #endregion

    }
}

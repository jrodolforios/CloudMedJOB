using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCLoud.Pdf.Entity;
using static MediCloud.BusinessProcess.Util.Enum.Laudo;

namespace MediCloud.BusinessProcess.Laudo.Reports
{
    public class LaudoReports
    {
        #region Private Fields

        private INFORMACOES_CLINICA _infoClinica = null;
        private LAUDOAUD _laudoAud = null;
        private LAUDORX _laudoRX = null;
        private LAUDOAV _laudoVisao = null;
        private LaudoReportEnum _tipoLaudoReport = LaudoReportEnum.indefinido;

        #endregion Private Fields

        #region Public Constructors

        public LaudoReports(LAUDOAV laudoVisao, LaudoReportEnum tipoLaudoReport, INFORMACOES_CLINICA infoClinica)
        {
            _laudoVisao = laudoVisao;
            _tipoLaudoReport = tipoLaudoReport;
            _infoClinica = infoClinica;
        }

        public LaudoReports(LAUDOAUD laudoAudio, LaudoReportEnum tipoLaudoReport, INFORMACOES_CLINICA infoClinica)
        {
            _laudoAud = laudoAudio;
            _tipoLaudoReport = tipoLaudoReport;
            _infoClinica = infoClinica;
        }

        public LaudoReports(LAUDORX laudoRX, LaudoReportEnum tipoLaudoReport, INFORMACOES_CLINICA infoClinica)
        {
            _laudoRX = laudoRX;
            _tipoLaudoReport = tipoLaudoReport;
            _infoClinica = infoClinica;
        }

        #endregion Public Constructors



        #region Public Methods

        public byte[] generate(params string[] args)
        {
            byte[] retorno = null;
            PdfTuesPechkin PDFGen = new PdfTuesPechkin();
            string template = ReportUtil.GetLaudoTemplate(_tipoLaudoReport);

            switch (_tipoLaudoReport)
            {
                case LaudoReportEnum.imprimirLaudoRaioX:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosLaudoRaioX(template));
                    break;

                case LaudoReportEnum.imprimirLaudoVisao:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosLaudoVisao(template));
                    break;

                case LaudoReportEnum.imprimirAudiometria:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosLaudoAud(template));
                    break;

                default:
                    retorno = null;
                    break;
            }

            return retorno;
        }

        #endregion Public Methods



        #region Private Methods

        private string substituirParametrosLaudoAud(string template)
        {
            template = template.Replace("[%DescricaoClinica%]", _infoClinica.DADOSCABECALHOREL);
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);

            template = template.Replace("[%NomePaciente%]", _laudoAud.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%RGPaciente%]", _laudoAud.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.FUNCIONARIO.RG);
            template = template.Replace("[%NomeCliente%]", _laudoAud.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.CLIENTE.RAZAOSOCIAL);
            template = template.Replace("[%DataNascimento%]", _laudoAud.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.FUNCIONARIO.NASCIMENTO?.ToShortDateString());
            template = template.Replace("[%NomeReferente%]", _laudoAud.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.MOVIMENTO_REFERENTE.NOMEREFERENCIA);
            template = template.Replace("[%NomeCargo%]", _laudoAud.MOVIMENTO_PROCEDIMENTO.MOVIMENTO.CARGO.CARGO1);

            return template;
        }

        #endregion Private Methods

        #region imprimirLaudoVisao

        private string substituirParametrosLaudoVisao(string template)
        {
            template = template.Replace("[%InformacoesClinica%]", _infoClinica.DADOSCABECALHOREL);
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);

            template = template.Replace("[%Paciente%]", _laudoVisao.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%Cliente%]", _laudoVisao.CLIENTE.RAZAOSOCIAL);
            template = template.Replace("[%Cargo%]", _laudoVisao.CARGO.CARGO1);
            template = template.Replace("[%DataNascimento%]", _laudoVisao.FUNCIONARIO.NASCIMENTO.HasValue ? _laudoVisao.FUNCIONARIO.NASCIMENTO.Value.ToShortDateString() : string.Empty);
            template = template.Replace("[%RG%]", _laudoVisao.FUNCIONARIO.RG);
            template = template.Replace("[%Correcao%]", _laudoVisao.CORRECAO);
            template = template.Replace("[%OD%]", _laudoVisao.OD);
            template = template.Replace("[%OE%]", _laudoVisao.OE);
            template = template.Replace("[%COD%]", _laudoVisao.COD);
            template = template.Replace("[%COE%]", _laudoVisao.COE);
            template = template.Replace("[%Estrabismo%]", _laudoVisao.ESTRABISMO);
            template = template.Replace("[%VisaoCromatica%]", _laudoVisao.VISAOCROMATICA);
            template = template.Replace("[%Conclusao%]", _laudoVisao.CONCLUSAO);
            template = template.Replace("[%Data%]", _laudoVisao.DATALAUDO.ToShortDateString());

            return template;
        }

        #endregion imprimirLaudoVisao

        #region imprimirLaudoRaioX

        private string substituirParametrosLaudoRaioX(string template)
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

        #endregion imprimirLaudoRaioX
    }
}
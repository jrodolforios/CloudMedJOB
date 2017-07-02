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

namespace MediCloud.BusinessProcess.Cliente.Reports
{
    public class ASOReports
    {
        MOVIMENTO _movimento = null;
        ASOReportEnum _tipoASOReport = ASOReportEnum.indefinido;
        private Dictionary<NATUREZA, List<RISCO>> _riscosENaturezas = new Dictionary<NATUREZA, List<RISCO>>();
        INFORMACOES_CLINICA _infoClinica = null;

        public ASOReports(MOVIMENTO movimento, ASOReportEnum tipoASOReport, INFORMACOES_CLINICA infoClinica)
        {
            _movimento = movimento;
            _tipoASOReport = tipoASOReport;
            _infoClinica = infoClinica;
        }

        public ASOReports(INFORMACOES_CLINICA infoClinica, MOVIMENTO aso, Dictionary<NATUREZA, List<RISCO>> riscosENaturezas, ASOReportEnum imprimirComMedCoord)
            : this(aso, imprimirComMedCoord, infoClinica)
        {
            this._riscosENaturezas = riscosENaturezas;
        }

        public byte[] generate(params string[] args)
        {
            byte[] retorno = null;
            PdfTuesPechkin PDFGen = new PdfTuesPechkin();
            string template = ReportUtil.GetASOTemplate(_tipoASOReport);

            switch (_tipoASOReport)
            {
                case ASOReportEnum.imprimirComMedCoord:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosMedCoord(template));
                    break;
                case ASOReportEnum.imprimirSemMedCoord:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosSemMedCoord(template));
                    break;
                case ASOReportEnum.imprimirReciboASO:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosReciboASO(template));
                    break;
                case ASOReportEnum.imprimirListaDeProcedimentos:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosListaDeProcedimentos(template));
                    break;
                case ASOReportEnum.imprimirFichaClinica:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosFichaClinica(template));
                    break;
                default:
                    retorno = null;
                    break;
            }

            return retorno;
        }

        #region imprimirSemMedCoord
        private string substituirParametrosSemMedCoord(string template)
        {
            template = template.Replace("[%Cliente%]", _movimento.CLIENTE.NOMEFANTASIA);
            template = template.Replace("[%Funcionario%]", _movimento.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%Setor%]", _movimento.SETOR.SETOR1);
            template = template.Replace("[%Cargo%]", _movimento.CARGO.CARGO1);
            template = template.Replace("[%DataExame%]", _movimento.DATA.ToShortDateString());
            template = template.Replace("[%DataNacimentoFuncionario%]", _movimento.FUNCIONARIO.NASCIMENTO.HasValue ? _movimento.FUNCIONARIO.NASCIMENTO.Value.ToShortDateString() : string.Empty);
            template = template.Replace("[%CalculoIdade%]", Util.Util.CalcularIdade(_movimento.FUNCIONARIO.NASCIMENTO).ToString());
            template = template.Replace("[%exposicao%]", PreencherRiscosENaturezas(_riscosENaturezas));
            template = template.Replace("[%procedimentos%]", PreencherProcedimentos(_movimento.MOVIMENTO_PROCEDIMENTO.ToList()));

            template = template.Replace("[%DadosEmpresaCabecalho%]", _infoClinica.DADOSCABECALHOREL);
            template = template.Replace("[%CidadeEstadoClinica%]", _infoClinica.CIDADEESTADOCLINICA);
            template = template.Replace("[%EnderecoClinica%]", _infoClinica.ENDERECOCLINICA);
            template = template.Replace("[%TelefoneClinica%]", _infoClinica.TELEFONECLINICA);
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);


            return template;
        }
        #endregion

        #region imprimirReciboASO
        private string substituirParametrosReciboASO(string template)
        {
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);
            template = template.Replace("[%DadosEmpresaCabecalho%]", _infoClinica.DADOSCABECALHOREL);
            template = template.Replace("[%Cliente%]", _movimento.CLIENTE.RAZAOSOCIAL);
            template = template.Replace("[%ValorTotalASO%]", calcularValorTotalDeASO());
            template = template.Replace("[%IdMov%]", ((int)_movimento.IDMOV).ToString());
            template = template.Replace("[%NomeFuncionario%]", _movimento.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%RazaoSocialClinica%]", _infoClinica.RAZAOSOCIAL);
            template = template.Replace("[%CNPJClinica%]", _infoClinica.CNPJ);
            template = template.Replace("[%Procedimentos%]", PreencherProcedimentos(_movimento.MOVIMENTO_PROCEDIMENTO.ToList()));
            template = template.Replace("[%EnderecoClinica%]", _infoClinica.ENDERECOCLINICA);
            template = template.Replace("[%CidadeEstadoClinica%]", _infoClinica.CIDADEESTADOCLINICA);
            template = template.Replace("[%DataEmissaoPorExtenso%]", Util.Util.dataToExtenso(DateTime.Now));
            template = template.Replace("[%ValorToalASOPorExtenso%]", Util.Util.toExtenso(Convert.ToDecimal(calcularValorTotalDeASO())));


            return template;
        }

        private string calcularValorTotalDeASO()
        {
            decimal valorTotalDaASO = 0;
            _movimento.MOVIMENTO_PROCEDIMENTO.ToList().ForEach(x =>
            {
                valorTotalDaASO += (x.TOTAL.HasValue ? x.TOTAL.Value : 0);
            });

            return string.Format("{0:n2}", valorTotalDaASO);
        }
        #endregion

        #region imprimirComMedCoord
        private string substituirParametrosMedCoord(string template)
        {

            template = template.Replace("[%Cliente%]", _movimento.CLIENTE.NOMEFANTASIA);
            template = template.Replace("[%Funcionario%]", _movimento.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%Setor%]", _movimento.SETOR.SETOR1);
            template = template.Replace("[%Cargo%]", _movimento.CARGO.CARGO1);
            template = template.Replace("[%nomeMedicoCoord%]", _movimento.CLIENTE.EPCMSO?.ELABORADORPCMSO);
            template = template.Replace("[%DataExame%]", _movimento.DATA.ToShortDateString());
            template = template.Replace("[%DataNacimentoFuncionario%]", _movimento.FUNCIONARIO.NASCIMENTO.HasValue ? _movimento.FUNCIONARIO.NASCIMENTO.Value.ToShortDateString() : string.Empty);
            template = template.Replace("[%CalculoIdade%]", Util.Util.CalcularIdade(_movimento.FUNCIONARIO.NASCIMENTO).ToString());
            template = template.Replace("[%exposicao%]", PreencherRiscosENaturezas(_riscosENaturezas));
            template = template.Replace("[%procedimentos%]", PreencherProcedimentos(_movimento.MOVIMENTO_PROCEDIMENTO.ToList()));

            template = template.Replace("[%DadosEmpresaCabecalho%]", _infoClinica.DADOSCABECALHOREL);
            template = template.Replace("[%CidadeEstadoClinica%]", _infoClinica.CIDADEESTADOCLINICA);
            template = template.Replace("[%EnderecoClinica%]", _infoClinica.ENDERECOCLINICA);
            template = template.Replace("[%TelefoneClinica%]", _infoClinica.TELEFONECLINICA);
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);


            return template;
        }

        private string PreencherProcedimentos(List<MOVIMENTO_PROCEDIMENTO> movimentoProcedimento)
        {
            StringBuilder strRetorno = new StringBuilder();

            movimentoProcedimento.ForEach(x =>
            {
                strRetorno.AppendLine("<br/>");
                strRetorno.AppendLine($"{x.DATAEXAME.Value.ToShortDateString()} - {x.PROCEDIMENTO.PROCEDIMENTO1}");
            });

            return strRetorno.ToString();
        }

        private string PreencherRiscosENaturezas(Dictionary<NATUREZA, List<RISCO>> riscosENaturezas)
        {
            StringBuilder strRetorno = new StringBuilder();

            foreach (var item in riscosENaturezas)
            {
                strRetorno.AppendLine($"- {item.Key.NATUREZA1}");

                item.Value.ForEach(x =>
                {
                    strRetorno.AppendLine("<br/>");
                    strRetorno.AppendLine($"&nbsp;&nbsp;&nbsp;- {x.RISCO1}");
                });
                strRetorno.AppendLine("<br/>");
                strRetorno.AppendLine("<br/>");
                strRetorno.AppendLine();
            }

            return strRetorno.ToString();
        }
        #endregion

        #region imprimirListaDeProcedimentos
        private string substituirParametrosListaDeProcedimentos(string template)
        {
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);
            template = template.Replace("[%DataHoraEmissao%]", DateTime.Now.ToShortDateString());
            template = template.Replace("[%IdMovimento%]", ((int)_movimento.IDMOV).ToString());
            template = template.Replace("[%Cliente%]", _movimento.CLIENTE.RAZAOSOCIAL);
            template = template.Replace("[%Funcionario%]", _movimento.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%RGFuncionario%]", _movimento.FUNCIONARIO.RG);
            template = template.Replace("[%Setor%]", _movimento.SETOR.SETOR1);
            template = template.Replace("[%Cargo%]", _movimento.CARGO.CARGO1);
            template = template.Replace("[%DataNacimentoFuncionario%]", _movimento.FUNCIONARIO.NASCIMENTO.HasValue ? _movimento.FUNCIONARIO.NASCIMENTO.Value.ToShortDateString() : string.Empty);
            template = template.Replace("[%EnderecoEmpresa%]", _movimento.FUNCIONARIO.ENDERECO);
            template = template.Replace("[%Observacoes%]", _movimento.OBSERVACAO);
            template = template.Replace("[%Procedimentos%]", PreencherProcedimentosComCaixaDeSelecao(_movimento.MOVIMENTO_PROCEDIMENTO.ToList()));

            return template;
        }

        private string PreencherProcedimentosComCaixaDeSelecao(List<MOVIMENTO_PROCEDIMENTO> movimentoProcedimento)
        {
            StringBuilder strRetorno = new StringBuilder();

            movimentoProcedimento.ForEach(x =>
            {
                strRetorno.AppendLine("<br/>");
                strRetorno.AppendLine($"(&nbsp;&nbsp;) [{x.IDMOVPRO}] {x.PROCEDIMENTO.PROCEDIMENTO1}");
            });

            return strRetorno.ToString();
        }

        #endregion

        #region imprimirFichaClinica
        private string substituirParametrosFichaClinica(string template)
        {
            template = template.Replace("[%Referente%]", _movimento.MOVIMENTO_REFERENTE.NOMEREFERENCIA);
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);
            template = template.Replace("[%NomeFuncionario%]", _movimento.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%Cargo%]", _movimento.CARGO.CARGO1);
            template = template.Replace("[%Cliente%]", _movimento.CLIENTE.NOMEFANTASIA);
            template = template.Replace("[%Nascimento%]", _movimento.FUNCIONARIO.NASCIMENTO.HasValue ? _movimento.FUNCIONARIO.NASCIMENTO.Value.ToShortDateString() : string.Empty);
            template = template.Replace("[%RazaoSocialCliente%]", _movimento.CLIENTE.RAZAOSOCIAL);
            template = template.Replace("[%RG%]", _movimento.FUNCIONARIO.RG);
            template = template.Replace("[%NomeClinica%]", _infoClinica.NOMECLINICA);
            template = template.Replace("[%DataHora%]", DateTime.Now.ToShortDateString());
            template = template.Replace("[%IdMov%]", ((int)_movimento.IDMOV).ToString());
            template = template.Replace("[%PCMSO%]", _movimento.CLIENTE.EPCMSO?.ELABORADORPCMSO);
            template = template.Replace("[%FormaPag%]", _movimento.FORMADEPAGAMENTO.FORMADEPAGAMENTO1);
            template = template.Replace("[%ValorTotalASO%]", ControleDeASO.CalcularValorTotalDeASO(_movimento).ToString("0.00"));
            template = template.Replace("[%Observacoes%]", _movimento.OBSERVACAO);
            template = template.Replace("[%NomeUsuario%]", _movimento.USUARIO);

            return template;
        }
        #endregion
    }
}

using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCLoud.Pdf.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MediCloud.BusinessProcess.Util.Enum.Cliente;

namespace MediCloud.BusinessProcess.Cliente.Reports
{
    public class ASOReports
    {
        #region Private Fields

        private INFORMACOES_CLINICA _infoClinica = null;
        private MOVIMENTO _movimento = null;
        private Dictionary<NATUREZA, List<RISCO>> _riscosENaturezas = new Dictionary<NATUREZA, List<RISCO>>();
        private ASOReportEnum _tipoASOReport = ASOReportEnum.indefinido;

        #endregion Private Fields

        #region Public Constructors

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

        #endregion Public Constructors



        #region Public Methods

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

                case ASOReportEnum.imprimirOrdemServicoASO:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametrosOrdemDeServico(template));
                    break;

                default:
                    retorno = null;
                    break;
            }

            return retorno;
        }

        #endregion Public Methods

        #region imprimirOrdemServicoASO

        private string substituirParametrosOrdemDeServico(string template)
        {
            StringBuilder relatorioProcessado = new StringBuilder();
            string ordemDeServicoTemp = string.Empty;
            if (this._movimento.MOVIMENTO_PROCEDIMENTO.Any())
                this._movimento.MOVIMENTO_PROCEDIMENTO.ToList().ForEach(x =>
                {
                    ordemDeServicoTemp = template;

                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%DadosEmpresaCabecalho%]", _infoClinica.DADOSCABECALHOREL);
                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);

                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%IDMOV%]", ((int)_movimento.IDMOV).ToString());
                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%IDMOVPRO%]", ((int)x.IDMOVPRO).ToString());
                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%NomeEmpresa%]", _movimento.CLIENTE.RAZAOSOCIAL);
                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%NomeFuncionario%]", _movimento.FUNCIONARIO.FUNCIONARIO1);
                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%Cargo%]", _movimento.CARGO.CARGO1);

                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%RG%]", _movimento.FUNCIONARIO.RG);
                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%DataNascimento%]", _movimento.FUNCIONARIO.NASCIMENTO?.ToShortDateString());
                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%Referente%]", _movimento.MOVIMENTO_REFERENTE.NOMEREFERENCIA);
                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%NomeProcedimento%]", x.PROCEDIMENTO.PROCEDIMENTO1);

                    ordemDeServicoTemp = ordemDeServicoTemp.Replace("[%DataAgora%]", DateTime.Now.ToShortDateString());

                    ordemDeServicoTemp += "<div style=\"page-break-before:always; \"> </div>";

                    relatorioProcessado.Append(ordemDeServicoTemp);
                });
            else
                throw new InvalidOperationException("Não é possível imprimir ordens de serviço pois nenhum procedimento foi cadastrado para este movimento.");

            return relatorioProcessado.ToString();
        }

        #endregion imprimirOrdemServicoASO

        #region imprimirSemMedCoord

        private string substituirParametrosSemMedCoord(string template)
        {
            template = template.Replace("[%Cliente%]", _movimento.CLIENTE.NOMEFANTASIA);
            template = template.Replace("[%CNPJCliente%]", _movimento.CLIENTE.CPFCNPJ.Length == 14 ? Util.Util.InserirMascaraCNPJ(_movimento.CLIENTE.CPFCNPJ) : Util.Util.InserirMascaraCPF(_movimento.CLIENTE.CPFCNPJ));
            template = template.Replace("[%CPFCNPJ%]", _movimento.CLIENTE.CPFCNPJ.Length == 14 ? "CNPJ" : "CPF");
            template = template.Replace("[%Funcionario%]", _movimento.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%Setor%]", _movimento.SETOR.SETOR1);
            template = template.Replace("[%Cargo%]", _movimento.CARGO.CARGO1);
            template = template.Replace("[%DataExame%]", _movimento.DATA.ToShortDateString());
            template = template.Replace("[%DataNacimentoFuncionario%]", _movimento.FUNCIONARIO.NASCIMENTO.HasValue ? _movimento.FUNCIONARIO.NASCIMENTO.Value.ToShortDateString() : string.Empty);
            template = template.Replace("[%CalculoIdade%]", Util.Util.CalcularIdade(_movimento.FUNCIONARIO.NASCIMENTO).ToString());
            template = template.Replace("[%exposicao%]", PreencherRiscosENaturezas(_riscosENaturezas));
            template = template.Replace("[%procedimentos%]", PreencherProcedimentos(_movimento.MOVIMENTO_PROCEDIMENTO.ToList()));
            template = template.Replace("[%Referencia%]", _movimento.MOVIMENTO_REFERENTE.NOMEREFERENCIA);

            template = template.Replace("[%DadosEmpresaCabecalho%]", _infoClinica.DADOSCABECALHOREL);
            template = template.Replace("[%CidadeEstadoClinica%]", _infoClinica.CIDADEESTADOCLINICA);
            template = template.Replace("[%EnderecoClinica%]", _infoClinica.ENDERECOCLINICA);
            template = template.Replace("[%TelefoneClinica%]", _infoClinica.TELEFONECLINICA);
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);

            return template;
        }

        #endregion imprimirSemMedCoord

        #region imprimirReciboASO

        private string calcularValorTotalDeASO()
        {
            decimal valorTotalDaASO = 0;
            _movimento.MOVIMENTO_PROCEDIMENTO.ToList().ForEach(x =>
            {
                valorTotalDaASO += (x.TOTAL.HasValue ? x.TOTAL.Value : 0);
            });

            return string.Format("{0:n2}", valorTotalDaASO);
        }

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

        #endregion imprimirReciboASO

        #region imprimirComMedCoord

        private string PreencherProcedimentos(List<MOVIMENTO_PROCEDIMENTO> movimentoProcedimento)
        {
            StringBuilder strRetorno = new StringBuilder();

            movimentoProcedimento.ForEach(x =>
            {
                strRetorno.AppendLine("<br/>");
                strRetorno.AppendLine($"{(x.DATAEXAME.HasValue ? x.DATAEXAME.Value.ToShortDateString() : string.Empty)} - {x.PROCEDIMENTO.PROCEDIMENTO1}");
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

        private string substituirParametrosMedCoord(string template)
        {
            template = template.Replace("[%Cliente%]", _movimento.CLIENTE.NOMEFANTASIA);
            template = template.Replace("[%CNPJCliente%]", _movimento.CLIENTE.CPFCNPJ.Length == 14 ? Util.Util.InserirMascaraCNPJ(_movimento.CLIENTE.CPFCNPJ) : Util.Util.InserirMascaraCPF(_movimento.CLIENTE.CPFCNPJ));
            template = template.Replace("[%CPFCNPJ%]", _movimento.CLIENTE.CPFCNPJ.Length == 14 ? "CNPJ" : "CPF");
            template = template.Replace("[%Funcionario%]", _movimento.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%Setor%]", _movimento.SETOR.SETOR1);
            template = template.Replace("[%Cargo%]", _movimento.CARGO.CARGO1);
            template = template.Replace("[%nomeMedicoCoord%]", _movimento.CLIENTE.EPCMSO?.ELABORADORPCMSO);
            template = template.Replace("[%DataExame%]", _movimento.DATA.ToShortDateString());
            template = template.Replace("[%DataNacimentoFuncionario%]", _movimento.FUNCIONARIO.NASCIMENTO.HasValue ? _movimento.FUNCIONARIO.NASCIMENTO.Value.ToShortDateString() : string.Empty);
            template = template.Replace("[%CalculoIdade%]", Util.Util.CalcularIdade(_movimento.FUNCIONARIO.NASCIMENTO).ToString());
            template = template.Replace("[%exposicao%]", PreencherRiscosENaturezas(_riscosENaturezas));
            template = template.Replace("[%procedimentos%]", PreencherProcedimentos(_movimento.MOVIMENTO_PROCEDIMENTO.ToList()));
            template = template.Replace("[%Referencia%]", _movimento.MOVIMENTO_REFERENTE.NOMEREFERENCIA);

            template = template.Replace("[%DadosEmpresaCabecalho%]", _infoClinica.DADOSCABECALHOREL);
            template = template.Replace("[%CidadeEstadoClinica%]", _infoClinica.CIDADEESTADOCLINICA);
            template = template.Replace("[%EnderecoClinica%]", _infoClinica.ENDERECOCLINICA);
            template = template.Replace("[%TelefoneClinica%]", _infoClinica.TELEFONECLINICA);
            template = template.Replace("[%LogoEmpresa%]", _infoClinica.URLLOGO);

            return template;
        }

        #endregion imprimirComMedCoord

        #region imprimirListaDeProcedimentos

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

        #endregion imprimirListaDeProcedimentos

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
            template = template.Replace("[%DataHora%]", _movimento.DATA.ToShortDateString());
            template = template.Replace("[%IdMov%]", ((int)_movimento.IDMOV).ToString());
            template = template.Replace("[%PCMSO%]", _movimento.CLIENTE.EPCMSO?.ELABORADORPCMSO);
            template = template.Replace("[%FormaPag%]", _movimento.FORMADEPAGAMENTO.FORMADEPAGAMENTO1);
            template = template.Replace("[%ValorTotalASO%]", ControleDeASO.CalcularValorTotalDeASO(_movimento).ToString("0.00"));
            template = template.Replace("[%Observacoes%]", _movimento.OBSERVACAO);
            template = template.Replace("[%NomeUsuario%]", _movimento.USUARIO);

            return template;
        }

        #endregion imprimirFichaClinica
    }
}
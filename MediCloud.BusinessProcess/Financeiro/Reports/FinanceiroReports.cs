using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCLoud.Pdf.Entity;
using System.Collections.Generic;
using System.Linq;
using static MediCloud.BusinessProcess.Util.Enum.Financeiro;

namespace MediCloud.BusinessProcess.Financeiro.Reports
{
    public class FinanceiroReports
    {
        #region Private Fields

        private string _informacoesAdicionais;
        private INFORMACOES_CLINICA _informacoesDaClinica;
        private List<MOVIMENTO> _reportResult;
        private FinanceiroReportEnum _tipoRelatorioFinanceiro;

        #endregion Private Fields

        #region Public Constructors

        public FinanceiroReports(List<MOVIMENTO> reportResult, INFORMACOES_CLINICA informacoesDaClinica, FinanceiroReportEnum imprimirRelatorioDeMovimentos)
        {
            this._reportResult = reportResult;
            this._tipoRelatorioFinanceiro = imprimirRelatorioDeMovimentos;
            this._informacoesDaClinica = informacoesDaClinica;
        }

        public FinanceiroReports(List<MOVIMENTO> reportResult, INFORMACOES_CLINICA informacoesDaClinica, FinanceiroReportEnum imprimirRelatorioDeMovimentos, string informacoesAdicionais)
            : this(reportResult, informacoesDaClinica, imprimirRelatorioDeMovimentos)
        {
            this._informacoesAdicionais = informacoesAdicionais;
        }

        #endregion Public Constructors



        #region Public Methods

        public byte[] generate(params string[] args)
        {
            byte[] retorno = null;
            PdfTuesPechkin PDFGen = new PdfTuesPechkin();
            string template = ReportUtil.GetRelatorioFinanceiroTemplate(_tipoRelatorioFinanceiro);

            switch (_tipoRelatorioFinanceiro)
            {
                case FinanceiroReportEnum.imprimirRelatorioDeMovimentos:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).ParseOrientacao(substituirParametrosRelatorioDeMovimentos(template), TipoOrientacaoPdf.Paisagem);
                    break;

                case FinanceiroReportEnum.imprimirRelatorioAnaliticoDeFaturamento:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).ParseOrientacao(substituirParametrosRelatorioAnaliticoDeFaturamento(template), TipoOrientacaoPdf.Retrato);
                    break;

                default:
                    retorno = null;
                    break;
            }

            return retorno;
        }

        #endregion Public Methods



        #region Private Methods

        private string substituirParametrosRelatorioAnaliticoDeFaturamento(string template)
        {
            string corpoRelatorio = string.Empty;
            string relatorioFinal = string.Empty;
            FATURAMENTO faturamento;

            _reportResult.Where(idFat => idFat.IDFAT != null).Select(idFat => idFat.IDFAT).Distinct().ToList().ForEach(idFat =>
            {
                _reportResult.Where(idCli => idCli.IDFAT == idFat).Select(idCli => idCli.IDCLI).Distinct().ToList().ForEach(idCli =>
                {
                    faturamento = _reportResult.Where(x => x.IDCLI == idCli && x.IDFAT == idFat).First().FATURAMENTO;
                    relatorioFinal += $@"<div class=""cabecalho"">
                                        <div class=""cabecalhoSuperior"">
                                            <div class=""logoEmpresa""><img src=""{_informacoesDaClinica.URLLOGO}"" alt=""Logo da empresa"" /></div>
                                            <div class=""dadosEmpresa""><h2><b>Relatório Analítico de Faturamento</b></h2></div>
                                            <div class=""dadosRelatorio"">{faturamento.MES + "/" + faturamento.ANO + " - " + idFat}</div>
                                        </div>
                                    </div>
                                    <table width=""100%"" >
                                        <tr>
                                            <td style=""width:20%"" >&nbsp;</td>
                                            <td style=""width:60%"">
                                                <table style=""text-align: center; width:100%"">
                                                    <tr >
                                                        <td style=""border-bottom:1px solid; font-size:12pt""><b>Grupo de Clientes:</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td style=""font-size:14pt""><b>{_reportResult.Where(y => y.IDCLI == idCli && y.IDFAT == idFat).First().CLIENTE.RAZAOSOCIAL}</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td style=""font-size:10pt"">{_reportResult.Where(y => y.IDCLI == idCli && y.IDFAT == idFat).First().CLIENTE.RAZAOSOCIAL}</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style=""width:20%"">&nbsp;</td>
                                        </tr>
                                    </table>
                                    <table width=""100%"" >
                                        <tr style=""font-weight:bold"">
                                            <td style=""border-bottom:solid 1px"">Funcionário</td>
                                            <td style=""border-bottom:solid 1px"">Cargo</td>
                                            <td style=""border-bottom:solid 1px"">Exame</td>
                                            <td style=""border-bottom:solid 1px"">Data</td>
                                            <td style=""border-bottom:solid 1px"">Valor</td>
                                            <td style=""border-bottom:solid 1px"">Observação</td>
                                        </tr>";

                    _reportResult.Where(idFun => idFun.IDCLI == idCli && idFun.IDFAT == idFat).Select(idFun => idFun.IDFUN).Distinct().ToList().ForEach(idFun =>
                    {
                        _reportResult.Where(idCgo => idCgo.IDFUN == idFun && idCgo.IDFAT == idFat && idCgo.IDCLI == idCli).Select(idCgo => idCgo.IDCGO).Distinct().ToList().ForEach(idCgo =>
                        {
                            relatorioFinal += $@"<tr>
                                                <td colspan=""6"">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style=""border-bottom:solid 1px""><b>{_reportResult.Where(x => x.IDFUN == idFun && x.IDCGO == idCgo && x.IDFAT == idFat).First().FUNCIONARIO.FUNCIONARIO1}</b></td>
                                                <td style=""border-bottom:solid 1px""><b>{_reportResult.Where(x => x.IDFUN == idFun && x.IDCGO == idCgo && x.IDFAT == idFat).First().CARGO.CARGO1}</b></td>
                                                <td colspan=""4"" style=""border-bottom:solid 1px"">&nbsp;</td>
                                            </tr>";

                            _reportResult.Where(idMovPro => idMovPro.IDCGO == idCgo && idMovPro.IDFAT == idFat && idMovPro.IDCLI == idCli && idMovPro.IDFUN == idFun).First().MOVIMENTO_PROCEDIMENTO?.Distinct().ToList().ForEach(idMovPro =>
                            {
                                relatorioFinal += $@"<tr>
                                                    <td colspan=""2"" >&nbsp;</td>
                                                    <td style=""font-size:7pt"">{idMovPro.PROCEDIMENTO?.PROCEDIMENTO1}</td>
                                                    <td style=""font-size:7pt"">{idMovPro.DATAEXAME?.ToShortDateString()}</td>
                                                    <td style=""font-size:7pt"">{idMovPro.TOTAL}</td>
                                                    <td style=""font-size:7pt"">{idMovPro.OBSMOVTO}</td>
                                                </tr>";
                            });

                            relatorioFinal += $@"<tr>
                                                <td colspan=""2"">&nbsp;</td>
                                                <td style=""font-size:7pt; border-top:solid 1px; font-weight:bold;"">Exames: {_reportResult.Where(idMovPro => idMovPro.IDCGO == idCgo && idMovPro.IDFAT == idFat && idMovPro.IDCLI == idCli && idMovPro.IDFUN == idFun).First().MOVIMENTO_PROCEDIMENTO?.Count()}</td>
                                                <td style=""font-size:7pt; border-top:solid 1px; font-weight:bold;"">Total:</td>
                                                <td style=""font-size:7pt; border-top:solid 1px; font-weight:bold;"">R$ {_reportResult.Where(idMovPro => idMovPro.IDCGO == idCgo && idMovPro.IDFAT == idFat && idMovPro.IDCLI == idCli && idMovPro.IDFUN == idFun).First().MOVIMENTO_PROCEDIMENTO?.Select(x => x.TOTAL).Sum()}</td>
                                                <td style=""font-size:7pt; border-top:solid 1px; font-weight:bold;"">&nbsp;</td>
                                            </tr>";
                        });
                    });

                    relatorioFinal += $@"</table>
                                    <br />
                                    <br/>
                                    <div style=""text-align:right"">
                                        <b>Total da Empresa: R${_reportResult.Where(x => x.IDCLI == idCli && x.IDFAT == idFat).Sum(x => x.MOVIMENTO_PROCEDIMENTO?.Sum(y => y.VALOR))}</b>
                                    </div>
                                    <div class=""cabecalho"">
                                        {_informacoesAdicionais}
                                    </div>
                                    <div style=""page-break-before: always;""> </div>";
                });
            });

            template = template.Replace("[%CorpoRelatorio%]", relatorioFinal);

            return template;
        }

        private string substituirParametrosRelatorioDeMovimentos(string template)
        {
            string corpoRelatorio = string.Empty;
            int contagem = 0;
            decimal valorTotal = 0;

            _reportResult.ForEach(x =>
            {
                corpoRelatorio += string.Format(@"
                                <tr>
                                    <td colspan=""11"">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan=""10"" style=""border-bottom:dashed 1px""><b>{0}</b></td>
                                    <td colspan=""10"" style=""border-bottom:dashed 1px""><b>R$ {1}</b></td>
                                </tr>
                             ",
                             x.FUNCIONARIO.FUNCIONARIO1 + " (" + x.FUNCIONARIO.IDFUN + ") - " + x.CARGO.CARGO1 + " - " + x.CLIENTE.RAZAOSOCIAL + " (" + x.CLIENTE.IDCLI + ")",
                             x.MOVIMENTO_PROCEDIMENTO?.Sum(y => y.TOTAL)
                             );

                if (x.MOVIMENTO_PROCEDIMENTO.Any())
                {
                    x.MOVIMENTO_PROCEDIMENTO.Distinct().ToList().ForEach(y =>
                    {
                        corpoRelatorio += string.Format(@"
                                                    <tr>
                                                        <td>{0}</td>
                                                        <td>{1}</td>
                                                        <td>{2}</td>
                                                        <td>{3}</td>
                                                        <td>{4}</td>
                                                        <td>{5}</td>
                                                        <td>{6}</td>
                                                        <td>{7}</td>
                                                        <td>{8}</td>
                                                        <td>{9}</td>
                                                        <td>R$ {10}</td>
                                                    </tr>
                                                       ",
                                                       y.PROCEDIMENTO?.PROCEDIMENTO1,
                                                       y.PROFISSIONAIS?.PROFISSIONAL,
                                                       x.IDMOV,
                                                       y.FORNECEDOR?.RAZAOSOCIAL,
                                                       x.USUARIO,
                                                       x.TABELA.TABELA1,
                                                       y.DATAEXAME.HasValue ? y.DATAEXAME.Value.ToShortDateString() : string.Empty,
                                                       x.DATAMOV.HasValue ? x.DATAMOV.Value.ToShortDateString() : string.Empty,
                                                       y.VALOR.HasValue ? y.VALOR.Value.ToString("0.00") : string.Empty,
                                                       y.DESCONTO.HasValue ? y.DESCONTO.Value.ToString("0.00") : string.Empty,
                                                       y.TOTAL.HasValue ? y.TOTAL.Value.ToString("0.00") : string.Empty
                                               );
                        contagem++;
                        valorTotal += y.TOTAL.HasValue ? y.TOTAL.Value : 0;
                    });
                }
            });

            template = template.Replace("[%CorpoRelatorio%]", corpoRelatorio);

            template = template.Replace("[%LogoEmpresa%]", _informacoesDaClinica.URLLOGO);

            template = template.Replace("[%Contagem%]", contagem.ToString());
            template = template.Replace("[%ValorTotal%]", valorTotal.ToString("0.00"));

            return template;
        }

        #endregion Private Methods
    }
}
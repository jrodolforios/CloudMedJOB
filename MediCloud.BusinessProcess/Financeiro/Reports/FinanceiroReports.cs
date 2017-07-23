using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.BusinessProcess.Util.Enum;
using MediCloud.DatabaseModels;
using MediCLoud.Pdf.Entity;
using MediCloud.BusinessProcess.Util;
using static MediCloud.BusinessProcess.Util.Enum.Financeiro;

namespace MediCloud.BusinessProcess.Financeiro.Reports
{
    public class FinanceiroReports
    {
        private List<MOVIMENTO> _reportResult;
        private FinanceiroReportEnum _tipoRelatorioFinanceiro;
        private INFORMACOES_CLINICA _informacoesDaClinica;

        public FinanceiroReports(List<MOVIMENTO> reportResult, INFORMACOES_CLINICA informacoesDaClinica,FinanceiroReportEnum imprimirRelatorioDeMovimentos)
        {
            this._reportResult = reportResult;
            this._tipoRelatorioFinanceiro = imprimirRelatorioDeMovimentos;
            this._informacoesDaClinica = informacoesDaClinica;
        }

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
                default:
                    retorno = null;
                    break;
            }

            return retorno;
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
    }
}

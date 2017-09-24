using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.BusinessProcess.Util.Enum;
using MediCloud.DatabaseModels;
using MediCLoud.Pdf.Entity;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Cliente.Reports
{
    public class MovimentoReports
    {
        private List<SELECTANUAL> _reportResult;
        private INFORMACOES_CLINICA _informacoesDaClinica;
        private Util.Enum.Cliente.MovimentoReportEnum _tipoRelatorioMovimento;

        private DateTime _dataInicio;
        private DateTime _dataFim;

        public MovimentoReports(List<SELECTANUAL> resultado, INFORMACOES_CLINICA informacoesDaClinica, Util.Enum.Cliente.MovimentoReportEnum tipoRelatorioMovimento, DateTime dataInicio, DateTime dataFim)
        {
            this._reportResult = resultado;
            this._informacoesDaClinica = informacoesDaClinica;
            this._tipoRelatorioMovimento = tipoRelatorioMovimento;
            this._dataInicio = dataInicio;
            this._dataFim = dataFim;
        }

        public byte[] generate(params string[] args)
        {
            byte[] retorno = null;
            PdfTuesPechkin PDFGen = new PdfTuesPechkin();
            string template = ReportUtil.GetRelatorioMovimentoTemplate(_tipoRelatorioMovimento);

            switch (_tipoRelatorioMovimento)
            {
                case Util.Enum.Cliente.MovimentoReportEnum.imprimirRelatorioAnual:
                    retorno = PdfFactory.create(EnumPdfType.TuesPechkin).ParseOrientacao(substituirParametrosRelatorioAnual(template), TipoOrientacaoPdf.Retrato);
                    break;
                default:
                    retorno = null;
                    break;
            }

            return retorno;
        }

        private string substituirParametrosRelatorioAnual(string template)
        {
            string corpoRelatorio = string.Empty;

            _reportResult.Select(x => x.RAZAOSOCIAL + x.NOMEFANTASIA).Distinct().ToList().ForEach(x =>
            {
                corpoRelatorio += @"
                    <tr style=""font - weight:bold"">
                        <td style = ""border-bottom:solid 1px"" colspan = ""5"" ><b> RAZÃO SOCIAL: "+ _reportResult.Where(y => (y.RAZAOSOCIAL + y.NOMEFANTASIA) == x).First().RAZAOSOCIAL + @" </b></ td >
                     </tr >";

                corpoRelatorio += @"
                    <tr>
			        <td colspan=""5"" style=""padding-left:0px; padding-right:0px"">
				        <table width=""100%"" style=""border: 1px solid black"">
					        <tr>
						        <td style=""width:20%"" >Natureza do Exame</td>
						        <td style=""width:20%"" >Nº Anual Realizado</td>
						        <td style=""width:20%"" >Nº de Anormais</td>
						        <td style=""width:20%"" >Nº de resultados anormais X 100 Nº anual de exames</td>
						        <td style=""width:20%"" >Nº de exames para o ano seguinte</td>
					        </tr>";

                _reportResult.Where(y => (y.RAZAOSOCIAL + y.NOMEFANTASIA) == x).Select(y => y.CARGO).Distinct().ToList().ForEach(y =>
                {
                    corpoRelatorio += @"
                    <tr>
						<td colspan=""5""><b>FUNÇÃO:" + _reportResult.Where(z => (z.RAZAOSOCIAL + z.NOMEFANTASIA) == x && z.CARGO == y).First().CARGO + @"</b></td>
					</tr>";

                    _reportResult.Where(z => (z.RAZAOSOCIAL + z.NOMEFANTASIA) == x && z.CARGO == y).Select(z => z.PROCEDIMENTO).Distinct().ToList().ForEach(a =>
                    {
                        corpoRelatorio += @"					
                            <tr style=""text-align:center"" >
						        <td style=""text-align:left"" >" + a + @"</td>
						        <td >" + _reportResult.Where(b => (b.RAZAOSOCIAL + b.NOMEFANTASIA) == x && b.CARGO == y && b.PROCEDIMENTO == a).Count() + @"</td>
						        <td >0</td>
						        <td >0.00</td>
						        <td >" + _reportResult.Where(b => (b.RAZAOSOCIAL + b.NOMEFANTASIA) == x && b.CARGO == y && b.PROCEDIMENTO == a).Select(b => b.PROXIMOANO).ToList().Sum(b => Convert.ToInt32(b)) + @"</td>
					        </tr>";
                    });

                });

                    corpoRelatorio += @"
                                </table>
			                </td>
		                </tr>";
            });

            corpoRelatorio += @"
            <tr style=""text-align:center; font-weight: bold"" >
				<td style=""width:20%"" style=""text-align:left"">Total: </td>
				<td style=""width:20%"">" + _reportResult.Select(x => x.PROCEDIMENTO).Count() + @"</td>
				<td style=""width:20%"">0</td>
				<td style=""width:20%"">0.00</td>
				<td style=""width:20%"">" + _reportResult.Select(x => x.PROXIMOANO).ToList().Sum(x => Convert.ToInt32(x)) + @"</td>
			</tr>";

            template = template.Replace("[%CorpoRelatorio%]", corpoRelatorio);
            template = template.Replace("[%LogoEmpresa%]", _informacoesDaClinica.URLLOGO);
            template = template.Replace("[%DataInicio%]", _dataInicio.ToShortDateString());
            template = template.Replace("[%DataFim%]", _dataFim.ToShortDateString());
            template = template.Replace("[%DataHoje%]", DateTime.Now.ToShortDateString());

            return template;
        }
    }
}

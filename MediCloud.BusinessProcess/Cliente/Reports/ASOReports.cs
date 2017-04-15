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

        public ASOReports(MOVIMENTO movimento, ASOReportEnum tipoASOReport)
        {
            _movimento = movimento;
            _tipoASOReport = tipoASOReport;
        }

        public ASOReports(MOVIMENTO aso, Dictionary<NATUREZA, List<RISCO>> riscosENaturezas, ASOReportEnum imprimirComMedCoord)
            : this(aso, imprimirComMedCoord)
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
                    retorno =  PdfFactory.create(EnumPdfType.TuesPechkin).Parse(substituirParametros(template, _movimento));
                    break;
                default:
                    retorno = null;
                    break;
            }

            return retorno;
        }

        private string substituirParametros(string template, MOVIMENTO movimento)
        {
            template = template.Replace("[%Cliente%]", movimento.CLIENTE.NOMEFANTASIA);
            template = template.Replace("[%Funcionario%]", movimento.FUNCIONARIO.FUNCIONARIO1);
            template = template.Replace("[%Setor%]", movimento.SETOR.SETOR1);
            template = template.Replace("[%Cargo%]", movimento.CARGO.CARGO1);
            template = template.Replace("[%DataNacimentoFuncionario%]", movimento.FUNCIONARIO.NASCIMENTO.HasValue ? movimento.FUNCIONARIO.NASCIMENTO.Value.ToShortDateString() : string.Empty);
            template = template.Replace("[%CalculoIdade%]", Util.Util.CalcularIdade(movimento.FUNCIONARIO.NASCIMENTO).ToString());
            template = template.Replace("[%exposicao%]", PreencherRiscosENaturezas(_riscosENaturezas));
            template = template.Replace("[%procedimentos%]", PreencherProcedimentos(movimento.MOVIMENTO_PROCEDIMENTO.ToList()));

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

            foreach(var item in riscosENaturezas)
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
    }
}

using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code.Clientes;
using MediCloud.Code.Financeiro;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.View.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            base.EstahLogado();
            ViewBag.Title = "Início";

            IndexModel model = new IndexModel()
            {
                MovimentosNaoFaturados = CadastroDeASO.ContagemDeASOsNaoFaturados(),
                MovimentosNoMês = CadastroDeASO.ContagemASOsNoMes(),
                ProcedimentosNoMes = CadastroDeProcedimentosMovimento.ContagemProcedimentosNoMes(),
                ConvocacoesNoMes = CadastroDeProcedimentosMovimento.ContagemDeConvocacoesNoMes(),
                ASOS = CadastroDeASO.UltimosASOS(),
                GraficoASOs = CadastroDeASO.GraficoASOs(),
                FaturamentoMesAtual = CadastroDeFaturamento.RecuperarFaturaPrevistaMesAtual(),
                FaturamentoUltimos8Meses = Util.TrocarVirgulaPorPonto(CadastroDeFaturamento.RecuperarUltimosOitoMesesDeFaturamento()),                
            };

            return View(model);
        }
    }
}

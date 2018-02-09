using MediCloud.App_Code;
using MediCloud.BusinessProcess.Util;
using MediCloud.Code;
using MediCloud.Code.Clientes;
using MediCloud.Code.Financeiro;
using MediCloud.Code.Parametro;
using MediCloud.Code.Recomendacao;
using MediCloud.Models.Cliente;
using MediCloud.Models.Financeiro;
using MediCloud.Models.Parametro;
using MediCloud.Models.Parametro.GrupoProcedimento;
using MediCloud.Models.Recomendacao;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ASOController : BaseController
    {
        // GET: ASO
        public ActionResult Index()
        {
            base.EstahLogado();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";

                List<ASOModel> model = CadastroDeASO.buscarASO(form);

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult DetalhamentoASO(int? codigoASO, bool useCache = false)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";
                ASOModel model = null;

                if (!useCache || Session["ASOModel"] == null)
                    model = CadastroDeASO.RecuperarASOPorID(codigoASO.HasValue ? codigoASO.Value : 0);
                else
                {
                    model = Session["ASOModel"] as ASOModel;
                    model = CadastroDeASO.AtualizarProcedimentos(model);
                }

                Session["ASOModel"] = model;

                ViewData["Referentes"] = CadastroDeReferente.RecuperarTodos() as List<ReferenteModel>;
                ViewData["FormaPagamento"] = CadastroFormaPagamento.RecuperarTodos() as List<FormaPagamentoModel>;
                ViewData["TabelaPrecos"] = CadastroDeTabelaDePreco.RecuperarTodos() as List<TabelaPrecoModel>;

                return View(model);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult ExcluirProcedimento(int codigoProcedimento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeProcedimentosMovimento.DeletarProcedimentoMovimento(this, codigoProcedimento);

                resultado.mensagem = "Procedimento excluído.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult MarcarASOEntregue(int codigoASO)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeASO.MarcarComoEntregue(this, codigoASO);

                resultado.mensagem = "Marcação alterada.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoASO(FormCollection form)
        {
            ASOModel modelASO = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";
                int codigoASO = 0;

                ViewData["Referentes"] = CadastroDeReferente.RecuperarTodos() as List<ReferenteModel>;
                ViewData["FormaPagamento"] = CadastroFormaPagamento.RecuperarTodos() as List<FormaPagamentoModel>;
                ViewData["TabelaPrecos"] = CadastroDeTabelaDePreco.RecuperarTodos() as List<TabelaPrecoModel>;

                if (!Int32.TryParse(form["codigoASO"], out codigoASO) || codigoASO <= 0)
                    form["usuario"] = base.CurrentUser.login;

                modelASO = CadastroDeASO.SalvarASO(form,true);

                base.FlashMessage("ASO cadastrado.", MessageType.Success);
                return View(modelASO);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoASO"]))
                    modelASO = CadastroDeASO.RecuperarASOPorID(Convert.ToInt32(form["codigoASO"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelASO);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult SalvarProcedimentoMovimento(FormCollection form)
        {
            ProcedimentoMovimentoModel modelProcedimentoMovimento = null;
            int codigoASO = Convert.ToInt32(form["codigoASOProcedimento"]);
            try
            {
                base.EstahLogado();
                ViewBag.Title = "ASO";
                int codigoProcedimento = 0;

                ViewData["Referentes"] = CadastroDeReferente.RecuperarTodos() as List<ReferenteModel>;
                ViewData["FormaPagamento"] = CadastroFormaPagamento.RecuperarTodos() as List<FormaPagamentoModel>;
                ViewData["TabelaPrecos"] = CadastroDeTabelaDePreco.RecuperarTodos() as List<TabelaPrecoModel>;

                if (!Int32.TryParse(form["codigoProcedimento"], out codigoProcedimento) || codigoProcedimento <= 0)
                    form["usuarioProcedimento"] = base.CurrentUser.login;

                CadastroDeProcedimentosMovimento.SalvarProcedimentoMovimento(form);

                base.FlashMessage("Procedimento cadastrado.", MessageType.Success);
                Response.Redirect($"/ASO/DetalhamentoASO?codigoASO={codigoASO}&useCache=true");
            }
            catch (InvalidOperationException ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/ASO/DetalhamentoASO?codigoASO={codigoASO}&useCache=true");
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/ASO/DetalhamentoASO?codigoASO={codigoASO}&useCache=true");
            }

            return null;
        }

        [HttpPost]
        public JsonResult DetalharProcedimentoMovimento(int codigoDoProcedimentoMovimento)
        {
            try
            {
                ProcedimentoMovimentoModel contadoresEncontrados = CadastroDeProcedimentosMovimento.BuscarProcedimentoDeMovimentoPorID(codigoDoProcedimentoMovimento);


                return Json(contadoresEncontrados, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();

                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UploadArquivo(int CodigoASO)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();
                byte[] fileData = null;

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);


                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(file.ContentLength);
                    }

                    CadastroDeASO.uploadDeArquivo(fileData, fileName, CodigoASO);
                }

                resultado.mensagem = "Upload de arquivo bem-sucedido.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        public FileResult BaixarArquivoASO(int codigoArquivo)
        {
            ArquivoMovimentoModel arquivo = null;
            try
            {
                base.EstahLogado();

                arquivo = CadastroDeASO.downloadDeArquivo(codigoArquivo);

                byte[] fileBytes = arquivo.Arquivo;
                string fileName = arquivo.NomeArquivo;
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/ASO");
                return null;
            }
        }

        public FileResult ImprimirFichaClinica(int codigoASO)
        {
            ASOModel aso = null;
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                aso = CadastroDeASO.RecuperarASOPorID(codigoASO, false);

                arquivo = CadastroDeASO.ImprimirFichaClinica(codigoASO);

                byte[] fileBytes = arquivo;
                string fileName = aso.toString() + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/ASO");
                return null;
            }
        }

        public FileResult ImprimirASOComMedCoord(int codigoASO)
        {
            ASOModel aso = null;
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                aso = CadastroDeASO.RecuperarASOPorID(codigoASO, false);

                arquivo = CadastroDeASO.ImprimirASOComMedCoord(codigoASO);

                byte[] fileBytes = arquivo;
                string fileName = aso.toString() + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/ASO");
                return null;
            }
        }

        public FileResult ImprimirASOSemMedCoord(int codigoASO)
        {
            ASOModel aso = null;
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                aso = CadastroDeASO.RecuperarASOPorID(codigoASO, false);

                arquivo = CadastroDeASO.ImprimirASOSemMedCoord(codigoASO);

                byte[] fileBytes = arquivo;
                string fileName = aso.toString() + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/ASO");
                return null;
            }
        }

        public FileResult ImprimirOrdemDeServico(int codigoASO)
        {
            ASOModel aso = null;
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                aso = CadastroDeASO.RecuperarASOPorID(codigoASO, false);

                arquivo = CadastroDeASO.ImprimirOrdemDeServico(codigoASO);

                byte[] fileBytes = arquivo;
                string fileName = aso.toString() + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/ASO");
                return null;
            }
        }


        public FileResult ImprimirListaDeProcedimentos(int codigoASO)
        {
            ASOModel aso = null;
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                aso = CadastroDeASO.RecuperarASOPorID(codigoASO, false);

                arquivo = CadastroDeASO.ImprimirListaDeProcedimentos(codigoASO);

                byte[] fileBytes = arquivo;
                string fileName = aso.toString() + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/ASO");
                return null;
            }
        }

        public FileResult ImprimirReciboASO(int codigoASO)
        {
            ASOModel aso = null;
            byte[] arquivo = null;
            try
            {
                base.EstahLogado();

                aso = CadastroDeASO.RecuperarASOPorID(codigoASO, false);

                arquivo = CadastroDeASO.ImprimirReciboASO(codigoASO);

                byte[] fileBytes = arquivo;
                string fileName = aso.toString() + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect("/ASO");
                return null;
            }
        }

        [HttpPost]
        public JsonResult ExcluirArquivoMovimento(int codigoArquivo)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeASO.DeletarArquivoMovimento(this, codigoArquivo);

                resultado.mensagem = "Arquivo excluído.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ConfirmarExame(int codigoDoProcedimentoMovimento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeASO.ConfirmarExame(this.CurrentUser, codigoDoProcedimentoMovimento);

                resultado.mensagem = "Exame confirmado.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ConfirmarASO(int codigoDoMovimento)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeASO.ConfirmarASO(this.CurrentUser, codigoDoMovimento);

                resultado.mensagem = "ASO confirmado.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult BuscaProcedimentosParaLaudoAJAX(string Prefix, int IdFuncionario)
        {
            List<ProcedimentoMovimentoModel> contadoresEncontrados = CadastroDeProcedimentosMovimento.RecuperarProcedimentoMovimentoPorTermoELaudo(Prefix, IdFuncionario);
            List<AutoCompleteDefaultModel> ObjList = new List<AutoCompleteDefaultModel>();

            try
            {
                contadoresEncontrados.ForEach(x =>
                {
                    ObjList.Add(new AutoCompleteDefaultModel() { Id = x.IdMovimentoProcedimento, Name = (x.Procedimento?.Nome + " - " + (x.DataExame.HasValue ? x.DataExame.Value.ToShortDateString() : string.Empty)) });
                });

                //Searching records from list using LINQ query  
                var results = (from N in ObjList
                               select new { N.Id, N.Name }).ToArray();
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ExceptionUtil.GerarLogDeExcecao(ex, Request.Url.ToString());
                ObjList = new List<AutoCompleteDefaultModel>()
                {
                new AutoCompleteDefaultModel {Id=-1,Name=Constantes.MENSAGEM_GENERICA_DE_ERRO },
                };
                return Json(ObjList.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
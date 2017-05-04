﻿using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Parametro;
using MediCloud.Models.Parametro;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class DadosOcupacionaisController : BaseController
    {
        // GET: DadosOcupacionais
        public ActionResult Index()
        {
            EstahLogado();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Dados Ocupacionais";

                List<DadosOcupacionaisModel> model = CadastroDeDadosOcupacionais.BuscarDadosOcupacionais(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeletarDadosOcupacionais(int codigoDoDadosOcupacionais)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeDadosOcupacionais.DeletarDadosOcupacionais(this, codigoDoDadosOcupacionais);

                resultado.mensagem = "Dados Ocupacionais excluídos.";
                resultado.acaoBemSucedida = true;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                resultado.mensagem = Constantes.MENSAGEM_GENERICA_DE_ERRO;
                resultado.acaoBemSucedida = false;

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ExcluirSetor(int codigoDadosOcupacionais)
        {
            DadosOcupacionaisModel modelCargo = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Dados Ocupacionais";

                CadastroDeDadosOcupacionais.DeletarDadosOcupacionais(this, codigoDadosOcupacionais);

                base.FlashMessage("Dados Ocupacionais excluídos.", MessageType.Success); 

                return View("Index");
            }
            catch (Exception ex)
            {
                modelCargo = CadastroDeDadosOcupacionais.BuscarDadosOcupacionaisPorID(Convert.ToInt32(codigoDadosOcupacionais));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCargo);
            }
        }
    }
}
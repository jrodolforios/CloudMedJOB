using MediCloud.App_Code;
using MediCloud.Code;
using MediCloud.Code.Clientes;
using MediCloud.Code.Fornecedor;
using MediCloud.Models.Cliente;
using MediCloud.Models.Fornecedor;
using MediCloud.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCloud.Controllers
{
    public class ClienteController : BaseController
    {
        // GET: Cliente
        public ActionResult Index()
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                return View();
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                List<ClienteModel> model = CadastroDeClientes.buscarClientes(form);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult SalvarContato(FormCollection form)
        {
            int codigoCliente = Convert.ToInt32(form["codigoClienteContato"]);

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                ContatoModel model = CadastroDeContato.salvarContato(form);

                Response.Redirect($"/Cliente/DetalhamentoCliente?codigoCliente={codigoCliente}");
            }
            catch (InvalidOperationException ex)
            {
                base.FlashMessage(ex.Message, MessageType.Error);
                Response.Redirect($"/Cliente/DetalhamentoCliente?codigoCliente={codigoCliente}");
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                Response.Redirect($"/Cliente/DetalhamentoCliente?codigoCliente={codigoCliente}");
            }

            return null;
        }

        [HttpPost]
        public JsonResult DeletarCliente(int codigoDoCliente)
        {
            ResultadoAjaxGenericoModel resultado = new ResultadoAjaxGenericoModel();
            try
            {
                base.EstahLogado();

                CadastroDeClientes.DeletarCliente(this, codigoDoCliente);

                resultado.mensagem = "Usuário excluído.";
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

        public ActionResult DetalhamentoCliente(int? codigoCliente)
        {
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                ClienteModel model = CadastroDeClientes.RecuperarClientePorID(codigoCliente);

                return View(model);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        [HttpPost]
        public ActionResult DetalhamentoCliente(FormCollection form)
        {
            ClienteModel modelUsuario = null;
            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                modelUsuario = CadastroDeClientes.SalvarCliente(form);

                base.FlashMessage("Usuário cadastrado.", MessageType.Success);
                return View(modelUsuario);
            }
            catch (InvalidOperationException ex)
            {
                if (!string.IsNullOrEmpty(form["codigoCliente"]))
                    modelUsuario = CadastroDeClientes.RecuperarClientePorID(Convert.ToInt32(form["codigoCliente"]));

                base.FlashMessage(ex.Message, MessageType.Error);
                return View(modelUsuario);
            }
            catch (Exception ex)
            {
                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View();
            }
        }

        public ActionResult ExcluirCliente(int codigoCliente)
        {
            ClienteModel modelCliente = null;

            try
            {
                base.EstahLogado();
                ViewBag.Title = "Clientes";

                CadastroDeClientes.DeletarCliente(this, codigoCliente);

                base.FlashMessage("Usuário excluído.", MessageType.Success);

                return View("index");
            }
            catch (Exception ex)
            {
                modelCliente = CadastroDeClientes.RecuperarClientePorID(Convert.ToInt32(codigoCliente));

                base.FlashMessage(Constantes.MENSAGEM_GENERICA_DE_ERRO, MessageType.Error);
                return View(modelCliente);
            }
        }

    }
}
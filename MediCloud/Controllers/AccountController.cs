using System.Web.Mvc;

namespace MediCloud.View.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Bem-vindo";

            return View();
        }
    }
}

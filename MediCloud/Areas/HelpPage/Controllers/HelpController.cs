using MediCloud.View.Areas.HelpPage.ModelDescriptions;
using MediCloud.View.Areas.HelpPage.Models;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace MediCloud.View.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        #region Private Fields

        private const string ErrorViewName = "Error";

        #endregion Private Fields

        #region Public Constructors

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        #endregion Public Constructors



        #region Public Properties

        public HttpConfiguration Configuration { get; private set; }

        #endregion Public Properties



        #region Public Methods

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }

        #endregion Public Methods
    }
}
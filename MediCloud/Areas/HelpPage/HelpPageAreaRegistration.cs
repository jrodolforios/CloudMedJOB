using System.Web.Http;
using System.Web.Mvc;

namespace MediCloud.View.Areas.HelpPage
{
    public class HelpPageAreaRegistration : AreaRegistration
    {
        #region Public Properties

        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        #endregion Public Properties



        #region Public Methods

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Default",
                "Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }

        #endregion Public Methods
    }
}
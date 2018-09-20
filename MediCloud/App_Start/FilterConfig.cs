using System.Web.Mvc;

namespace MediCloud.View
{
    public class FilterConfig
    {
        #region Public Methods

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion Public Methods
    }
}
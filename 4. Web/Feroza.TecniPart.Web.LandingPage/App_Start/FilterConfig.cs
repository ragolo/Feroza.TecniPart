using System.Web;
using System.Web.Mvc;

namespace Feroza.TecniPart.Web.LandingPage
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

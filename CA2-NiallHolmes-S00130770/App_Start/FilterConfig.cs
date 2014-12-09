using System.Web;
using System.Web.Mvc;

namespace CA2_NiallHolmes_S00130770
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
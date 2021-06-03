using System.Web;
using System.Web.Mvc;

namespace WebApiAssign1Link
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

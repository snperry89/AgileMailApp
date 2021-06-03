using System.Web;
using System.Web.Mvc;

namespace Rockwood_Tech_Development
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

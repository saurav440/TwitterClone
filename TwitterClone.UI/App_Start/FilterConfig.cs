using System.Web;
using System.Web.Mvc;
using TwitterClone.UI.CustomFilters;

namespace TwitterClone.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
          //  filters.Add(new HandleErrorAttribute());
            filters.Add(new MyHandlerError());
        }
    }
}

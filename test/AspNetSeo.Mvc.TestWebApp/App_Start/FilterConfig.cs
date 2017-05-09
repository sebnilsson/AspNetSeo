using System.Web.Mvc;

namespace AspNetSeo.Mvc.TestWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SeoBaseTitleAttribute("ASP.NET MVC SEO Test-Website"));
        }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetSeo.CoreMvc.Tests
{
    internal static class SeoHelperTestFactory
    {
        public static SeoHelper Create(ViewContext viewContext = null)
        {
            viewContext = viewContext ?? ViewContextTestFactory.Create();

            var seo = viewContext.GetSeoHelper();
            return seo;
        }
    }
}
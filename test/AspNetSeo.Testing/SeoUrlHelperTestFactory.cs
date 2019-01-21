using System;

using AspNetSeo.CoreMvc.Internal;
using Microsoft.AspNetCore.Mvc.Routing;

namespace AspNetSeo.Testing
{
    public static class SeoUrlHelperTestFactory
    {
        public static ISeoUrlHelper Create(Uri path = null)
        {
            var actionContext = ActionContextTestFactory.Create(path);

            var urlHelper = new UrlHelper(actionContext);

            return new SeoUrlHelper(urlHelper);
        }
    }
}
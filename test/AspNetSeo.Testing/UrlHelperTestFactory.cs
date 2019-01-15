using System;
using Microsoft.AspNetCore.Mvc.Routing;

namespace AspNetSeo.Testing
{
    public static class UrlHelperTestFactory
    {
        public static UrlHelper Create(Uri path = null)
        {
            var actionContext = ActionContextTestFactory.Create(path);

            return new UrlHelper(actionContext);
        }
    }
}
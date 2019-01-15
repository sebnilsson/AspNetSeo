using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;

namespace AspNetSeo.Testing
{
    public static class ActionContextTestFactory
    {
        public static ActionContext Create(Uri path = null)
        {
            var httpContext = new DefaultHttpContext();
            PopulatePath(httpContext, path);

            var modelState = new ModelStateDictionary();

            return new ActionContext(
                httpContext,
                new RouteData(),
                new PageActionDescriptor(),
                modelState);
        }

        private static void PopulatePath(
            DefaultHttpContext httpContext,
            Uri path)
        {
            if (path == null || !path.IsAbsoluteUri)
            {
                return;
            }

            var request = httpContext.Request;

            request.Host = new HostString(path.Host);
            request.Path = path.AbsolutePath;

            if (path.Query != null)
            {
                request.QueryString = new QueryString(path.Query);
            }
            request.Scheme = path.Scheme;
        }
    }
}

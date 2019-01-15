using System.IO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;

namespace AspNetSeo.Testing
{
    public static class ViewContextTestFactory
    {
        public const string Domain = "testhost.co";

        public static ViewContext Create(string requestPathBase = null)
        {
            var serviceProvider = ServiceProviderTestFactory.Create();

            HttpContext httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var request = new DefaultHttpRequest(httpContext)
                              {
                                  Host = new HostString(Domain),
                                  PathBase = "/testpathbase",
                                  Path = "/testpath",
                                  QueryString =
                                      new QueryString("?testquery=123&test=ABC"),
                                  Scheme = "https"
                              };

            if (requestPathBase != null)
            {
                request.PathBase = new PathString(requestPathBase);
            }

            httpContext = request.HttpContext;

            var routeData = new RouteData();
            var actionDescriptor = new ActionDescriptor();

            var actionContext = new ActionContext(httpContext, routeData, actionDescriptor);
            var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());

            var htmlHelperOptions = new HtmlHelperOptions();

            var viewContext = new ViewContext(
                actionContext,
                Mock.Of<IView>(),
                viewData,
                Mock.Of<ITempDataDictionary>(),
                TextWriter.Null,
                htmlHelperOptions);
            return viewContext;
        }
    }
}
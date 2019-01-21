using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace AspNetSeo.CoreMvc.Internal
{
    internal class SeoUrlHelper : ISeoUrlHelper
    {
        private readonly IUrlHelper _urlHelper;

        public SeoUrlHelper(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper
                ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public ActionContext ActionContext
            => _urlHelper.ActionContext;

        public string Action(UrlActionContext actionContext)
        {
            return _urlHelper.Action(actionContext);
        }

        public string Content(string contentPath)
        {
            return _urlHelper.Content(contentPath);
        }

        public bool IsLocalUrl(string url)
        {
            return _urlHelper.IsLocalUrl(url);
        }

        public string Link(string routeName, object values)
        {
            return _urlHelper.Link(routeName, values);
        }

        public string RouteUrl(UrlRouteContext routeContext)
        {
            return _urlHelper.RouteUrl(routeContext);
        }
    }
}
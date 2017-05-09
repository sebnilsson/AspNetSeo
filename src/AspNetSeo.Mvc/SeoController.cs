using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetSeo.Mvc
{
    public abstract class SeoController : Controller
    {
        public SeoHelper Seo { get; private set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException(nameof(requestContext));
            }

            base.Initialize(requestContext);

            this.Seo = this.GetSeoHelper();
        }
    }
}
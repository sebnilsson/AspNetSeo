using System;

using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetSeo.CoreMvc
{
    public abstract class SeoAttributeBase : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var seoHelper = context.GetSeoHelper();
            if (seoHelper == null)
            {
                throw new TypeLoadException(
                    $"Could not resolve service for type '{nameof(ISeoHelper)}'.");
            }

            OnHandleSeoValues(seoHelper);
        }

        public abstract void OnHandleSeoValues(ISeoHelper seoHelper);
    }
}

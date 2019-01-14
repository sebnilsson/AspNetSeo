using System;

#if COREMVC
using Microsoft.AspNetCore.Mvc.Filters;
#else
using System.Web.Mvc;
#endif

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
#if COREMVC
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
                throw new TypeLoadException($"Could not resolve service for type '{nameof(SeoHelper)}'.");
            }

            OnHandleSeoValues(seoHelper);
        }
#else
    public abstract class SeoAttributeBase : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var seoHelper = context.Controller?.ViewData?.GetSeoHelper();
            if (seoHelper == null)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(context),
                    $"Could not get '{nameof(SeoHelper)}' from {nameof(ActionExecutingContext)}.");
            }

            OnHandleSeoValues(seoHelper);
        }
#endif

        public abstract void OnHandleSeoValues(SeoHelper seoHelper);
    }
}
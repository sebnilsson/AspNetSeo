using System;

#if NETSTANDARD
using Microsoft.AspNetCore.Mvc.Filters;
#else
using System.Web.Mvc;
#endif

#if NETSTANDARD
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
#if NETSTANDARD
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

            this.OnHandleSeoValues(seoHelper);
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

            this.OnHandleSeoValues(seoHelper);
        }
#endif

        public abstract void OnHandleSeoValues(SeoHelper seoHelper);
    }
}
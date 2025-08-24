using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetSeo.CoreMvc;

/// <summary>
/// Base attribute for setting SEO values.
/// </summary>
public abstract class SeoAttributeBase : ActionFilterAttribute
{
    /// <summary>Injects values before the action executes.</summary>
    /// <param name="context">The action context.</param>
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

    /// <summary>Applies values to the helper.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public abstract void OnHandleSeoValues(ISeoHelper seoHelper);
}


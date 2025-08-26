using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc;

/// <summary>
/// Extension methods for <see cref="ActionContext"/>.
/// </summary>
public static class ActionContextExtensions
{
    /// <summary>Gets the registered <see cref="ISeoHelper"/>.</summary>
    /// <param name="context">The MVC action context.</param>
    /// <returns>The SEO helper.</returns>
    public static ISeoHelper GetSeoHelper(this ActionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var serviceProvider = context.HttpContext.RequestServices;
        if (serviceProvider == null)
        {
            var message =
                $"The {nameof(context.HttpContext.RequestServices)} of the provided {nameof(ActionContext)} cannot be null.";
            throw new ArgumentOutOfRangeException(nameof(context), message);
        }

        var seoHelper = serviceProvider.GetSeoHelper();
        return seoHelper;
    }
}


using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc;

public static class ControllerBaseExtensions
{
    public static ISeoHelper GetSeoHelper(this ControllerBase controller)
    {
        ArgumentNullException.ThrowIfNull(controller);

        var serviceProvider = controller.HttpContext.RequestServices;
        if (serviceProvider == null)
        {
            var message =
                $"The {nameof(controller.HttpContext.RequestServices)} of the provided {nameof(ControllerBase)} cannot be null.";
            throw new ArgumentOutOfRangeException(nameof(controller), message);
        }

        var seoHelper = serviceProvider.GetSeoHelper();
        return seoHelper;
    }
}

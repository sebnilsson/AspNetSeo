using System;

using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc
{
    public static class ActionContextExtensions
    {
        public static ISeoHelper GetSeoHelper(this ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var serviceProvider = context.HttpContext.RequestServices;
            if (serviceProvider == null)
            {
                string message =
                    $"The {nameof(context.HttpContext.RequestServices)} of the provided {nameof(ActionContext)} cannot be null.";
                throw new ArgumentOutOfRangeException(nameof(context), message);
            }

            var seoHelper = serviceProvider.GetSeoHelper();
            return seoHelper;
        }
    }
}
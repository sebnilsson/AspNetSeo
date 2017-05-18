using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AspNetSeo.CoreMvc
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSeoHelper(
            this IServiceCollection services,
            string baseTitle = null,
            string baseLinkCanonical = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAddScoped(
                _ =>
                    {
                        var seoHelper = new SeoHelper { BaseLinkCanonical = baseLinkCanonical, BaseTitle = baseTitle };
                        return seoHelper;
                    });
        }
    }
}
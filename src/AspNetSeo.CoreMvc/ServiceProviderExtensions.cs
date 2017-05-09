using System;

using Microsoft.Extensions.DependencyInjection;

namespace AspNetSeo.CoreMvc
{
    public static class ServiceProviderExtensions
    {
        public static SeoHelper GetSeoHelper(this IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var seoHelper = serviceProvider.GetService<SeoHelper>();
            if (seoHelper == null)
            {
                throw new TypeLoadException($"Could not resolve service for type '{nameof(SeoHelper)}'. "
                                            + $"Use the extension-method '.{nameof(ServiceCollectionExtensions.AddSeoHelper)}'"
                                            + " in service-configuration.");
            }

            return seoHelper;
        }
    }
}
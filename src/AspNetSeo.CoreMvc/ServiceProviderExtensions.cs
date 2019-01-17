using System;

using Microsoft.Extensions.DependencyInjection;

namespace AspNetSeo.CoreMvc
{
    public static class ServiceProviderExtensions
    {
        public static ISeoHelper GetSeoHelper(this IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var seoHelper = serviceProvider.GetService<ISeoHelper>();
            if (seoHelper == null)
            {
                var message = $"Could not resolve service for type '{nameof(ISeoHelper)}'."
                    + $" Use the extension-method '{nameof(ServiceCollectionExtensions.AddSeoHelper)}'"
                    + " in service-configuration.";
                throw new TypeLoadException(message);
            }

            return seoHelper;
        }
    }
}
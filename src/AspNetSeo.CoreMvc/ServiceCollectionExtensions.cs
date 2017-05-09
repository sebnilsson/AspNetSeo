using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AspNetSeo.CoreMvc
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSeoHelper(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAddScoped<SeoHelper>();
        }
    }
}
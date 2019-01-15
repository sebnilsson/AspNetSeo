using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AspNetSeo.CoreMvc
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSeoHelper(
            this IServiceCollection services,
            string siteName = null,
            string siteUrl = null,
            string documentTitleFormat = null)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            
            services.TryAddScoped<ISeoHelper>(_ =>
            {
                return new SeoHelper
                {
                    SiteName = siteName,
                    SiteUrl = siteUrl,
                    DocumentTitleFormat = documentTitleFormat
                };
            });
        }
    }
}
using System;

using AspNetSeo.CoreMvc.Internal;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
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
                    DocumentTitleFormat = 
                        documentTitleFormat
                        ?? SeoHelper.DefaultDocumentTitleFormat
                };
            });

            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.TryAddTransient<ISeoUrlHelper>(x =>
            {
                var urlHelperFactory =
                    x.GetRequiredService<IUrlHelperFactory>();
                var actionAccessor =
                    x.GetRequiredService<IActionContextAccessor>();

                var urlHelper =
                    urlHelperFactory.GetUrlHelper(actionAccessor.ActionContext);

                return new SeoUrlHelper(urlHelper);
            });
        }
    }
}

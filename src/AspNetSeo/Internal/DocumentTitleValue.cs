using System;

namespace AspNetSeo.Internal
{
    internal static class DocumentTitleValue
    {
        public static string Get(ISeoHelper seoHelper)
        {
            if (seoHelper == null)
                throw new ArgumentNullException(nameof(seoHelper));

            var hasPageTitle = !string.IsNullOrWhiteSpace(seoHelper.PageTitle);
            var hasSiteName = !string.IsNullOrWhiteSpace(seoHelper.SiteName);

            if (hasPageTitle && hasSiteName)
            {
                return string.Format(
                    seoHelper.DocumentTitleFormat ?? string.Empty,
                    seoHelper.PageTitle,
                    seoHelper.SiteName);
            }
            else if (hasPageTitle)
            {
                return seoHelper.PageTitle;
            }
            else if (hasSiteName)
            {
                return seoHelper.SiteName;
            }

            return null;
        }
    }
}

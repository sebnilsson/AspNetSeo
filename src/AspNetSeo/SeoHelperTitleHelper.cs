using System;

namespace AspNetSeo
{
    public static class SeoHelperTitleHelper
    {
        public static string GetFullTitle(SeoHelper seoHelper, string title = null)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            title = title ?? seoHelper.Title;

            bool isBaseTitleSet = !string.IsNullOrWhiteSpace(seoHelper.BaseTitle);
            bool isPageTitleSet = !string.IsNullOrWhiteSpace(title);

            if (isBaseTitleSet && isPageTitleSet)
            {
                string titleFormat = !string.IsNullOrWhiteSpace(seoHelper.TitleFormat)
                                         ? seoHelper.TitleFormat
                                         : SeoHelper.DefaultTitleFormat;

                string fullTitle = string.Format(titleFormat, title, seoHelper.BaseTitle);
                return fullTitle;
            }

            if (!isBaseTitleSet)
            {
                return !string.IsNullOrWhiteSpace(title) ? title : null;
            }

            return !string.IsNullOrWhiteSpace(seoHelper.BaseTitle) ? seoHelper.BaseTitle : null;
        }
    }
}
using System;

namespace AspNetSeo
{
    public static class SeoHelperTitleHelper
    {
        public static string GetTitle(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            bool isBaseTitleSet = !string.IsNullOrWhiteSpace(seoHelper.BaseTitle);
            bool isPageTitleSet = !string.IsNullOrWhiteSpace(seoHelper.Title);

            if (isBaseTitleSet && isPageTitleSet)
            {
                string titleFormat = !string.IsNullOrWhiteSpace(seoHelper.TitleFormat)
                                         ? seoHelper.TitleFormat
                                         : SeoHelper.DefaultTitleFormat;

                string title = string.Format(titleFormat, seoHelper.Title, seoHelper.BaseTitle);
                return title;
            }

            if (!isBaseTitleSet)
            {
                return !string.IsNullOrWhiteSpace(seoHelper.Title) ? seoHelper.Title : null;
            }

            return !string.IsNullOrWhiteSpace(seoHelper.BaseTitle) ? seoHelper.BaseTitle : null;
        }
    }
}
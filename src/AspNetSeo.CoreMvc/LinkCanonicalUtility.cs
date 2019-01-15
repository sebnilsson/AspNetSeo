using System;

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;

namespace AspNetSeo.CoreMvc
{
    internal static class LinkCanonicalUtility
    {
        public static string GetLinkCanonical(
            SeoHelper seoHelper,
            ViewContext viewContext,
            string value,
            string baseValue = null)
        {
            if (seoHelper == null)
                throw new ArgumentNullException(nameof(seoHelper));

            baseValue = baseValue ?? seoHelper.BaseLinkCanonical;

            var urlHelper = (viewContext != null) ? new UrlHelper(viewContext) : null;

            var linkCanonical = !string.IsNullOrWhiteSpace(value) ? value : seoHelper.LinkCanonical;

            linkCanonical = urlHelper?.Content(linkCanonical) ?? linkCanonical;

            var linkCanonicalBase = !string.IsNullOrWhiteSpace(baseValue) ? baseValue : seoHelper.BaseLinkCanonical;

            var requestUrl = viewContext?.HttpContext?.Request?.GetDisplayUrl()
                ?? string.Empty;

            var requestUri = new Uri(requestUrl);

            string combinedLinkCanonical = SeoHelperLinkCanonicalHelper.GetLinkCanonical(
                linkCanonical,
                linkCanonicalBase,
                requestUri);
            return combinedLinkCanonical;
        }
    }
}
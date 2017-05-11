using System;

namespace AspNetSeo
{
    public static class SeoHelperLinkCanonicalHelper
    {
        public static string GetLinkCanonical(string linkCanonical, string linkCanonicalBase, Uri requestUri)
        {
            if (linkCanonical == null || Uri.IsWellFormedUriString(linkCanonical, UriKind.Absolute))
            {
                return linkCanonical;
            }

            string baseCombinedLinkCanonical = GetBaseCombinedLinkCanonical(linkCanonical, linkCanonicalBase);
            if (baseCombinedLinkCanonical != null)
            {
                return baseCombinedLinkCanonical;
            }

            if (requestUri == null)
            {
                return null;
            }

            string requestCombinedLinkCanonical = GetRequestCombinedLinkCanonical(requestUri, linkCanonical);
            return requestCombinedLinkCanonical;
        }

        private static string GetBaseCombinedLinkCanonical(string linkCanonicalAppAbsolute, string linkCanonicalBase)
        {
            if (linkCanonicalBase == null)
            {
                return null;
            }

            string combinedLinkCanoncial = $"{linkCanonicalBase.TrimEnd('/')}/{linkCanonicalAppAbsolute.TrimStart('/')}";
            return combinedLinkCanoncial;
        }

        private static string GetRequestCombinedLinkCanonical(Uri requestUri, string linkCanonical)
        {
            int queryIndex = linkCanonical.IndexOf('?');

            string uriPath = (queryIndex >= 0) ? linkCanonical.Substring(0, queryIndex) : linkCanonical;
            string uriQuery = (queryIndex >= 0) ? linkCanonical.Substring(queryIndex + 1) : string.Empty;
            int uriPort = requestUri.Authority.Contains(":") ? requestUri.Port : -1;

            var uri = new UriBuilder(requestUri.AbsoluteUri) { Path = uriPath, Query = uriQuery, Port = uriPort };

            string absoluteLinkCanonicalUrl = uri.ToString();

            if (string.IsNullOrWhiteSpace(absoluteLinkCanonicalUrl)
                || !Uri.IsWellFormedUriString(absoluteLinkCanonicalUrl, UriKind.Absolute))
            {
                return null;
            }

            return absoluteLinkCanonicalUrl;
        }
    }
}
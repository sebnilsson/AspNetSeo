using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc.Internal
{
    internal static class AbsoluteUrlUtility
    {
        public static string Resolve(
            IUrlHelper urlHelper,
            string url,
            string siteUrl)
        {
            if (urlHelper == null)
                throw new ArgumentNullException(nameof(urlHelper));

            var escapedUrl = url != null ? Uri.EscapeUriString(url) : null;

            var contentUrl = urlHelper.Content(escapedUrl);

            var isWellFormedUri = contentUrl != null
                && Uri.IsWellFormedUriString(
                    contentUrl,
                    UriKind.RelativeOrAbsolute);

            if (!isWellFormedUri)
            {
                return null;
            }

            return
                GetAbsoluteUrl(contentUrl)
                ?? GetSiteUrl(contentUrl, siteUrl)
                ?? GetRequestUrl(
                    contentUrl,
                    urlHelper.ActionContext?.HttpContext?.Request);
        }

        private static string GetAbsoluteUrl(string url)
        {
            var isAbsolute = Uri.IsWellFormedUriString(
                    url,
                    UriKind.Absolute);

            return isAbsolute ? url : null;
        }

        private static string GetRequestUrl(string url, HttpRequest request)
        {
            if (request == null
                || request.Host.Host == null
                || request.Scheme == null)
            {
                return null;
            }

            var path = request.Path.HasValue
                ? $"/{request.Path.Value.TrimStart('/')}"
                : null;

            var requestSiteUri =
                new Uri($"{request.Scheme}://{request.Host.Host}{path}");

            var absoluteUri = new Uri(requestSiteUri, url);
            return absoluteUri.ToString();
        }

        private static string GetSiteUrl(string url, string siteUrl)
        {
            if (siteUrl == null
                || !Uri.TryCreate(siteUrl, UriKind.Absolute, out Uri siteUri))
            {
                return null;
            }

            var absoluteUri = new Uri(siteUri, url);
            return absoluteUri.ToString();
        }
    }
}
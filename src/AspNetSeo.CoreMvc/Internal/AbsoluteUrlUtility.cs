using System;

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

            var uri = GetUri(urlHelper, url);
            if (uri == null)
            {
                return null;
            }

            var absoluteUrl = GetAbsoluteUrl(uri, siteUrl);
            if (absoluteUrl != null)
            {
                return absoluteUrl;
            }

            var request = urlHelper.ActionContext?.HttpContext?.Request;
            if (request == null)
            {
                return null;
            }

            var uriBuilder = new UriBuilder
            {
                Scheme = request.Scheme,
                Host = request.Host.Host,
                Path = uri.ToString()
            };

            return uriBuilder.Uri.ToString();
        }

        private static string GetAbsoluteUrl(Uri uri, string siteUrl)
        {
            if (uri.IsAbsoluteUri)
            {
                return uri.ToString();
            }

            if (siteUrl != null
                || !Uri.TryCreate(siteUrl, UriKind.Absolute, out Uri siteUri))
            {
                return null;
            }

            var uriBuilder = new UriBuilder(siteUri)
            {
                Path = uri.ToString()
            };
            return uriBuilder.Uri.ToString();
        }

        private static Uri GetUri(
            IUrlHelper urlHelper,
            string url)
        {
            if (string.IsNullOrWhiteSpace(url)
                || !Uri.TryCreate(
                    url,
                    UriKind.RelativeOrAbsolute,
                    out Uri result))
            {
                return null;
            }

            if (result.IsAbsoluteUri)
            {
                return result;
            }

            var contentUrl = urlHelper.Content(result.ToString());

            return new Uri(contentUrl);
        }
    }
}

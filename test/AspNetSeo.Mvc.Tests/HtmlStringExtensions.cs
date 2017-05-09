using System;
using System.Web;

namespace AspNetSeo.Mvc.Tests
{
    public static class HtmlStringExtensions
    {
        public static bool Contains(this IHtmlString htmlString, string value)
        {
            if (htmlString == null)
            {
                throw new ArgumentNullException(nameof(htmlString));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var html = htmlString.ToString();

            bool contains = html.Contains(value);
            return contains;
        }
    }
}
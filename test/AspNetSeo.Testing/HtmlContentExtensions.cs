using System.IO;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.WebEncoders.Testing;

namespace AspNetSeo.Testing
{
    public static class HtmlContentExtensions
    {
        public static string GetContent(this IHtmlContent content, HtmlEncoder encoder = null)
        {
            encoder = encoder ?? new HtmlTestEncoder();

            using (var writer = new StringWriter())
            {
                content.WriteTo(writer, encoder);
                return writer.ToString();
            }
        }
    }
}
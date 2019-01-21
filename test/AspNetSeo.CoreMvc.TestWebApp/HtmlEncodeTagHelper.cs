using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TestWebApp
{
    [HtmlTargetElement("html-encode", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class HtmlEncodeTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = output.Content.IsModified
                                   ? output.Content.GetContent()
                                   : (await output.GetChildContentAsync()).GetContent();

            string encodedChildContent = WebUtility.HtmlEncode(childContent ?? string.Empty);

            output.TagName = null;
            output.Content.SetHtmlContent(encodedChildContent);
        }
    }
}
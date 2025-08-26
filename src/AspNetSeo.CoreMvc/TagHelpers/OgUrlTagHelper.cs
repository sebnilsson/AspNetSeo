using AspNetSeo.CoreMvc;
using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders the Open Graph URL tag.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
/// <param name="urlHelper">URL resolver.</param>
[HtmlTargetElement("og-url", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgUrlTagHelper(
    ISeoHelper seoHelper,
    ISeoUrlHelper urlHelper) : SeoTagHelperBase(seoHelper)
{
    private readonly ISeoUrlHelper _urlHelper = urlHelper
            ?? throw new ArgumentNullException(nameof(urlHelper));

    /// <summary>URL value.</summary>
    public string? Value { get; set; }

    /// <summary>Builds the tag.</summary>
    /// <param name="context">Tag helper context.</param>
    /// <param name="output">Tag helper output.</param>
    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        var value = TagValueUtility.GetContent(
            Value,
            SeoHelper.OgUrl,
            SeoHelper.LinkCanonical);

        var linkCanonical =
            AbsoluteUrlUtility.Resolve(
                _urlHelper,
                value,
                SeoHelper.SiteUrl);

        output.ProcessOpenGraph(OgMetaName.Url, linkCanonical);
    }
}


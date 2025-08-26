using AspNetSeo.CoreMvc;
using AspNetSeo.CoreMvc.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders the canonical link tag.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
/// <param name="urlHelper">URL resolver.</param>
[HtmlTargetElement("link-canonical", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("link")]
public class LinkCanonicalTagHelper(
    ISeoHelper seoHelper,
    ISeoUrlHelper urlHelper) : SeoTagHelperBase(seoHelper)
{
    private readonly ISeoUrlHelper _urlHelper = urlHelper
            ?? throw new ArgumentNullException(nameof(urlHelper));

    /// <summary>Canonical URL.</summary>
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
            SeoHelper.LinkCanonical);

        var linkCanonical =
            AbsoluteUrlUtility.Resolve(
                _urlHelper,
                value,
                SeoHelper.SiteUrl);

        if (string.IsNullOrWhiteSpace(linkCanonical))
        {
            output.SuppressOutput();
            return;
        }

        output.TagName = "link";
        output.TagMode = TagMode.SelfClosing;

        output.Attributes.Clear();

        output.Attributes.SetAttribute("rel", "canonical");
        output.Attributes.SetAttribute("href", linkCanonical);
    }
}


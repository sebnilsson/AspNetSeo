using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders the Open Graph image tag.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement("og-image", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgImageTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    /// <summary>Image URL.</summary>
    public string? Value { get; set; }

    /// <summary>Builds the tag.</summary>
    /// <param name="context">Tag helper context.</param>
    /// <param name="output">Tag helper output.</param>
    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        var content = TagValueUtility.GetContent(
            Value,
            SeoHelper.OgImage);

        output.ProcessOpenGraph(OgMetaName.Image, content);
    }
}


using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders the Open Graph determiner tag.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement("og-determiner", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgDeterminerTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    /// <summary>Determiner value.</summary>
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
            SeoHelper.OgDeterminer);

        output.ProcessOpenGraph(OgMetaName.Determiner, content);
    }
}


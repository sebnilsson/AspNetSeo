using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders the Open Graph title tag.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement(Tag, TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgTitleTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    /// <summary>Element tag name.</summary>
    public const string Tag = "og-title";

    /// <summary>Title value.</summary>
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
            SeoHelper.OgTitle,
            SeoHelper.PageTitle);

        output.ProcessOpenGraph(OgMetaName.Title, content);
    }
}


using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders the Open Graph site name tag.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement("og-site-name", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgSiteNameTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    /// <summary>Site name value.</summary>
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
            SeoHelper.OgSiteName,
            SeoHelper.SiteName);

        output.ProcessOpenGraph(OgMetaName.SiteName, content);
    }
}


using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders the meta robots tag.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement("meta-robots", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class MetaRobotsTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    /// <summary>Follow directive.</summary>
    public bool? Follow { get; set; }

    /// <summary>Index directive.</summary>
    public bool? Index { get; set; }

    /// <summary>Explicit value.</summary>
    public string? Value { get; set; }

    /// <summary>Builds the tag.</summary>
    /// <param name="context">Tag helper context.</param>
    /// <param name="output">Tag helper output.</param>
    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        if (Follow != null || Index != null)
        {
            SeoHelper.SetMetaRobots(Index ?? true, Follow ?? true);
        }

        var content = TagValueUtility.GetContent(
            Value,
            SeoHelper.MetaRobots);

        output.ProcessMeta(MetaName.Robots, content);
    }
}


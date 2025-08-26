using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders the Open Graph audio tag.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement("og-audio", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgAudioTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    /// <summary>Audio URL.</summary>
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
            SeoHelper.OgAudio);

        output.ProcessOpenGraph(OgMetaName.Audio, content);
    }
}


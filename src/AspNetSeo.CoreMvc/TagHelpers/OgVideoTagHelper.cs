using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

[HtmlTargetElement("og-video", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgVideoTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    public string? Value { get; set; }

    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        var content = TagValueUtility.GetContent(
            Value,
            SeoHelper.OgVideo);

        output.ProcessOpenGraph(OgMetaName.Video, content);
    }
}

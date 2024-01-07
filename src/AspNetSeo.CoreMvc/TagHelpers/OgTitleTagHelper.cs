using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

[HtmlTargetElement(Tag, TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgTitleTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    public const string Tag = "og-title";

    public string? Value { get; set; }

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

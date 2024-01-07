using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

[HtmlTargetElement("og-site-name", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgSiteNameTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    public string? Value { get; set; }

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

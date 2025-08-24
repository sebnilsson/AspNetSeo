using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

[HtmlTargetElement("og-locale", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class OgLocaleTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    public string? Value { get; set; }

    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        var content = TagValueUtility.GetContent(
            Value,
            SeoHelper.OgLocale);

        output.ProcessOpenGraph(OgMetaName.Locale, content);
    }
}

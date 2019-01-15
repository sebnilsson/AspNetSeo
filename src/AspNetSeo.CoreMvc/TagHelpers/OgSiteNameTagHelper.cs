using AspNetSeo.CoreMvc.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("og-site-name", TagStructure = TagStructure.WithoutEndTag)]
    [OutputElementHint("meta")]
    public class OgSiteNameTagHelper : SeoTagHelperBase
    {
        public OgSiteNameTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public string Value { get; set; }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            var content = TagValueUtility.GetContent(
                Value,
                SeoHelper.OgSiteName,
                SeoHelper.SiteName);

            output.ProcessMeta(OgMetaName.SiteName, content);
        }
    }
}
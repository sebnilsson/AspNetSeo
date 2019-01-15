using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoOgSiteNameTagHelper : SeoTagHelperBase
    {
        internal const string TagName = "seo-og-site-name";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public SeoOgSiteNameTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ProcessMetaTag(
                output,
                "og:site_name",
                Value,
                SeoHelper.OgSiteName,
                SeoHelper.BaseTitle);
        }
    }
}
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoOgTitleTagHelper : SeoTagHelperBase
    {
        internal const string TagName = "seo-og-title";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public SeoOgTitleTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ProcessMetaTag(output, "og:title", Value, SeoHelper.OgTitle);
        }
    }
}
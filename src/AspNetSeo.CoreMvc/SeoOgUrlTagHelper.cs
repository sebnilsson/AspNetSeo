using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoOgUrlTagHelper : SeoTagHelperBase
    {
        internal const string TagName = "seo-og-url";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public SeoOgUrlTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ProcessMetaTag(
                output,
                "og:url",
                Value,
                SeoHelper.OgUrl,
                SeoHelper.LinkCanonical);
        }
    }
}
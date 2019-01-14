using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoOgDescriptionTagHelper : SeoTagHelperBase
    {
        internal const string TagName = "seo-og-description";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public SeoOgDescriptionTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ProcessMetaTag(output, "og:description", Value, SeoHelper.OgDescription);
        }
    }
}
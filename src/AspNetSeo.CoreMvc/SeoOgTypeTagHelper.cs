using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoOgTypeTagHelper : SeoTagHelperBase
    {
        internal const string TagName = "seo-og-type";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public SeoOgTypeTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ProcessMetaTag(output, "og:type", Value, SeoHelper.OgType);
        }
    }
}
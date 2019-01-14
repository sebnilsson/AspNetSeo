using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoOgImageTagHelper : SeoTagHelperBase
    {
        internal const string TagName = "seo-og-image";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public SeoOgImageTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ProcessMetaTag(output, "og:image", Value, SeoHelper.OgImage);
        }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public SeoOgUrlTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            string combinedLinkCanonical =
                LinkCanonicalUtility.GetLinkCanonical(
                    SeoHelper,
                    ViewContext,
                    Value);

            SetMetaTagOutput(output, "og:url", combinedLinkCanonical);
        }
    }
}
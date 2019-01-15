using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoLinkCanonicalTagHelper : SeoTagHelperBase
    {
        internal const string BaseAttributeName = "base";

        internal const string TagName = "seo-link-canonical";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(BaseAttributeName)]
        public string Base { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public SeoLinkCanonicalTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string combinedLinkCanonical =
                LinkCanonicalUtility.GetLinkCanonical(
                    SeoHelper,
                    ViewContext,
                    Value,
                    Base);

            if (string.IsNullOrWhiteSpace(combinedLinkCanonical))
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "link";

            output.Attributes.Clear();

            output.Attributes.SetAttribute("rel", "canonical");
            output.Attributes.SetAttribute("href", combinedLinkCanonical);
        }
    }
}
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoMetaKeywordsTagHelper : SeoTagHelperBase
    {
        internal const string TagName = "seo-meta-keywords";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public SeoMetaKeywordsTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var metaKeywords = !string.IsNullOrWhiteSpace(Value) ? Value : SeoHelper.MetaKeywords;
            if (metaKeywords == null)
            {
                output.SuppressOutput();
                return;
            }

            output.Attributes.RemoveAll(nameof(Value));

            SetMetaTagOutput(output, name: "keywords", content: metaKeywords);
        }
    }
}
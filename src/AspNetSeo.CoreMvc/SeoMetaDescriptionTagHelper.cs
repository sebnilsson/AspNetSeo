using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoMetaDescriptionTagHelper : SeoTagHelperBase
    {
        internal const string TagName = "seo-meta-description";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public SeoMetaDescriptionTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var metaDescription = !string.IsNullOrWhiteSpace(this.Value) ? this.Value : this.SeoHelper.MetaDescription;
            if (metaDescription == null)
            {
                output.SuppressOutput();
                return;
            }

            output.Attributes.RemoveAll(nameof(this.Value));

            this.SetMetaTagOutput(output, name: "description", content: metaDescription);
        }
    }
}
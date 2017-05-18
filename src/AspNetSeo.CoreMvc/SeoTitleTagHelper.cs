using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoTitleTagHelper : SeoTagHelperBase
    {
        internal const string TagName = "seo-title";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }

        public SeoTitleTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var title = !string.IsNullOrWhiteSpace(this.Value) ? this.Value : this.SeoHelper.Title;

            var fullTitle = SeoHelperTitleHelper.GetFullTitle(this.SeoHelper, title);

            if (fullTitle == null)
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "title";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.RemoveAll(nameof(this.Value));

            output.Content.SetContent(fullTitle);
        }
    }
}
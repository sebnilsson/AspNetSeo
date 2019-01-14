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
            var title = !string.IsNullOrWhiteSpace(Value) ? Value : SeoHelper.Title;

            var fullTitle = SeoHelperTitleHelper.GetFullTitle(SeoHelper, title);

            if (fullTitle == null)
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "title";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.RemoveAll(nameof(Value));

            output.Content.SetContent(fullTitle);
        }
    }
}
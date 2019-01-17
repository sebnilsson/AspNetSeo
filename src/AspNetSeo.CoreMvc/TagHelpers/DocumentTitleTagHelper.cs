using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("document-title", TagStructure = TagStructure.WithoutEndTag)]
    [OutputElementHint("title")]
    public class DocumentTitleTagHelper : SeoTagHelperBase
    {
        public DocumentTitleTagHelper(ISeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            var documentTitle = SeoHelper.DocumentTitle;
            if (documentTitle == null)
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "title";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Clear();

            output.Content.SetContent(documentTitle);
        }
    }
}
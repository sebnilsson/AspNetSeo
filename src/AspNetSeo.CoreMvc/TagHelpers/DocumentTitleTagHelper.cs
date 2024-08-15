using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

[HtmlTargetElement("document-title", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("title")]
public class DocumentTitleTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
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

        output.Content.SetHtmlContent(documentTitle);
    }
}

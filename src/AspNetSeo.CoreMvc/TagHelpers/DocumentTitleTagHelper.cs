using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders the document title element.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement("document-title", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("title")]
public class DocumentTitleTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    /// <summary>Builds the title tag.</summary>
    /// <param name="context">Tag helper context.</param>
    /// <param name="output">Tag helper output.</param>
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


using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.Testing;

public static class TagHelperExtensions
{
    public static string GetHtml(
        this TagHelper tagHelper,
        string tagName)
    {
        var tagHelperContext = new TagHelperContext(
            [],
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));

        var tagHelperOutput = new TagHelperOutput(tagName,
            [],
            (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent(string.Empty);

                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });

        tagHelper.Process(tagHelperContext, tagHelperOutput);

        string html;
        using (var writer = new StringWriter())
        {
            tagHelperOutput.WriteTo(writer, HtmlEncoder.Default);

            html = writer.ToString();
        }

        return html;
    }
}

using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders all SEO related tags using values from <see cref="ISeoHelper"/>.
/// </summary>
[HtmlTargetElement("seo-tags", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("title")]
public class SeoTagsTagHelper : SeoTagHelperBase
{
    private readonly ISeoUrlHelper _urlHelper;

    /// <summary>
    /// Initializes a new instance of the <see cref="SeoTagsTagHelper"/> class.
    /// </summary>
    /// <param name="seoHelper">The SEO helper providing tag values.</param>
    /// <param name="urlHelper">The URL helper used to resolve absolute URLs.</param>
    public SeoTagsTagHelper(ISeoHelper seoHelper, ISeoUrlHelper urlHelper)
        : base(seoHelper)
    {
        _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
    }

    /// <summary>
    /// Generates the markup for all tags associated with <see cref="ISeoHelper"/>.
    /// </summary>
    /// <param name="context">The execution context.</param>
    /// <param name="output">The HTML output.</param>
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(output);

        output.TagName = null;
        output.Attributes.Clear();

        var sb = new StringBuilder();

        void Append(TagHelper tagHelper, string tagName)
        {
            var html = GetHtml(tagHelper, tagName);
            if (string.IsNullOrEmpty(html))
            {
                return;
            }

            if (sb.Length > 0)
            {
                sb.AppendLine();
            }

            sb.Append(html);
        }

        Append(new DocumentTitleTagHelper(SeoHelper), "document-title");
        Append(new LinkCanonicalTagHelper(SeoHelper, _urlHelper), "link-canonical");
        Append(new MetaDescriptionTagHelper(SeoHelper), "meta-description");
        Append(new MetaKeywordsTagHelper(SeoHelper), "meta-keywords");
        Append(new MetaRobotsTagHelper(SeoHelper), "meta-robots");
        Append(new CustomMetasTagHelper(SeoHelper), "custom-metas");
        Append(new OgAudioTagHelper(SeoHelper), "og-audio");
        Append(new OgDescriptionTagHelper(SeoHelper), "og-description");
        Append(new OgDeterminerTagHelper(SeoHelper), "og-determiner");
        Append(new OgImageTagHelper(SeoHelper), "og-image");
        Append(new OgLocaleTagHelper(SeoHelper), "og-locale");
        Append(new OgLocaleAlternateTagHelper(SeoHelper), "og-locale-alternate");
        Append(new OgSiteNameTagHelper(SeoHelper), "og-site-name");
        Append(new OgTitleTagHelper(SeoHelper), "og-title");
        Append(new OgTypeTagHelper(SeoHelper), "og-type");
        Append(new OgUrlTagHelper(SeoHelper, _urlHelper), "og-url");
        Append(new OgVideoTagHelper(SeoHelper), "og-video");

        output.Content.SetHtmlContent(sb.ToString());
    }

    private static string GetHtml(TagHelper tagHelper, string tagName)
    {
        var tagHelperContext = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));

        var tagHelperOutput = new TagHelperOutput(
            tagName,
            new TagHelperAttributeList(),
            (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent(string.Empty);
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });

        tagHelper.Process(tagHelperContext, tagHelperOutput);

        using var writer = new StringWriter();
        tagHelperOutput.WriteTo(writer, HtmlEncoder.Default);

        return writer.ToString();
    }
}


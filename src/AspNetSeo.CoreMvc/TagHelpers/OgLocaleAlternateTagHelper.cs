using AspNetSeo.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders Open Graph locale alternates.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement("og-locale-alternate", TagStructure = TagStructure.NormalOrSelfClosing)]
public class OgLocaleAlternateTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    /// <summary>Optional locale value.</summary>
    public string? Value { get; set; }

    /// <summary>Builds the tags.</summary>
    /// <param name="context">Tag helper context.</param>
    /// <param name="output">Tag helper output.</param>
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var values = Value != null
            ? [Value]
            : SeoHelper.OgLocaleAlternates;

        if (values == null || !values.Any())
        {
            output.SuppressOutput();
            return;
        }

        output.TagName = null;
        output.Attributes.Clear();

        var isFirst = true;
        foreach (var locale in values)
        {
            if (string.IsNullOrWhiteSpace(locale))
            {
                continue;
            }

            if (!isFirst)
            {
                output.Content.AppendHtml(Environment.NewLine);
            }

            var tag = new TagBuilder("meta")
            {
                TagRenderMode = TagRenderMode.SelfClosing
            };

            tag.Attributes["property"] = OgMetaName.LocaleAlternate;
            tag.Attributes["content"] = locale;

            output.Content.AppendHtml(tag);
            isFirst = false;
        }

        if (isFirst)
        {
            output.SuppressOutput();
        }
    }
}


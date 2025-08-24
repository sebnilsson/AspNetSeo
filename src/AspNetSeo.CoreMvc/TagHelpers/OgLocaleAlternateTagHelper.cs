using AspNetSeo.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

[HtmlTargetElement("og-locale-alternate", TagStructure = TagStructure.NormalOrSelfClosing)]
public class OgLocaleAlternateTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    public string? Value { get; set; }

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

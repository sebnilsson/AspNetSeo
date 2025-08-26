using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using AspNetSeo;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders custom meta elements.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement("custom-metas", TagStructure = TagStructure.NormalOrSelfClosing)]
public class CustomMetasTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    /// <summary>Builds the meta tags.</summary>
    /// <param name="context">Tag helper context.</param>
    /// <param name="output">Tag helper output.</param>
    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        if (!SeoHelper.CustomMetas.Any())
        {
            output.SuppressOutput();
            return;
        }

        output.TagName = null;
        output.Attributes.Clear();

        var isFirst = true;
        foreach (var custom in SeoHelper.CustomMetas.Values)
        {
            if (!isFirst)
                output.Content.AppendHtml(Environment.NewLine);

            AddCustomMeta(output, custom);

            isFirst = false;
        }
    }

    private void AddCustomMeta(TagHelperOutput output, CustomMetaItem item)
    {
        var name = item.Key;
        var content = item.Value;

        if (name == null || content == null)
        {
            return;
        }

        var tag = new TagBuilder("meta")
        {
            TagRenderMode = TagRenderMode.SelfClosing
        };

        var attributeName = ShouldUseProperty(item)
            ? "property"
            : "name";

        tag.Attributes[attributeName] = name;
        tag.Attributes["content"] = content;

        output.Content.AppendHtml(tag);
    }

    private bool ShouldUseProperty(CustomMetaItem item)
    {
        if (item.Attribute is CustomMetaAttributeKey attr)
        {
            return attr == CustomMetaAttributeKey.Property;
        }

        return DetectProperty(item.Key);
    }

    private static bool DetectProperty(string key)
    {
        foreach (var prefix in PropertyPrefixes)
        {
            if (key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private static readonly string[] PropertyPrefixes =
    [
        "og:",
        "fb:",
        "article:",
        "music:",
        "video:",
        "profile:",
        "book:",
        "books:",
        "business:",
        "product:",
        "place:"
    ];
}


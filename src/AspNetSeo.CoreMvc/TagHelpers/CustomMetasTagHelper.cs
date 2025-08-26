using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Renders custom meta elements.
/// </summary>
/// <param name="seoHelper">The SEO helper.</param>
[HtmlTargetElement("custom-metas", TagStructure = TagStructure.NormalOrSelfClosing)]
public class CustomMetasTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    private const string ATTRIBUTE_KEY_NAME = "name";
    private const string ATTRIBUTE_KEY_PROPERTY = "property";

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
            {
                output.Content.AppendHtml(Environment.NewLine);
            }

            AddCustomMeta(output, custom);

            isFirst = false;
        }
    }

    private static void AddCustomMeta(TagHelperOutput output, CustomMetaItem item)
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

        var attributeName = GetAttributeName(item);

        tag.Attributes[attributeName] = name;
        tag.Attributes["content"] = content;

        output.Content.AppendHtml(tag);
    }

    private static string GetAttributeName(CustomMetaItem item)
    {
        if (item.Attribute is CustomMetaAttributeKey attr)
        {
            return attr == CustomMetaAttributeKey.Property ? ATTRIBUTE_KEY_PROPERTY : ATTRIBUTE_KEY_NAME;
        }

        var isProperty = s_propertyPrefixes.Any(x => item.Key.StartsWith(x));

        return isProperty ? ATTRIBUTE_KEY_PROPERTY : ATTRIBUTE_KEY_NAME;
    }

    private static readonly string[] s_propertyPrefixes =
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


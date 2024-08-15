using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.Internal;

internal static class TagHelperOutputProcessExtensions
{
    public static void ProcessMeta(
        this TagHelperOutput output,
        string name,
        string? content)
    {
        ArgumentNullException.ThrowIfNull(output);
        ArgumentNullException.ThrowIfNull(name);

        ProcessInternal(output, name, content, "name");
    }

    public static void ProcessOpenGraph(
        this TagHelperOutput output,
        string name,
        string? content)
    {
        ArgumentNullException.ThrowIfNull(output);
        ArgumentNullException.ThrowIfNull(name);

        ProcessInternal(output, name, content, "property");
    }

    private static void ProcessInternal(
        this TagHelperOutput output,
        string name,
        string? content,
        string attributeName)
    {
        if (content == null)
        {
            output.SuppressOutput();
            return;
        }

        output.TagName = "meta";
        output.TagMode = TagMode.SelfClosing;

        output.Attributes.Clear();

        output.Attributes.SetAttribute(attributeName, name);
        output.Attributes.SetAttribute("content", content);
    }
}

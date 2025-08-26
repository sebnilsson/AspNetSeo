namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

public abstract class TagHelperTestBase
{
    public static string MetaTag(string name, string content, bool reverseAttributes = false)
    {
        return reverseAttributes
            ? $"<meta name=\"{name}\" content=\"{content}\" />"
            : $"<meta content=\"{content}\" name=\"{name}\" />";
    }

    public static string OpenGraphTag(string name, string content, bool reverseAttributes = false)
    {
        return !reverseAttributes
            ? $"<meta property=\"{name}\" content=\"{content}\" />"
            : $"<meta content=\"{content}\" property=\"{name}\" />";
    }
}

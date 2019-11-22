namespace AspNetSeo.CoreMvc.Tests.TagHelpers
{
    public abstract class TagHelperTestBase
    {
        public static string MetaTag(string name, string content)
        {
            return $"<meta name=\"{name}\" content=\"{content}\" />";
        }

        public static string MetaTagContentFirst(string name, string content)
        {
            return $"<meta content=\"{content}\" name=\"{name}\" />";
        }

        public static string OpenGraphTag(string name, string content)
        {
            return $"<meta property=\"{name}\" content=\"{content}\" />";
        }
    }
}

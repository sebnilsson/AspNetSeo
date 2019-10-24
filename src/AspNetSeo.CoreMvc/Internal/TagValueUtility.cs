using System.Linq;

namespace AspNetSeo.CoreMvc.Internal
{
    internal static class TagValueUtility
    {
        public static string GetContent(
            string htmlValue,
            string content,
            params string[] fallbackContents)
        {
            var outputContent =
                !string.IsNullOrWhiteSpace(htmlValue)
                ? htmlValue
                : content;

            return
                outputContent
                ?? fallbackContents.FirstOrDefault(x => x != null);
        }
    }
}

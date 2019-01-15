namespace AspNetSeo.CoreMvc.Internal
{
    internal static class TagValueUtility
    {
        public static string GetContent(
            string htmlValue,
            string content,
            string fallbackContent = null)
        {
            var outputContent =
                !string.IsNullOrWhiteSpace(htmlValue)
                ? htmlValue
                : content;

            return outputContent ?? fallbackContent;
        }
    }
}
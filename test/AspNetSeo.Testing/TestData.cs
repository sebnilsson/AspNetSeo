namespace AspNetSeo.Testing
{
    public static class TestData
    {
        public static readonly string BaseTitle = $"Test{nameof(SeoHelper.BaseTitle)}";

        public static readonly string AppRelativeLinkCanonical = $"~/Test/{nameof(SeoHelper.LinkCanonical)}.html";

        public static readonly string LinkCanonical = $"/Test/{nameof(SeoHelper.LinkCanonical)}.html";

        public static readonly string MetaDescription = $"Test{nameof(SeoHelper.MetaDescription)}";

        public static readonly string MetaKeywords = $"Test{nameof(SeoHelper.MetaKeywords)}";

        public static readonly string Title = $"Test{nameof(SeoHelper.Title)}";

        public static readonly string TitleFormat = "{1} > {0}";
    }
}
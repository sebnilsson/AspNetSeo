namespace AspNetSeo.Testing
{
    public static class TestData
    {
        public static readonly string BaseTitle = $"Test{nameof(SeoHelper.BaseTitle)}";

        public static readonly string AppRelativeLinkCanonical = $"~/Test/{nameof(SeoHelper.LinkCanonical)}.html";

        public static readonly string LinkCanonical = $"/Test/{nameof(SeoHelper.LinkCanonical)}.html";

        public static readonly string MetaDescription = $"Test{nameof(SeoHelper.MetaDescription)}";

        public static readonly string MetaKeywords = $"Test{nameof(SeoHelper.MetaKeywords)}";

        public static readonly string OgDescription = $"Test{nameof(SeoHelper.OgDescription)}";

        public static readonly string OgImage = $"Test{nameof(SeoHelper.OgImage)}";

        public static readonly string OgSiteName = $"Test{nameof(SeoHelper.OgSiteName)}";

        public static readonly string OgTitle = $"Test{nameof(SeoHelper.OgTitle)}";

        public static readonly string OgType = $"Test{nameof(SeoHelper.OgType)}";

        public static readonly string OgUrl = $"Test{nameof(SeoHelper.OgUrl)}";

        public static readonly string Title = $"Test{nameof(SeoHelper.Title)}";

        public static readonly string TitleFormat = "{1} > {0}";
    }
}
using System;

namespace AspNetSeo.Testing
{
    public static class TagHelperTestFactory
    {
        public static TTagHelper Create<TTagHelper>(
            Func<ISeoHelper, TTagHelper> tagHelperFactory,
            Action<ISeoHelper> seoConfig = null,
            Action<TTagHelper> tagConfig = null)
        {
            var seoHelper = new SeoHelper();
            seoConfig?.Invoke(seoHelper);

            var tagHelper = tagHelperFactory(seoHelper);
            tagConfig?.Invoke(tagHelper);

            return tagHelper;
        }
    }
}
using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaKeywordsAttribute : SeoAttributeBase
    {
        private readonly string _metaKeywords;

        public SeoMetaKeywordsAttribute(string metaKeywords)
        {
            _metaKeywords = metaKeywords;

            Append = true;
        }

        public bool Append { get; set; }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (Append)
            {
                seoHelper.AddMetaKeyword(_metaKeywords);
            }
            else
            {
                seoHelper.MetaKeywords = _metaKeywords;
            }
        }
    }
}
using System;

#if NETSTANDARD
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaKeywordsAttribute : SeoAttributeBase
    {
        private readonly string metaKeywords;

        public SeoMetaKeywordsAttribute(string metaKeywords)
        {
            this.metaKeywords = metaKeywords;

            this.Append = true;
        }

        public bool Append { get; set; }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (this.Append)
            {
                seoHelper.AddMetaKeyword(this.metaKeywords);
            }
            else
            {
                seoHelper.MetaKeywords = this.metaKeywords;
            }
        }
    }
}
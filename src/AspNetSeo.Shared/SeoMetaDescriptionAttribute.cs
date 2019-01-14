using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaDescriptionAttribute : SeoAttributeBase
    {
        private readonly string _metaDescription;

        public SeoMetaDescriptionAttribute(string metaDescription)
        {
            _metaDescription = metaDescription;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.MetaDescription = _metaDescription;
        }
    }
}
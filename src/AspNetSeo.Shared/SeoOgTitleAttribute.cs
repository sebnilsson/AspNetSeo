using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoOgTitleAttribute : SeoAttributeBase
    {
        private readonly string _title;

        public SeoOgTitleAttribute(string title)
        {
            _title = title;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.OgTitle = _title;
        }
    }
}
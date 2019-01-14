using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoOgUrlAttribute : SeoAttributeBase
    {
        private readonly string _url;

        public SeoOgUrlAttribute(string url)
        {
            _url = url;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.OgUrl = _url;
        }
    }
}
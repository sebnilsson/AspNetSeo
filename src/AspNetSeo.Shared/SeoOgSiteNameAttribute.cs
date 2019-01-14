using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoOgSiteNameAttribute : SeoAttributeBase
    {
        private readonly string _name;

        public SeoOgSiteNameAttribute(string name)
        {
            _name = name;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.OgSiteName = _name;
        }
    }
}
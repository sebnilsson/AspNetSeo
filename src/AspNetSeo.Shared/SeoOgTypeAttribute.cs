using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoOgTypeAttribute : SeoAttributeBase
    {
        private readonly string _type;

        public SeoOgTypeAttribute(string type)
        {
            _type = type;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.OgType = _type;
        }
    }
}
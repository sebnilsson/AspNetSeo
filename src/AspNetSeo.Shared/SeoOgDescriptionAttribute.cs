using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoOgDescriptionAttribute : SeoAttributeBase
    {
        private readonly string _description;

        public SeoOgDescriptionAttribute(string description)
        {
            _description = description;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.OgDescription = _description;
        }
    }
}
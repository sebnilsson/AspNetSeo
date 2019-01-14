using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoOgImageAttribute : SeoAttributeBase
    {
        private readonly string _image;

        public SeoOgImageAttribute(string image)
        {
            _image = image;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.OgImage = _image;
        }
    }
}
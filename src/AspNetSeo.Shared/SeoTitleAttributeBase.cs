using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public abstract class SeoTitleAttributeBase : SeoAttributeBase
    {
        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }
            
            if (!string.IsNullOrWhiteSpace(Format))
            {
                seoHelper.TitleFormat = Format;
            }
        }

        public string Format { get; set; }
    }
}
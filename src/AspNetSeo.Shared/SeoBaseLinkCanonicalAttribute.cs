using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class SeoBaseLinkCanonicalAttribute : SeoAttributeBase
    {
        private readonly string _linkCanonical;

        public SeoBaseLinkCanonicalAttribute(string linkCanonical)
        {
            _linkCanonical = linkCanonical;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            seoHelper.BaseLinkCanonical = _linkCanonical;
        }
    }
}
using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoLinkCanonicalAttribute : SeoAttributeBase
    {
        private readonly string _linkCanonical;

        public SeoLinkCanonicalAttribute(string linkCanonical)
        {
            _linkCanonical = linkCanonical;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.LinkCanonical = _linkCanonical;
        }
    }
}
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
        private readonly string linkCanonical;

        public SeoBaseLinkCanonicalAttribute(string linkCanonical)
        {
            this.linkCanonical = linkCanonical;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            seoHelper.BaseLinkCanonical = this.linkCanonical;
        }
    }
}
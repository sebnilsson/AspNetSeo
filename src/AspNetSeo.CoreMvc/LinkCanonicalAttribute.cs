using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class LinkCanonicalAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public LinkCanonicalAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.LinkCanonical = _value;
        }
    }
}
using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class OgTitleAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public OgTitleAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.OgTitle = _value;
        }
    }
}
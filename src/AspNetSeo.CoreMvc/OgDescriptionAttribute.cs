using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class OgDescriptionAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public OgDescriptionAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.OgDescription = _value;
        }
    }
}
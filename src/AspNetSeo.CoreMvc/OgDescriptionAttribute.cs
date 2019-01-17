using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OgDescriptionAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public OgDescriptionAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.OgDescription = _value;
        }
    }
}
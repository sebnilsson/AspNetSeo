using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OgUrlAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public OgUrlAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.OgUrl = _value;
        }
    }
}
using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OgTypeAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public OgTypeAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.OgType = _value;
        }
    }
}
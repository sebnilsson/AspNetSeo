using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MetaKeywordsAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public MetaKeywordsAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.MetaKeywords = _value;
        }
    }
}
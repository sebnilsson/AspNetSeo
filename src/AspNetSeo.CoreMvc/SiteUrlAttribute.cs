using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class SiteUrlAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public SiteUrlAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.SiteUrl = _value;
        }
    }
}
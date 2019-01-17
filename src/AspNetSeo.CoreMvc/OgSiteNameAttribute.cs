using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OgSiteNameAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public OgSiteNameAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.OgSiteName = _value;
        }
    }
}
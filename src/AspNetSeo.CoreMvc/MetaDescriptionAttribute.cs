using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MetaDescriptionAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public MetaDescriptionAttribute(string value)
        {
            _value = value;
        }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.MetaDescription = _value;
        }
    }
}
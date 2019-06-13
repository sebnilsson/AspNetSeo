using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class CustomMetaAttribute : SeoAttributeBase
    {
        private readonly string _name;
        private readonly string _content;

        public CustomMetaAttribute(string name, string content)
        {
            _name = name
                ?? throw new ArgumentNullException(nameof(name));
            _content = content;
        }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.CustomMetas[_name] = _content;
        }
    }
}
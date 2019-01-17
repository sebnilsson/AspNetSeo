using System;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class PageTitleAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public PageTitleAttribute(string value)
        {
            _value = value;
        }

        public string Format { get; set; }

        public bool OverrideSiteName { get; set; }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.PageTitle = _value;

            if (Format != null)
            {
                seoHelper.DocumentTitleFormat = Format;
            }
            if (OverrideSiteName)
            {
                seoHelper.SiteName = null;
            }
        }
    }
}
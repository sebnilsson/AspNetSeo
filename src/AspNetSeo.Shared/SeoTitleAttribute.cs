using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class SeoTitleAttribute : SeoTitleAttributeBase
    {
        private readonly string _title;

        public SeoTitleAttribute(string title)
        {
            _title = title;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            base.OnHandleSeoValues(seoHelper);

            seoHelper.Title = _title;

            if (OverrideBaseTitle)
            {
                seoHelper.BaseTitle = null;
            }
        }

        public bool OverrideBaseTitle { get; set; }
    }
}
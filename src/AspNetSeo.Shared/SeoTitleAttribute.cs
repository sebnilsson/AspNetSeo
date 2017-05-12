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
        private readonly string title;

        public SeoTitleAttribute(string title)
        {
            this.title = title;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            base.OnHandleSeoValues(seoHelper);

            seoHelper.Title = this.title;

            if (this.OverrideBaseTitle)
            {
                seoHelper.BaseTitle = null;
            }
        }

        public bool OverrideBaseTitle { get; set; }
    }
}
using System;

#if NETSTANDARD
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class SeoBaseTitleAttribute : SeoTitleAttributeBase
    {
        private readonly string title;

        public SeoBaseTitleAttribute(string title)
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

            seoHelper.BaseTitle = this.title;
        }
    }
}
using System;

using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc
{
    public abstract class SeoController : Controller
    {
        private readonly Lazy<SeoHelper> seoLazy;

        public SeoHelper Seo => this.seoLazy.Value;

        protected SeoController()
        {
            this.seoLazy = new Lazy<SeoHelper>(this.GetSeoHelper);
        }
    }
}
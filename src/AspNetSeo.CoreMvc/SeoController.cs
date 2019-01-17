using System;

using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc
{
    public abstract class SeoController : Controller
    {
        private readonly Lazy<ISeoHelper> seoLazy;

        public ISeoHelper Seo => seoLazy.Value;

        protected SeoController()
        {
            seoLazy = new Lazy<ISeoHelper>(this.GetSeoHelper);
        }
    }
}
using System;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    public abstract class SeoTagHelperBase : TagHelper
    {
        protected readonly ISeoHelper SeoHelper;

        protected SeoTagHelperBase(ISeoHelper seoHelper)
        {
            SeoHelper = seoHelper
                ?? throw new ArgumentNullException(nameof(seoHelper));
        }
    }
}
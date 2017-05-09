using System;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    public abstract class SeoTagHelperBase : TagHelper
    {
        protected readonly SeoHelper SeoHelper;

        protected SeoTagHelperBase(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            this.SeoHelper = seoHelper;
        }

        protected void SetMetaTagOutput(TagHelperOutput output, string name, string content)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (content == null)
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "meta";

            output.Attributes.SetAttribute("name", name);
            output.Attributes.SetAttribute("content", content);
        }
    }
}
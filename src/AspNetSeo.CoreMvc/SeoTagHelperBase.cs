using System;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    public abstract class SeoTagHelperBase : TagHelper
    {
        protected readonly SeoHelper SeoHelper;

        protected SeoTagHelperBase(SeoHelper seoHelper)
        {
            SeoHelper = seoHelper
                ?? throw new ArgumentNullException(nameof(seoHelper));
        }

        protected void ProcessMetaTag(
            TagHelperOutput output,
            string name,
            string htmlValue,
            string content,
            string fallbackContent = null)
        {
            if (output == null)
                throw new ArgumentNullException(nameof(output));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var outputContent =
                !string.IsNullOrWhiteSpace(htmlValue)
                ? htmlValue
                : (content ?? fallbackContent);

            if (outputContent == null)
            {
                output.SuppressOutput();
                return;
            }

            output.Attributes.RemoveAll("Value");

            SetMetaTagOutput(output, name, content: outputContent);
        }

        protected void SetMetaTagOutput(
            TagHelperOutput output,
            string name,
            string content)
        {
            if (output == null)
                throw new ArgumentNullException(nameof(output));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

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
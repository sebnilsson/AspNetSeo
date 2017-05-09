using System.Collections.Generic;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.Tests
{
    public static class TagHelperExtensions
    {
        public static TagHelperOutput Process(
            this TagHelper tagHelper,
            string tagName,
            IEnumerable<TagHelperAttribute> contextAttributes = null)
        {
            var context = TagHelperTestFactory.CreateContext(contextAttributes);

            var output = TagHelperTestFactory.CreateOutput(SeoLinkCanonicalTagHelper.TagName);

            tagHelper.Process(context, output);

            return output;
        }
    }
}
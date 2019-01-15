using System.Collections.Generic;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.Testing
{
    public static class TagHelperExtensions
    {
        public static TagHelperOutput Process(
            this TagHelper tagHelper,
            string tagName,
            IEnumerable<TagHelperAttribute> contextAttributes = null)
        {
            var context = TagHelperTestFactory.CreateContext(contextAttributes);

            var output = TagHelperTestFactory.CreateOutput(tagName);

            tagHelper.Process(context, output);

            return output;
        }
    }
}
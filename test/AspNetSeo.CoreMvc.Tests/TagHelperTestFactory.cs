using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.Tests
{
    public static class TagHelperTestFactory
    {
        public static TagHelperOutput CreateOutput(
            string tagName,
            IEnumerable<TagHelperAttribute> attributes = null,
            Func<bool, HtmlEncoder, Task<TagHelperContent>> getChildContentAsync = null)
        {
            var attributeList = (attributes != null)
                                    ? new TagHelperAttributeList(attributes)
                                    : new TagHelperAttributeList();

            getChildContentAsync = getChildContentAsync ?? DefaultGetChildContentAsync;

            var output = new TagHelperOutput(tagName, attributeList, getChildContentAsync);
            return output;
        }

        public static TagHelperContext CreateContext(IEnumerable<TagHelperAttribute> attributes = null)
        {
            var attributeList = (attributes != null)
                                    ? new TagHelperAttributeList(attributes)
                                    : new TagHelperAttributeList();
            var items = new Dictionary<object, object>();
            var uniqueId = Convert.ToString(Guid.NewGuid());

            var context = new TagHelperContext(attributeList, items, uniqueId);
            return context;
        }

        private static async Task<TagHelperContent> DefaultGetChildContentAsync(
            bool useCachedResult,
            HtmlEncoder encoder)
        {
            var tagHelperContent = new DefaultTagHelperContent();

            await Task.CompletedTask;

            return tagHelperContent;
        }
    }
}
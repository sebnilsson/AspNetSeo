using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.Testing
{
    public static class TagHelperExtensions
    {
        //public static TagHelperOutput Process(
        //    this TagHelper tagHelper,
        //    string tagName,
        //    IEnumerable<TagHelperAttribute> contextAttributes = null)
        //{
        //    var context = TagHelperTestFactory.CreateContext(contextAttributes);

        //    var output = TagHelperTestFactory.CreateOutput(tagName);

        //    tagHelper.Process(context, output);

        //    return output;
        //}

        public static string GetHtml(
            this TagHelper tagHelper,
            string tagName)
        {
            var tagHelperContext = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                Guid.NewGuid().ToString("N"));

            var tagHelperOutput = new TagHelperOutput(tagName,
                new TagHelperAttributeList(),
                (result, encoder) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetHtmlContent(string.Empty);

                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                });

            tagHelper.Process(tagHelperContext, tagHelperOutput);

            string html;
            using (var writer = new StringWriter())
            {
                tagHelperOutput.WriteTo(writer, HtmlEncoder.Default);

                html = writer.ToString();
            }

            return html;
        }
    }
}
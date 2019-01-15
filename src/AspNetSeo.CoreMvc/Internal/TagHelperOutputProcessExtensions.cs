using System;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.Internal
{
    internal static class TagHelperOutputProcessExtensions
    {
        public static void ProcessMeta(
            this TagHelperOutput output,
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

            output.Attributes.Clear();

            output.Attributes.SetAttribute("name", name);
            output.Attributes.SetAttribute("content", content);
        }
    }
}
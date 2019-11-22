using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("custom-metas", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CustomMetasTagHelper : SeoTagHelperBase
    {
        public CustomMetasTagHelper(ISeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            if (!SeoHelper.CustomMetas.Any())
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = null;
            output.Attributes.Clear();

            var isFirst = true;
            foreach (var custom in SeoHelper.CustomMetas)
            {
                if (!isFirst)
                    output.Content.AppendHtml(Environment.NewLine);

                AddCustomMeta(output, custom.Key, custom.Value);

                isFirst = false;
            }
        }

        private void AddCustomMeta(TagHelperOutput output, string name, string content)
        {
            if (name == null || content == null)
            {
                return;
            }

            var tag = new TagBuilder("meta")
            {
                TagRenderMode = TagRenderMode.SelfClosing
            };

            tag.Attributes["name"] = name;
            tag.Attributes["content"] = content;

            output.Content.AppendHtml(tag);
        }
    }
}

using System.Linq;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("custom-metas", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CustomMetasTagHelper : SeoTagHelperBase
    {
        public CustomMetasTagHelper(SeoHelper seoHelper)
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

            output.Attributes.Clear();

            foreach (var custom in SeoHelper.CustomMetas)
            {
                AddCustomMeta(output, custom.Key, custom.Value);
            }
        }

        private void AddCustomMeta(TagHelperOutput output, string name, string content)
        {
            if (name == null || content == null)
            {
                return;
            }

            var tag = new TagBuilder("meta");

            tag.Attributes["name"] = name;
            tag.Attributes["content"] = content;

            output.Content.AppendHtml(tag);
        }
    }
}
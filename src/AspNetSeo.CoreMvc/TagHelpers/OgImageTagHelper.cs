using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("og-image", TagStructure = TagStructure.WithoutEndTag)]
    [OutputElementHint("meta")]
    public class OgImageTagHelper : SeoTagHelperBase
    {
        public OgImageTagHelper(ISeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public string Value { get; set; }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            var content = TagValueUtility.GetContent(
                Value,
                SeoHelper.OgImage);

            output.ProcessOpenGraph(OgMetaName.Image, content);
        }
    }
}

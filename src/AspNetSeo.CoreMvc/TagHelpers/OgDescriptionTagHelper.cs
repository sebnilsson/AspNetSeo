using AspNetSeo.CoreMvc.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("og-description", TagStructure = TagStructure.WithoutEndTag)]
    [OutputElementHint("meta")]
    public class OgDescriptionTagHelper : SeoTagHelperBase
    {
        public OgDescriptionTagHelper(ISeoHelper seoHelper)
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
                SeoHelper.OgDescription,
                SeoHelper.MetaDescription);

            output.ProcessMeta(OgMetaName.Description, content);
        }
    }
}
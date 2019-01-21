using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("meta-description", TagStructure = TagStructure.WithoutEndTag)]
    [OutputElementHint("meta")]
    public class MetaDescriptionTagHelper : SeoTagHelperBase
    {
        public MetaDescriptionTagHelper(ISeoHelper seoHelper)
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
                SeoHelper.MetaDescription);

            output.ProcessMeta(MetaName.Description, content);
        }
    }
}
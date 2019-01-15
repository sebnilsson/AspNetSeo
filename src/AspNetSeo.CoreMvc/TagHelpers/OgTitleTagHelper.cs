using AspNetSeo.CoreMvc.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("og-title", TagStructure = TagStructure.WithoutEndTag)]
    [OutputElementHint("meta")]
    public class OgTitleTagHelper : SeoTagHelperBase
    {
        public OgTitleTagHelper(SeoHelper seoHelper)
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
                SeoHelper.OgTitle,
                SeoHelper.PageTitle);

            output.ProcessMeta(OgMetaName.Title, content);
        }
    }
}
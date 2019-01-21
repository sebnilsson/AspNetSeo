using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("meta-robots", TagStructure = TagStructure.WithoutEndTag)]
    [OutputElementHint("meta")]
    public class MetaRobotsTagHelper : SeoTagHelperBase
    {
        public MetaRobotsTagHelper(ISeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public bool? Follow { get; set; }

        public bool? Index { get; set; }

        public string Value { get; set; }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            if (Follow != null || Index != null)
            {
                SeoHelper.SetMetaRobots(Index ?? true, Follow ?? true);
            }

            var content = TagValueUtility.GetContent(
                Value,
                SeoHelper.MetaRobots);

            output.ProcessMeta(MetaName.Robots, content);
        }
    }
}
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoMetaRobotsIndexTagHelper : SeoTagHelperBase
    {
        internal const string NoIndexAttributeName = "no-index";

        internal const string TagName = "seo-meta-robots-index";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(NoIndexAttributeName)]
        public bool NoIndex { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public RobotsIndex? Value { get; set; }

        public SeoMetaRobotsIndexTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var metaRobotsIndex = Value ?? SeoHelper.MetaRobotsIndex;

            metaRobotsIndex = NoIndex ? RobotsIndexManager.DefaultRobotsNoIndex : metaRobotsIndex;

            if (metaRobotsIndex == null)
            {
                output.SuppressOutput();
                return;
            }

            string content = RobotsIndexManager.GetMetaContent(metaRobotsIndex.Value);

            output.Attributes.RemoveAll(nameof(Value));
            output.Attributes.RemoveAll(nameof(NoIndex));

            SetMetaTagOutput(output, name: "robots", content: content);
        }
    }
}
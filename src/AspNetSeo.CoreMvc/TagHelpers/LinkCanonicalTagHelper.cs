using System;

using AspNetSeo.CoreMvc.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("link-canonical", TagStructure = TagStructure.WithoutEndTag)]
    [OutputElementHint("link")]
    public class LinkCanonicalTagHelper : SeoTagHelperBase
    {
        private readonly ISeoUrlHelper _urlHelper;

        public LinkCanonicalTagHelper(
            ISeoHelper seoHelper,
            ISeoUrlHelper urlHelper)
            : base(seoHelper)
        {
            _urlHelper = urlHelper
                ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public string Value { get; set; }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            var value = TagValueUtility.GetContent(
                Value,
                SeoHelper.LinkCanonical);

            var linkCanonical =
                AbsoluteUrlUtility.Resolve(
                    _urlHelper,
                    value,
                    SeoHelper.SiteUrl);

            if (string.IsNullOrWhiteSpace(linkCanonical))
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "link";
            output.TagMode = TagMode.SelfClosing;

            output.Attributes.Clear();

            output.Attributes.SetAttribute("rel", "canonical");
            output.Attributes.SetAttribute("href", linkCanonical);
        }
    }
}
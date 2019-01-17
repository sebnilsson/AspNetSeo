using System;

using AspNetSeo.CoreMvc.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers
{
    [HtmlTargetElement("og-url", TagStructure = TagStructure.WithoutEndTag)]
    [OutputElementHint("meta")]
    public class OgUrlTagHelper : SeoTagHelperBase
    {
        private readonly IUrlHelper _urlHelper;

        public OgUrlTagHelper(
            ISeoHelper seoHelper,
            IUrlHelper urlHelper)
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
                SeoHelper.OgUrl,
                SeoHelper.LinkCanonical);

            var linkCanonical =
                AbsoluteUrlUtility.Resolve(
                    _urlHelper,
                    value,
                    SeoHelper.SiteUrl);

            output.ProcessMeta(OgMetaName.Url, linkCanonical);
        }
    }
}
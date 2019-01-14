using System;

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    [HtmlTargetElement(TagName, TagStructure = TagStructure.WithoutEndTag)]
    public class SeoLinkCanonicalTagHelper : SeoTagHelperBase
    {
        internal const string BaseAttributeName = "base";

        internal const string TagName = "seo-link-canonical";

        internal const string ValueAttributeName = "value";

        [HtmlAttributeName(BaseAttributeName)]
        public string Base { get; set; }

        [HtmlAttributeName(ValueAttributeName)]
        public string Value { get; set; }
        
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public SeoLinkCanonicalTagHelper(SeoHelper seoHelper)
            : base(seoHelper)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = (ViewContext != null) ? new UrlHelper(ViewContext) : null;
            
            var linkCanonical = !string.IsNullOrWhiteSpace(Value) ? Value : SeoHelper.LinkCanonical;

            linkCanonical = urlHelper?.Content(linkCanonical) ?? linkCanonical;

            var linkCanonicalBase = !string.IsNullOrWhiteSpace(Base) ? Base : SeoHelper.BaseLinkCanonical;

            var requestUrl = ViewContext?.HttpContext?.Request?.GetDisplayUrl() ?? string.Empty;
            var requestUri = new Uri(requestUrl);

            string combinedLinkCanonical = SeoHelperLinkCanonicalHelper.GetLinkCanonical(
                linkCanonical,
                linkCanonicalBase,
                requestUri);

            if (string.IsNullOrWhiteSpace(combinedLinkCanonical))
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "link";

            output.Attributes.RemoveAll(nameof(Base));
            output.Attributes.RemoveAll(nameof(Value));

            output.Attributes.SetAttribute("rel", "canonical");
            output.Attributes.SetAttribute("href", combinedLinkCanonical);
        }
    }
}
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
            var urlHelper = (this.ViewContext != null) ? new UrlHelper(this.ViewContext) : null;
            
            var linkCanonical = !string.IsNullOrWhiteSpace(this.Value) ? this.Value : this.SeoHelper.LinkCanonical;

            linkCanonical = urlHelper?.Content(linkCanonical) ?? linkCanonical;

            var linkCanonicalBase = !string.IsNullOrWhiteSpace(this.Base) ? this.Base : this.SeoHelper.BaseLinkCanonical;

            var requestUrl = this.ViewContext?.HttpContext?.Request?.GetDisplayUrl() ?? string.Empty;
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

            output.Attributes.RemoveAll(nameof(this.Base));
            output.Attributes.RemoveAll(nameof(this.Value));

            output.Attributes.SetAttribute("rel", "canonical");
            output.Attributes.SetAttribute("href", combinedLinkCanonical);
        }
    }
}
using System;

using AspNetSeo.CoreMvc.TestWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc.TestWebApp.Controllers
{
    public class TestsController : SeoController
    {
        public IActionResult Index()
        {
            var model = TestActionsViewModel.Default;

            return this.View("~/Views/Home/Index.cshtml", model);
        }

        [SeoBaseTitle("Override attribute base-title")]
        [SeoBaseLinkCanonical("https://test-url-attribute.co/base-path")]
        [SeoTitle("LinkCanonical")]
        public IActionResult LinkCanonical()
        {
            this.Seo.LinkCanonical = "~/Tests/LinkCanonicalAttribute_FromHelperProperty/?abc=123&param=param";

            return this.View();
        }

        [SeoLinkCanonical("TestsAttribute/LinkCanonicalAttribute_FromAttribute/?abc=123&param=param")]
        [SeoTitle("LinkCanonicalAttribute")]
        public IActionResult LinkCanonicalAttribute()
        {
            return this.View("LinkCanonical");
        }

        [SeoTitle("MetaDescription")]
        public IActionResult MetaDescription()
        {
            this.Seo.MetaDescription = $"Test meta-description{Environment.NewLine}Newline-content";

            return this.View();
        }

        [SeoMetaDescription("Test attribute meta-description\r\nNewline-content")]
        [SeoTitle("MetaDescriptionAttribute")]
        public IActionResult MetaDescriptionAttribute()
        {
            return this.View("MetaDescription");
        }

        [SeoTitle("MetaKeywords")]
        public IActionResult MetaKeywords()
        {
            this.Seo.MetaKeywords = $"Test meta-keywords{Environment.NewLine}Newline-content";

            return this.View();
        }

        [SeoMetaKeywords("Test meta-keywords\r\nNewline-content")]
        [SeoTitle("MetaKeywordsAttribute")]
        public IActionResult MetaKeywordsAttribute()
        {
            return this.View("MetaKeywords");
        }

        [SeoTitle("MetaRobotsIndexAttribute")]
        [SeoMetaRobotsIndex]
        public IActionResult MetaRobotsIndexAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsIndexIndexNoFollow")]
        public IActionResult MetaRobotsIndexIndexNoFollow()
        {
            this.Seo.MetaRobotsIndex = RobotsIndex.IndexNoFollow;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.IndexNoFollow)]
        [SeoTitle("MetaRobotsIndexIndexNoFollowAttribute")]
        public IActionResult MetaRobotsIndexIndexNoFollowAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsIndexNoIndexFollow")]
        public IActionResult MetaRobotsIndexNoIndexFollow()
        {
            this.Seo.MetaRobotsIndex = RobotsIndex.NoIndexFollow;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.NoIndexFollow)]
        [SeoTitle("MetaRobotsIndexNoIndexFollowAttribute")]
        public IActionResult MetaRobotsIndexNoIndexFollowAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsIndexNoIndexNoFollow")]
        public IActionResult MetaRobotsIndexNoIndexNoFollow()
        {
            this.Seo.MetaRobotsIndex = RobotsIndex.NoIndexNoFollow;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.NoIndexNoFollow)]
        [SeoTitle("MetaRobotsIndexNoIndexNoFollowAttribute")]
        public IActionResult MetaRobotsIndexNoIndexNoFollowAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsNoIndex")]
        public IActionResult MetaRobotsNoIndex()
        {
            this.Seo.MetaRobotsNoIndex = true;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsNoIndex]
        [SeoTitle("MetaRobotsNoIndexAttribute")]
        public IActionResult MetaRobotsNoIndexAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("Overridden attribute action-title", OverrideBaseTitle = true)]
        public IActionResult Title()
        {
            this.Seo.Title = "Override action-method-title";
            this.Seo.TitleFormat = "Base: '{1}' | Title: '{0}'";

            return this.View();
        }

        [SeoTitle("Attribute action-title", Format = "Attribute Base: '{1}' | Title: '{0}'")]
        public IActionResult TitleAttribute()
        {
            return this.View("Title");
        }
    }
}
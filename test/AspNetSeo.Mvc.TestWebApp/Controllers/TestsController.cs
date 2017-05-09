using System;
using System.Web.Mvc;

using AspNetSeo.Mvc.TestWebApp.Models;

namespace AspNetSeo.Mvc.TestWebApp.Controllers
{
    [SeoBaseTitle("Controller-title")]
    [SeoBaseLinkCanonical("https://attributebaselinkcanonical.co/base-path")]
    public class TestsController : SeoController
    {
        public ActionResult Index()
        {
            var model = TestActionsViewModel.Default;

            return this.View("~/Views/Home/Index.cshtml", model);
        }

        [SeoTitle("LinkCanonical")]
        public ActionResult LinkCanonical()
        {
            this.Seo.LinkCanonical = "~/Tests/LinkCanonicalAttribute_FromHelperProperty/?abc=123&param=param";

            return this.View();
        }

        [SeoLinkCanonical("TestsAttribute/LinkCanonicalAttribute_FromAttribute/?abc=123&param=param")]
        [SeoTitle("LinkCanonicalAttribute")]
        public ActionResult LinkCanonicalAttribute()
        {
            return this.View("LinkCanonical");
        }

        [SeoTitle("MetaDescription")]
        public ActionResult MetaDescription()
        {
            this.Seo.MetaDescription = $"Test meta-description{Environment.NewLine}Newline-content";

            return this.View();
        }

        [SeoMetaDescription("Test attribute meta-description\r\nNewline-content")]
        [SeoTitle("MetaDescriptionAttribute")]
        public ActionResult MetaDescriptionAttribute()
        {
            return this.View("MetaDescription");
        }

        [SeoTitle("MetaKeywords")]
        public ActionResult MetaKeywords()
        {
            this.Seo.MetaKeywords = $"Test meta-keywords{Environment.NewLine}Newline-content";

            return this.View();
        }

        [SeoMetaKeywords("Test meta-keywords\r\nNewline-content")]
        [SeoTitle("MetaKeywordsAttribute")]
        public ActionResult MetaKeywordsAttribute()
        {
            return this.View("MetaKeywords");
        }

        [SeoTitle("MetaRobotsIndexAttribute")]
        [SeoMetaRobotsIndex]
        public ActionResult MetaRobotsIndexAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsIndexIndexNoFollow")]
        public ActionResult MetaRobotsIndexIndexNoFollow()
        {
            this.Seo.MetaRobotsIndex = RobotsIndex.IndexNoFollow;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.IndexNoFollow)]
        [SeoTitle("MetaRobotsIndexIndexNoFollowAttribute")]
        public ActionResult MetaRobotsIndexIndexNoFollowAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsIndexNoIndexFollow")]
        public ActionResult MetaRobotsIndexNoIndexFollow()
        {
            this.Seo.MetaRobotsIndex = RobotsIndex.NoIndexFollow;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.NoIndexFollow)]
        [SeoTitle("MetaRobotsIndexNoIndexFollowAttribute")]
        public ActionResult MetaRobotsIndexNoIndexFollowAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsIndexNoIndexNoFollow")]
        public ActionResult MetaRobotsIndexNoIndexNoFollow()
        {
            this.Seo.MetaRobotsIndex = RobotsIndex.NoIndexNoFollow;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.NoIndexNoFollow)]
        [SeoTitle("MetaRobotsIndexNoIndexNoFollowAttribute")]
        public ActionResult MetaRobotsIndexNoIndexNoFollowAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsNoIndex")]
        public ActionResult MetaRobotsNoIndex()
        {
            this.Seo.MetaRobotsNoIndex = true;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsNoIndex]
        [SeoTitle("MetaRobotsNoIndexAttribute")]
        public ActionResult MetaRobotsNoIndexAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoTitle("Overridden attribute action-title", OverrideBaseTitle = true)]
        public ActionResult Title()
        {
            this.Seo.Title = "Override action-method-title";
            this.Seo.TitleFormat = "Base: '{1}' | Title: '{0}'";

            return this.View();
        }

        [SeoTitle("Attribute action-title", Format = "Attribute Base: '{1}' | Title: '{0}'")]
        public ActionResult TitleAttribute()
        {
            return this.View("Title");
        }
    }
}
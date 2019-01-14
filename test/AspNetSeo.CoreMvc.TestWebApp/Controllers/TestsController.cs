using System;

using AspNetSeo.CoreMvc.TestWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc.TestWebApp.Controllers
{
    [SeoOgSiteName("Class-level OG Site Name")]
    public class TestsController : SeoController
    {
        public IActionResult Index()
        {
            var model = TestActionsViewModel.Default;

            return View("~/Views/Home/Index.cshtml", model);
        }

        [SeoBaseTitle("Override attribute base-title")]
        [SeoBaseLinkCanonical("https://test-url-attribute.co/base-path")]
        [SeoTitle("LinkCanonical")]
        public IActionResult LinkCanonical()
        {
            Seo.LinkCanonical = "~/Tests/LinkCanonicalAttribute_FromHelperProperty/?abc=123&param=param";

            return View();
        }

        [SeoLinkCanonical("TestsAttribute/LinkCanonicalAttribute_FromAttribute/?abc=123&param=param")]
        [SeoTitle("LinkCanonicalAttribute")]
        public IActionResult LinkCanonicalAttribute()
        {
            return View("LinkCanonical");
        }

        [SeoTitle("MetaDescription")]
        public IActionResult MetaDescription()
        {
            Seo.MetaDescription = $"Test meta-description{Environment.NewLine}Newline-content";

            return View();
        }

        [SeoMetaDescription("Test attribute meta-description\r\nNewline-content")]
        [SeoTitle("MetaDescriptionAttribute")]
        public IActionResult MetaDescriptionAttribute()
        {
            return View("MetaDescription");
        }

        [SeoTitle("MetaKeywords")]
        public IActionResult MetaKeywords()
        {
            Seo.MetaKeywords = $"Test meta-keywords{Environment.NewLine}Newline-content";

            return View();
        }

        [SeoMetaKeywords("Test meta-keywords\r\nNewline-content")]
        [SeoTitle("MetaKeywordsAttribute")]
        public IActionResult MetaKeywordsAttribute()
        {
            return View("MetaKeywords");
        }

        [SeoTitle("MetaRobotsIndexAttribute")]
        [SeoMetaRobotsIndex]
        public IActionResult MetaRobotsIndexAttribute()
        {
            return View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsIndexIndexNoFollow")]
        public IActionResult MetaRobotsIndexIndexNoFollow()
        {
            Seo.MetaRobotsIndex = RobotsIndex.IndexNoFollow;

            return View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.IndexNoFollow)]
        [SeoTitle("MetaRobotsIndexIndexNoFollowAttribute")]
        public IActionResult MetaRobotsIndexIndexNoFollowAttribute()
        {
            return View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsIndexNoIndexFollow")]
        public IActionResult MetaRobotsIndexNoIndexFollow()
        {
            Seo.MetaRobotsIndex = RobotsIndex.NoIndexFollow;

            return View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.NoIndexFollow)]
        [SeoTitle("MetaRobotsIndexNoIndexFollowAttribute")]
        public IActionResult MetaRobotsIndexNoIndexFollowAttribute()
        {
            return View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsIndexNoIndexNoFollow")]
        public IActionResult MetaRobotsIndexNoIndexNoFollow()
        {
            Seo.MetaRobotsIndex = RobotsIndex.NoIndexNoFollow;

            return View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.NoIndexNoFollow)]
        [SeoTitle("MetaRobotsIndexNoIndexNoFollowAttribute")]
        public IActionResult MetaRobotsIndexNoIndexNoFollowAttribute()
        {
            return View("MetaRobotsIndex");
        }

        [SeoTitle("MetaRobotsNoIndex")]
        public IActionResult MetaRobotsNoIndex()
        {
            Seo.MetaRobotsNoIndex = true;

            return View("MetaRobotsIndex");
        }

        [SeoMetaRobotsNoIndex]
        [SeoTitle("MetaRobotsNoIndexAttribute")]
        public IActionResult MetaRobotsNoIndexAttribute()
        {
            return View("MetaRobotsIndex");
        }
        
        [SeoOgDescription("OgDesciptionAttribute")]
        public IActionResult OgDescription()
        {
            return View();
        }

        [SeoOgImage("OgImage")]
        public IActionResult OgImage()
        {
            return View();
        }

        [SeoOgSiteName("OgSiteName action override")]
        public IActionResult OgSiteName()
        {
            return View();
        }

        [SeoOgTitle("OgTitle")]
        public IActionResult OgTitle()
        {
            return View();
        }

        [SeoOgType("OgType")]
        public IActionResult OgType()
        {
            return View();
        }

        [SeoOgUrl("OgUrl")]
        public IActionResult OgUrl()
        {
            return View();
        }

        [SeoTitle("Overridden attribute action-title", OverrideBaseTitle = true)]
        public IActionResult Title()
        {
            Seo.Title = "Override action-method-title";
            Seo.TitleFormat = "Base: '{1}' | Title: '{0}'";

            return View();
        }

        [SeoTitle("Attribute action-title", Format = "Attribute Base: '{1}' | Title: '{0}'")]
        public IActionResult TitleAttribute()
        {
            return View("Title");
        }
    }
}
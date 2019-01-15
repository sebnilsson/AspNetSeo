using System;

using AspNetSeo.CoreMvc.TestWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc.TestWebApp.Controllers
{
    [SiteName("Class-level Site Name")]
    [OgSiteName("Class-level OG Site Name")]
    public class TestsController : SeoController
    {
        public IActionResult Index()
        {
            var model = TestActionsViewModel.Default;

            return View("~/Views/Home/Index.cshtml", model);
        }

        [SiteName("Override attribute site name")]
        [LinkCanonical("https://test-url-attribute.co/base-path")]
        [PageTitle("LinkCanonical")]
        public IActionResult LinkCanonical()
        {
            Seo.LinkCanonical = "~/Tests/LinkCanonicalAttribute_FromHelperProperty/?abc=123&param=param";

            return View();
        }

        [LinkCanonical("TestsAttribute/LinkCanonicalAttribute_FromAttribute/?abc=123&param=param")]
        [PageTitle("LinkCanonicalAttribute")]
        public IActionResult LinkCanonicalAttribute()
        {
            return View("LinkCanonical");
        }

        [PageTitle("MetaDescription")]
        public IActionResult MetaDescription()
        {
            Seo.MetaDescription = $"Test meta-description{Environment.NewLine}Newline-content";

            return View();
        }

        [MetaDescription("Test attribute meta-description\r\nNewline-content")]
        [PageTitle("MetaDescriptionAttribute")]
        public IActionResult MetaDescriptionAttribute()
        {
            return View("MetaDescription");
        }

        [PageTitle("MetaKeywords")]
        public IActionResult MetaKeywords()
        {
            Seo.MetaKeywords = $"Test meta-keywords{Environment.NewLine}Newline-content";

            return View();
        }

        [MetaKeywords("Test meta-keywords\r\nNewline-content")]
        [PageTitle("MetaKeywordsAttribute")]
        public IActionResult MetaKeywordsAttribute()
        {
            return View("MetaKeywords");
        }

        [PageTitle("MetaRobotsIndexAttribute")]
        [MetaRobots(index: true, follow: true)]
        public IActionResult MetaRobotsIndexAttribute()
        {
            return View("MetaRobotsIndex");
        }

        [PageTitle("MetaRobotsIndexIndexNoFollow")]
        public IActionResult MetaRobotsIndexIndexNoFollow()
        {
            Seo.SetMetaRobots(index: true, follow: false);

            return View("MetaRobotsIndex");
        }

        [MetaRobots(index: true, follow: false)]
        [PageTitle("MetaRobotsIndexIndexNoFollowAttribute")]
        public IActionResult MetaRobotsIndexIndexNoFollowAttribute()
        {
            return View("MetaRobotsIndex");
        }

        [PageTitle("MetaRobotsIndexNoIndexFollow")]
        public IActionResult MetaRobotsIndexNoIndexFollow()
        {
            Seo.SetMetaRobots(index: false, follow: true);

            return View("MetaRobotsIndex");
        }

        [MetaRobots(index: false, follow: true)]
        [PageTitle("MetaRobotsIndexNoIndexFollowAttribute")]
        public IActionResult MetaRobotsIndexNoIndexFollowAttribute()
        {
            return View("MetaRobotsIndex");
        }

        [PageTitle("MetaRobotsIndexNoIndexNoFollow")]
        public IActionResult MetaRobotsIndexNoIndexNoFollow()
        {
            Seo.SetMetaRobots(index: false, follow: false);

            return View("MetaRobotsIndex");
        }

        [MetaRobots(index: false, follow: false)]
        [PageTitle("MetaRobotsIndexNoIndexNoFollowAttribute")]
        public IActionResult MetaRobotsIndexNoIndexNoFollowAttribute()
        {
            return View("MetaRobotsIndex");
        }
                
        [OgDescription("OgDesciptionAttribute")]
        public IActionResult OgDescription()
        {
            return View();
        }

        [OgImage("OgImage")]
        public IActionResult OgImage()
        {
            return View();
        }

        [OgSiteName("OgSiteName action override")]
        public IActionResult OgSiteName()
        {
            return View();
        }

        [OgTitle("OgTitle")]
        public IActionResult OgTitle()
        {
            return View();
        }

        [OgType("OgType")]
        public IActionResult OgType()
        {
            return View();
        }

        [OgUrl("OgUrl")]
        public IActionResult OgUrl()
        {
            return View();
        }

        [PageTitle("Overridden attribute action-title", OverrideSiteName = true)]
        public IActionResult Title()
        {
            Seo.PageTitle = "Override action-method-title";
            Seo.DocumentTitleFormat = "Base: '{1}' | Title: '{0}'";

            return View();
        }

        [PageTitle("Attribute action-title", Format = "Attribute Base: '{1}' | Title: '{0}'")]
        public IActionResult TitleAttribute()
        {
            return View("Title");
        }
    }
}
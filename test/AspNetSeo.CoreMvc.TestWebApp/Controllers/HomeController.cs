using AspNetSeo.CoreMvc.TestWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc.TestWebApp.Controllers
{
    [SiteName("Controller Attribute SiteName")]
    [OgSiteName("Controller Attribute OgSiteName")]
    public class HomeController : SeoController
    {
        public IActionResult Index()
        {
            return HomeView();
        }

        [LinkCanonical("https://t.co/controller-action-attribute-linkcanonical")]
        public IActionResult LinkCanonicalAttribute()
        {
            return HomeView();
        }

        public IActionResult LinkCanonical()
        {
            Seo.LinkCanonical = "https://t.co/seohelper-linkcanonical";
            return HomeView();
        }

        [MetaDescription("Action Attribute MetaDescription")]
        public IActionResult MetaDescriptionAttribute()
        {
            return HomeView();
        }

        public IActionResult MetaDescription()
        {
            Seo.MetaDescription = "SeoHelper MetaDescription";
            return HomeView();
        }

        [SiteName("Action Attribute SiteName")]
        public IActionResult SiteNameAttribute()
        {
            return HomeView();
        }

        public IActionResult SiteName()
        {
            Seo.SiteName = "SeoHelper SiteName";
            return HomeView();
        }

        private IActionResult HomeView()
        {
            var model = HomeViewModel.Default;

            return View("Index", model);
        }
    }
}
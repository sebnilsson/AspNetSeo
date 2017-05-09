using System.Web.Mvc;

using AspNetSeo.Mvc.TestWebApp.Models;

namespace AspNetSeo.Mvc.TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = TestActionsViewModel.Default;

            return this.View(model);
        }
    }
}
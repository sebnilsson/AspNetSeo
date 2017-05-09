using AspNetSeo.CoreMvc.TestWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc.TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = TestActionsViewModel.Default;

            return this.View(model);
        }
    }
}
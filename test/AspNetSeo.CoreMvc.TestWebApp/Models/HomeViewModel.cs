using AspNetSeo.CoreMvc.TestWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc.TestWebApp.Models;

public class HomeViewModel
{
    private static readonly Lazy<HomeViewModel> s_defaultLazy = new(GetDefault);

    public static HomeViewModel Default => s_defaultLazy.Value;

    public IReadOnlyList<string> ActionNames { get; private set; } = [];

    private static HomeViewModel GetDefault()
    {
        var model = new HomeViewModel { ActionNames = GetActionNames() };

        return model;
    }

    private static List<string> GetActionNames()
    {
        var controllerType = typeof(HomeController);

        var properties = controllerType.GetMethods().Where(x => x.ReturnType == typeof(IActionResult));

        return properties.Select(x => x.Name).OrderBy(x => x).ToList();
    }
}

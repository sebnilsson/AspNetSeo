using System;
using System.Collections.Generic;
using System.Linq;

using AspNetSeo.CoreMvc.TestWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc.TestWebApp.Models
{
    public class HomeViewModel
    {
        private static readonly Lazy<HomeViewModel> DefaultLazy = new Lazy<HomeViewModel>(GetDefault);

        public static HomeViewModel Default => DefaultLazy.Value;

        public IReadOnlyCollection<string> ActionNames { get; private set; }

        private static HomeViewModel GetDefault()
        {
            var model = new HomeViewModel { ActionNames = GetActionNames().ToList() };

            return model;
        }

        private static IEnumerable<string> GetActionNames()
        {
            var controllerType = typeof(HomeController);

            var properties = controllerType.GetMethods().Where(x => x.ReturnType == typeof(IActionResult));

            var propertyNames = properties.Select(x => x.Name).OrderBy(x => x).ToList();
            return propertyNames;
        }
    }
}
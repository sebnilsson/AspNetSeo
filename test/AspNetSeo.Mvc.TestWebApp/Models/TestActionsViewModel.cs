using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AspNetSeo.Mvc.TestWebApp.Controllers;

namespace AspNetSeo.Mvc.TestWebApp.Models
{
    public class TestActionsViewModel
    {
        private static readonly Lazy<TestActionsViewModel> DefaultLazy = new Lazy<TestActionsViewModel>(GetDefault);

        public static TestActionsViewModel Default => DefaultLazy.Value;

        public IReadOnlyCollection<string> ActionNames { get; private set; }

        private static TestActionsViewModel GetDefault()
        {
            var model = new TestActionsViewModel { ActionNames = GetActionNames().ToList() };

            return model;
        }

        private static IEnumerable<string> GetActionNames()
        {
            var controllerType = typeof(TestsController);

            var properties = controllerType.GetMethods().Where(x => x.ReturnType == typeof(ActionResult));

            var propertyNames = properties.Select(x => x.Name).OrderBy(x => x).ToList();
            return propertyNames;
        }
    }
}
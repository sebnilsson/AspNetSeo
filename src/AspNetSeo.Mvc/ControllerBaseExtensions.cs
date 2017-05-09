using System;
using System.Web.Mvc;

namespace AspNetSeo.Mvc
{
    public static class ControllerBaseExtensions
    {
        public static SeoHelper GetSeoHelper(this ControllerBase controller)
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            var seoHelper = controller.ControllerContext?.Controller?.ViewData?.GetSeoHelper();
            return seoHelper;
        }
    }
}
using System;
using System.Web.Mvc;

namespace AspNetSeo.Mvc
{
    public static class ViewDataContainerExtensions
    {
        public static SeoHelper GetSeoHelper(this IViewDataContainer viewDataContainer)
        {
            if (viewDataContainer == null)
            {
                throw new ArgumentNullException(nameof(viewDataContainer));
            }

            var seoHelper = viewDataContainer.ViewData?.GetSeoHelper();
            return seoHelper;
        }
    }
}
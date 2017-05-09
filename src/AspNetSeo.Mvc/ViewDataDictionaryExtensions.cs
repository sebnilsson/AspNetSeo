using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNetSeo.Mvc
{
    internal static class ViewDataDictionaryExtensions
    {
        public static SeoHelper GetSeoHelper(this ViewDataDictionary viewData)
        {
            if (viewData == null)
            {
                throw new ArgumentNullException(nameof(viewData));
            }

            var seoHelper = ((IDictionary<string, object>)viewData).GetSeoHelper();
            return seoHelper;
        }
    }
}
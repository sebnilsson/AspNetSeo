using System;
using System.Collections;
using System.Collections.Generic;

namespace AspNetSeo
{
    public static class DictionaryExtensions
    {
        internal static readonly string DictionaryKey = "AspNetSeo.SeoHelper";

        internal static SeoHelper GetSeoHelper(this IDictionary<string, object> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            var seoHelperData = dictionary[DictionaryKey] as SeoHelper;

            if (seoHelperData == null)
            {
                lock (dictionary)
                {
                    seoHelperData = dictionary[DictionaryKey] as SeoHelper;

                    if (seoHelperData == null)
                    {
                        seoHelperData = new SeoHelper();

                        dictionary[DictionaryKey] = seoHelperData;
                    }
                }
            }

            return seoHelperData;
        }

        internal static T TryGet<T>(this IDictionary dictionary, object key)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!dictionary.Contains(key))
            {
                return default(T);
            }

            var item = dictionary[key];
            return (item is T) ? (T)item : default(T);
        }
    }
}
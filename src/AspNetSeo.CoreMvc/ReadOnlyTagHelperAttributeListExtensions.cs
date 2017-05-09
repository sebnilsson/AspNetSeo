using System;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc
{
    public static class ReadOnlyTagHelperAttributeListExtensions
    {
        public static object TryGet(this ReadOnlyTagHelperAttributeList attributeList, string name)
        {
            if (attributeList == null)
            {
                throw new ArgumentNullException(nameof(attributeList));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            TagHelperAttribute attribute;
            if (!attributeList.TryGetAttribute(name, out attribute))
            {
                return null;
            }

            return attribute.Value;
        }
    }
}
﻿using AspNetSeo.CoreMvc.Internal;
using AspNetSeo.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

[HtmlTargetElement("meta-keywords", TagStructure = TagStructure.WithoutEndTag)]
[OutputElementHint("meta")]
public class MetaKeywordsTagHelper(ISeoHelper seoHelper) : SeoTagHelperBase(seoHelper)
{
    public string? Value { get; set; }

    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        var content = TagValueUtility.GetContent(
            Value,
            SeoHelper.MetaKeywords);

        output.ProcessMeta(MetaName.Keywords, content);
    }
}

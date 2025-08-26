using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

public class OgLocaleAlternateTagHelperTest : TagHelperTestBase
{
    [Theory]
    [MemberData(nameof(GetMemberData))]
    public void Process_TestData_ReturnsExpectedHtml(
        string expected,
        TagHelper tagHelper)
    {
        var html = tagHelper.GetHtml("og-locale-alternate");
        Assert.Equal(expected, html);
    }

    public static TheoryData<string, TagHelper> GetMemberData()
    {
        var data = new TheoryData<string, TagHelper>
        {
            {
                OpenGraphTag(OgMetaName.LocaleAlternate, "da_DK", reverseAttributes: true)
                    + Environment.NewLine
                    + OpenGraphTag(OgMetaName.LocaleAlternate, "en_US", reverseAttributes: true),
                TagHelperTestFactory.Create(
                    seo => new OgLocaleAlternateTagHelper(seo),
                    seo => { seo.OgLocaleAlternates = new[] { "da_DK", "en_US" }; })
            },
            {
                OpenGraphTag(OgMetaName.LocaleAlternate, "de_DE", reverseAttributes: true),
                TagHelperTestFactory.Create(
                    seo => new OgLocaleAlternateTagHelper(seo),
                    seo => { seo.OgLocaleAlternates = new[] { "da_DK" }; },
                    tag => tag.Value = "de_DE")
            },
            {
                string.Empty,
                TagHelperTestFactory.Create(
                    seo => new OgLocaleAlternateTagHelper(seo))
            }
        };

        return data;
    }
}

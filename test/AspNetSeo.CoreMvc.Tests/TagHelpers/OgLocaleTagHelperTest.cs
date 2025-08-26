using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

public class OgLocaleTagHelperTest : TagHelperTestBase
{
    [Theory]
    [MemberData(nameof(GetMemberData))]
    public void Process_TestData_ReturnsExpectedHtml(
        string expected,
        TagHelper tagHelper)
    {
        var html = tagHelper.GetHtml("og-locale");
        Assert.Equal(expected, html);
    }

    public static TheoryData<string, TagHelper> GetMemberData => new()
    {
        {
            OpenGraphTag(OgMetaName.Locale, "da_DK"),
            TagHelperTestFactory.Create(
                seo => new OgLocaleTagHelper(seo),
                seo => seo.OgLocale = "da_DK")
        },
        {
            OpenGraphTag(OgMetaName.Locale, "en_US"),
            TagHelperTestFactory.Create(
                seo => new OgLocaleTagHelper(seo),
                seo => seo.OgLocale = "da_DK",
                tag => tag.Value = "en_US")
        },
        {
            string.Empty,
            TagHelperTestFactory.Create(
                seo => new OgLocaleTagHelper(seo))
        }
    };
}

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

    public static IEnumerable<object[]> GetMemberData()
    {
        yield return new object[]
        {
            OpenGraphTag(OgMetaName.Locale, "da_DK"),
            TagHelperTestFactory.Create(
                seo => new OgLocaleTagHelper(seo),
                seo => seo.OgLocale = "da_DK")
        };

        yield return new object[]
        {
            OpenGraphTag(OgMetaName.Locale, "en_US"),
            TagHelperTestFactory.Create(
                seo => new OgLocaleTagHelper(seo),
                seo => seo.OgLocale = "da_DK",
                tag => tag.Value = "en_US")
        };

        yield return new object[]
        {
            string.Empty,
            TagHelperTestFactory.Create(
                seo => new OgLocaleTagHelper(seo))
        };
    }
}

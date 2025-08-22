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

    public static IEnumerable<object[]> GetMemberData()
    {
        yield return new object[]
        {
            OpenGraphTag(OgMetaName.LocaleAlternate, "da_DK") + Environment.NewLine +
            OpenGraphTag(OgMetaName.LocaleAlternate, "en_US"),
            TagHelperTestFactory.Create(
                seo => new OgLocaleAlternateTagHelper(seo),
                seo => { seo.OgLocaleAlternates.Add("da_DK"); seo.OgLocaleAlternates.Add("en_US"); })
        };

        yield return new object[]
        {
            OpenGraphTag(OgMetaName.LocaleAlternate, "de_DE"),
            TagHelperTestFactory.Create(
                seo => new OgLocaleAlternateTagHelper(seo),
                seo => { seo.OgLocaleAlternates.Add("da_DK"); },
                tag => tag.Value = "de_DE")
        };

        yield return new object[]
        {
            string.Empty,
            TagHelperTestFactory.Create(
                seo => new OgLocaleAlternateTagHelper(seo))
        };
    }
}

using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

public class OgDeterminerTagHelperTest : TagHelperTestBase
{
    [Theory]
    [MemberData(nameof(GetMemberData))]
    public void Process_TestData_ReturnsExpectedHtml(
        string expected,
        TagHelper tagHelper)
    {
        var html = tagHelper.GetHtml("og-determiner");
        Assert.Equal(expected, html);
    }

    public static IEnumerable<object[]> GetMemberData()
    {
        yield return new object[]
        {
            OpenGraphTag(OgMetaName.Determiner, "the"),
            TagHelperTestFactory.Create(
                seo => new OgDeterminerTagHelper(seo),
                seo => seo.OgDeterminer = "the")
        };

        yield return new object[]
        {
            OpenGraphTag(OgMetaName.Determiner, "a"),
            TagHelperTestFactory.Create(
                seo => new OgDeterminerTagHelper(seo),
                seo => seo.OgDeterminer = "the",
                tag => tag.Value = "a")
        };

        yield return new object[]
        {
            string.Empty,
            TagHelperTestFactory.Create(
                seo => new OgDeterminerTagHelper(seo))
        };
    }
}

using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

public class OgVideoTagHelperTest : TagHelperTestBase
{
    [Theory]
    [MemberData(nameof(GetMemberData))]
    public void Process_TestData_ReturnsExpectedHtml(
        string expected,
        TagHelper tagHelper)
    {
        var html = tagHelper.GetHtml("og-video");
        Assert.Equal(expected, html);
    }

    public static IEnumerable<object[]> GetMemberData()
    {
        yield return new object[]
        {
            OpenGraphTag(OgMetaName.Video, "TEST_OG_VIDEO"),
            TagHelperTestFactory.Create(
                seo => new OgVideoTagHelper(seo),
                seo => seo.OgVideo = "TEST_OG_VIDEO")
        };

        yield return new object[]
        {
            OpenGraphTag(OgMetaName.Video, "OVERRIDE_VIDEO"),
            TagHelperTestFactory.Create(
                seo => new OgVideoTagHelper(seo),
                seo => seo.OgVideo = "TEST_OG_VIDEO",
                tag => tag.Value = "OVERRIDE_VIDEO")
        };

        yield return new object[]
        {
            string.Empty,
            TagHelperTestFactory.Create(
                seo => new OgVideoTagHelper(seo))
        };
    }
}

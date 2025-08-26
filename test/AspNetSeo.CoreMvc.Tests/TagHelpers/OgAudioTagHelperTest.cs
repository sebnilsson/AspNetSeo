using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

public class OgAudioTagHelperTest : TagHelperTestBase
{
    [Theory]
    [MemberData(nameof(GetMemberData))]
    public void Process_TestData_ReturnsExpectedHtml(
        string expected,
        TagHelper tagHelper)
    {
        var html = tagHelper.GetHtml("og-audio");
        Assert.Equal(expected, html);
    }

    public static TheoryData<string, TagHelper> GetMemberData => new()
    {
        {
            OpenGraphTag(OgMetaName.Audio, "TEST_OG_AUDIO"),
            TagHelperTestFactory.Create(
                seo => new OgAudioTagHelper(seo),
                seo => seo.OgAudio = "TEST_OG_AUDIO")
        },
        {
            OpenGraphTag(OgMetaName.Audio, "OVERRIDE_AUDIO"),
            TagHelperTestFactory.Create(
                seo => new OgAudioTagHelper(seo),
                seo => seo.OgAudio = "TEST_OG_AUDIO",
                tag => tag.Value = "OVERRIDE_AUDIO")
        },
        {
            string.Empty,
            TagHelperTestFactory.Create(
                seo => new OgAudioTagHelper(seo))
        }
    };
}

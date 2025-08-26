using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

public class MetaRobotsTagHelperTest : TagHelperTestBase
{
    [Theory]
    [MemberData(nameof(GetMemberData))]
    public void Process_TestData_ReturnsExpectedHtml(
        string expected,
        TagHelper tagHelper)
    {
        // Act
        var html = tagHelper.GetHtml("meta-robots");

        // Assert
        Assert.Equal(expected, html);
    }

    public static TheoryData<string, TagHelper> GetMemberData => new()
    {
        {
            MetaTag(MetaName.Robots, "TEST_ROBOTS", reverseAttributes: true),
            TagHelperTestFactory.Create(
                seo => new MetaRobotsTagHelper(seo),
                seo => seo.MetaRobots = "TEST_ROBOTS")
        },
        {
            MetaTag(MetaName.Robots, $"{MetaRobotsValue.Index}, {MetaRobotsValue.Follow}", reverseAttributes: true),
            TagHelperTestFactory.Create(
                seo => new MetaRobotsTagHelper(seo),
                seo => seo.SetMetaRobots(index: true, follow: true))
        },
        {
            MetaTag(MetaName.Robots, $"{MetaRobotsValue.Index}, {MetaRobotsValue.NoFollow}", reverseAttributes: true),
            TagHelperTestFactory.Create(
                seo => new MetaRobotsTagHelper(seo),
                seo => seo.SetMetaRobots(index: true, follow: false))
        },
        {
            MetaTag(MetaName.Robots, $"{MetaRobotsValue.NoIndex}, {MetaRobotsValue.Follow}", reverseAttributes: true),
            TagHelperTestFactory.Create(
                seo => new MetaRobotsTagHelper(seo),
                seo => seo.SetMetaRobots(index: false, follow: true))
        },
        {
            MetaTag(MetaName.Robots, $"{MetaRobotsValue.NoIndex}, {MetaRobotsValue.NoFollow}", reverseAttributes: true),
            TagHelperTestFactory.Create(
                seo => new MetaRobotsTagHelper(seo),
                seo => seo.SetMetaRobots(index: false, follow: false))
        }
    };
}

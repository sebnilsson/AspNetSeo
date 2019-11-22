using System.Collections.Generic;

using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers
{
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

        public static IEnumerable<object[]> GetMemberData()
        {
            yield return new object[]
            {
                MetaTag(MetaName.Robots, "TEST_ROBOTS"),
                TagHelperTestFactory.Create(
                    seo => new MetaRobotsTagHelper(seo),
                    seo => seo.MetaRobots = "TEST_ROBOTS")
            };

            yield return new object[]
            {
                MetaTag(MetaName.Robots, "INDEX, FOLLOW"),
                TagHelperTestFactory.Create(
                    seo => new MetaRobotsTagHelper(seo),
                    seo => seo.SetMetaRobots(index: true, follow: true))
            };

            yield return new object[]
            {
                MetaTag(MetaName.Robots, "INDEX, NOFOLLOW"),
                TagHelperTestFactory.Create(
                    seo => new MetaRobotsTagHelper(seo),
                    seo => seo.SetMetaRobots(index: true, follow: false))
            };

            yield return new object[]
            {
                MetaTag(MetaName.Robots, "NOINDEX, FOLLOW"),
                TagHelperTestFactory.Create(
                    seo => new MetaRobotsTagHelper(seo),
                    seo => seo.SetMetaRobots(index: false, follow: true))
            };

            yield return new object[]
            {
                MetaTag(MetaName.Robots, "NOINDEX, NOFOLLOW"),
                TagHelperTestFactory.Create(
                    seo => new MetaRobotsTagHelper(seo),
                    seo => seo.SetMetaRobots(index: false, follow: false))
            };
        }
    }
}

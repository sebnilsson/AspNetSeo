using System;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoMetaRobotsIndexTagHelperTest
    {
        [Fact]
        public void Process_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var tag = GetSeoMetaRobotsIndexTagHelper();

            // Act
            var output = tag.Process(SeoMetaRobotsIndexTagHelper.TagName);

            // Assert
            var html = output.GetContent();
            bool htmlIsNullOrEmpty = string.IsNullOrWhiteSpace(html);

            Assert.True(htmlIsNullOrEmpty);
        }

        [Fact]
        public void Process_EmptyArgumentWithMetaRobotsNoIndexInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var tag = GetSeoMetaRobotsIndexTagHelper(seoHelper => seoHelper.MetaRobotsNoIndex = true);

            // Act
            var output = tag.Process(SeoMetaRobotsIndexTagHelper.TagName);

            // Assert
            var html = output.GetContent();
            bool htmlContainsRobots = html.Contains("robots");
            var defaultRobotsNoIndex = RobotsIndexManager.GetMetaContent(RobotsIndexManager.DefaultRobotsNoIndex);
            bool htmlContainsMetaContent = html.Contains(defaultRobotsNoIndex);

            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsMetaContent);
        }

        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow, RobotsIndexManager.IndexNoFollowMetaContent)]
        [InlineData(RobotsIndex.NoIndexFollow, RobotsIndexManager.NoIndexFollowMetaContent)]
        [InlineData(RobotsIndex.NoIndexNoFollow, RobotsIndexManager.NoIndexNoFollowMetaContent)]
        public void Process_WithArgument_ReturnsHtmlContainingValue(RobotsIndex robotsIndex, string expectedContent)
        {
            // Arrange
            var tag = GetSeoMetaRobotsIndexTagHelper();
            tag.Value = robotsIndex;

            var attributes = new[] { new TagHelperAttribute(nameof(tag.Value), robotsIndex) };

            // Act
            var output = tag.Process(SeoMetaRobotsIndexTagHelper.TagName, attributes);

            // Assert
            var html = output.GetContent();
            bool htmlContainsRobots = html.Contains("robots");
            var metaContent = RobotsIndexManager.GetMetaContent(robotsIndex);
            bool htmlContainsMetaContent = html.Contains(metaContent);
            bool htmlContainsExpectedContent = html.Contains(expectedContent);

            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsMetaContent);
            Assert.True(htmlContainsExpectedContent);
        }

        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow, RobotsIndexManager.IndexNoFollowMetaContent)]
        [InlineData(RobotsIndex.NoIndexFollow, RobotsIndexManager.NoIndexFollowMetaContent)]
        [InlineData(RobotsIndex.NoIndexNoFollow, RobotsIndexManager.NoIndexNoFollowMetaContent)]
        public void Process_EmptyArgumentWithValuesInSeoHelper_ReturnsHtmlContainingValue(
            RobotsIndex robotsIndex,
            string expectedContent)
        {
            // Arrange
            var tag = GetSeoMetaRobotsIndexTagHelper(seoHelper => seoHelper.MetaRobotsIndex = robotsIndex);

            // Act
            var output = tag.Process(SeoMetaRobotsIndexTagHelper.TagName);

            // Assert
            var html = output.GetContent();
            bool htmlContainsRobots = html.Contains("robots");
            var metaContent = RobotsIndexManager.GetMetaContent(robotsIndex);
            bool htmlContainsMetaContent = html.Contains(metaContent);
            bool htmlContainsExpectedContent = html.Contains(expectedContent);

            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsMetaContent);
            Assert.True(htmlContainsExpectedContent);
        }

        private static SeoMetaRobotsIndexTagHelper GetSeoMetaRobotsIndexTagHelper(
            Action<SeoHelper> seoHelperConfig = null)
        {
            var seoHelper = SeoHelperTestFactory.Create();

            seoHelperConfig?.Invoke(seoHelper);

            var tag = new SeoMetaRobotsIndexTagHelper(seoHelper);
            return tag;
        }
    }
}
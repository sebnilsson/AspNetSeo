using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.Mvc.Tests
{
    public class HtmlHelperSeoMetaRobotsIndexExtensionsTest
    {
        [Fact]
        public void SeoMetaRobotsIndex_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaRobotsIndex();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoMetaRobotsIndex_EmptyArgumentWithMetaRobotsNoIndexInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();
            var seoHelper = SeoHelperTestFactory.Create(htmlHelper.ViewContext);

            seoHelper.MetaRobotsNoIndex = true;

            // Act
            var html = htmlHelper.SeoMetaRobotsIndex();

            // Assert
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
        public void SeoMetaRobotsIndex_WithArgument_ReturnsHtmlContainingValue(
            RobotsIndex robotsIndex,
            string expectedContent)
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaRobotsIndex(robotsIndex);

            // Assert
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
        public void SeoMetaRobotsIndex_EmptyArgumentWithValuesInSeoHelper_ReturnsHtmlContainingValue(
            RobotsIndex robotsIndex,
            string expectedContent)
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();
            var seoHelper = SeoHelperTestFactory.Create(htmlHelper.ViewContext);

            seoHelper.MetaRobotsIndex = robotsIndex;

            // Act
            var html = htmlHelper.SeoMetaRobotsIndex();

            // Assert
            bool htmlContainsRobots = html.Contains("robots");
            var metaContent = RobotsIndexManager.GetMetaContent(robotsIndex);
            bool htmlContainsMetaContent = html.Contains(metaContent);
            bool htmlContainsExpectedContent = html.Contains(expectedContent);

            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsMetaContent);
            Assert.True(htmlContainsExpectedContent);
        }
    }
}
using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.Mvc.Tests
{
    public class HtmlHelperSeoTitleExtensionsTest
    {
        [Fact]
        public void SeoTitle_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoTitle();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoTitle_EmptyArgumentWithPageTitleInSeoHelper_ReturnsNotNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();
            var seoHelper = SeoHelperTestFactory.Create(htmlHelper.ViewContext);

            seoHelper.Title = TestData.Title;

            // Act
            var html = htmlHelper.SeoTitle();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.Title);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoTitle_EmptyArgumentWithBaseTitleInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();
            var seoHelper = SeoHelperTestFactory.Create(htmlHelper.ViewContext);

            seoHelper.BaseTitle = TestData.BaseTitle;

            // Act
            var html = htmlHelper.SeoTitle();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.BaseTitle);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoTitle_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoTitle(TestData.Title);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.Title);

            Assert.True(htmlContainsValue);
        }
    }
}
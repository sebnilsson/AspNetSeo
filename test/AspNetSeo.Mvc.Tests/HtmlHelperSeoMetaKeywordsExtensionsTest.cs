using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.Mvc.Tests
{
    public class HtmlHelperSeoMetaKeywordsExtensionsTest
    {
        [Fact]
        public void SeoMetaKeywords_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaKeywords();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoMetaKeywords_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();
            var seoHelper = SeoHelperTestFactory.Create(htmlHelper.ViewContext);

            seoHelper.MetaKeywords = TestData.MetaKeywords;

            // Act
            var html = htmlHelper.SeoMetaKeywords();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.MetaKeywords);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoMetaKeywords_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaKeywords(TestData.MetaKeywords);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.MetaKeywords);

            Assert.True(htmlContainsValue);
        }
    }
}
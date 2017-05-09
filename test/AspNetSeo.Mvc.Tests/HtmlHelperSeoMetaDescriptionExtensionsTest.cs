using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.Mvc.Tests
{
    public class HtmlHelperSeoMetaDescriptionExtensionsTest
    {
        [Fact]
        public void SeoMetaDescription_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaDescription();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoMetaDescription_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();
            var seoHelper = SeoHelperTestFactory.Create(htmlHelper.ViewContext);

            seoHelper.MetaDescription = TestData.MetaDescription;

            // Act
            var html = htmlHelper.SeoMetaDescription();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.MetaDescription);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoMetaDescription_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaDescription(TestData.MetaDescription);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.MetaDescription);

            Assert.True(htmlContainsValue);
        }
    }
}
using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.Mvc.Tests
{
    public class HtmlHelperSeoLinkCanonicalExtensionsTest
    {
        [Fact]
        public void SeoLinkCanonical_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoLinkCanonical_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();
            var seoHelper = SeoHelperTestFactory.Create(htmlHelper.ViewContext);

            seoHelper.LinkCanonical = $"{TestData.LinkCanonical}";

            // Act
            var html = htmlHelper.SeoLinkCanonical();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.LinkCanonical);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void
            SeoLinkCanonical_EmptyArgumentWithAppRelativeValueInSeoHelper_ReturnsHtmlContainingValueAndIsAbsolute()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();
            var seoHelper = SeoHelperTestFactory.Create(htmlHelper.ViewContext);

            seoHelper.LinkCanonical = TestData.AppRelativeLinkCanonical;

            // Act
            var html = htmlHelper.SeoLinkCanonical();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.LinkCanonical);
            bool htmlContainsDomain = html.Contains(RequestContextTestFactory.Domain);
            bool htmlContainsAppRelativeCharacter = html.Contains("~");

            Assert.True(htmlContainsValue);
            Assert.True(htmlContainsDomain);
            Assert.False(htmlContainsAppRelativeCharacter);
        }

        [Fact]
        public void SeoLinkCanonical_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical(TestData.LinkCanonical);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.LinkCanonical);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoLinkCanonical_WithArgument_ReturnsHtmlContainingAbsoluteUrl()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical(TestData.LinkCanonical);

            // Assert
            bool htmlContainsAbsoluteUrl = html.Contains(RequestContextTestFactory.Domain);

            Assert.True(htmlContainsAbsoluteUrl);
        }

        [Fact]
        public void SeoLinkCanonical_WithLinkCanonicalBase_ReturnsHtmlContainingLinkCanonicalBase()
        {
            const string LinkCanonicalBase = "https://linkcanonical.co/base/";

            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical(TestData.LinkCanonical, linkCanonicalBase: LinkCanonicalBase);

            // Assert
            bool htmlContainsLinkCanonicalBase = html.Contains(LinkCanonicalBase);

            Assert.True(htmlContainsLinkCanonicalBase);
        }

        [Fact]
        public void
            SeoLinkCanonical_WithAppRelativeLinkCanonicalAndLinkCanonicalBase_ReturnsHtmlNotContainingAppRelativeChar()
        {
            const string LinkCanonicalBase = "https://linkcanonical.co/base/";

            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical(
                TestData.AppRelativeLinkCanonical,
                linkCanonicalBase: LinkCanonicalBase);

            // Assert
            bool htmlContainsAppRelativeChar = html.Contains("~");

            Assert.False(htmlContainsAppRelativeChar);
        }
    }
}
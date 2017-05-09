using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoLinkCanonicalAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestLinkCanonical_SetsSeoHelperCanonicalLink()
        {
            // Arrange
            var attribute = new SeoLinkCanonicalAttribute(TestData.LinkCanonical);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.LinkCanonical, seo.LinkCanonical);
        }

        [Fact]
        public void OnHandleSeoValues_TestLinkCanonical_SetsSeoHelperCanonicalLinkOnly()
        {
            // Arrange
            var attribute = new SeoLinkCanonicalAttribute(TestData.Title);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}
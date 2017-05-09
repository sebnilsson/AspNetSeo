using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.Mvc.Tests
{
    public class SeoMetaDescriptionAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestMetaDescription_SetsMetaDescription()
        {
            // Arrange
            var attribute = new SeoMetaDescriptionAttribute(TestData.MetaDescription);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.MetaDescription, seo.MetaDescription);
        }

        [Fact]
        public void OnHandleSeoValues_TestMetaDescription_SetsMetaDescriptionOnly()
        {
            // Arrange
            var attribute = new SeoMetaDescriptionAttribute(TestData.MetaDescription);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}
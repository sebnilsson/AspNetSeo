using Xunit;

namespace AspNetSeo.Mvc.Tests
{
    public class SeoMetaRobotsNoIndexAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_NoIndexValue_MetaNoIndex()
        {
            // Arrange
            var attribute = new SeoMetaRobotsNoIndexAttribute();

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.True(seo.MetaRobotsNoIndex);
            Assert.Equal(RobotsIndexManager.DefaultRobotsNoIndex, seo.MetaRobotsIndex);
        }

        [Fact]
        public void OnHandleSeoValues_NoIndexValue_MetaNoIndexOnly()
        {
            // Arrange
            var attribute = new SeoMetaRobotsNoIndexAttribute();

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.Title);
        }
    }
}
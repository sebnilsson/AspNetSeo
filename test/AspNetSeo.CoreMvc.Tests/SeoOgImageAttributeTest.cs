using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoOgImageAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestOgImage_SetsOgImage()
        {
            // Arrange
            var attribute = new SeoOgImageAttribute(TestData.OgImage);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.OgImage, seo.OgImage);
        }

        [Fact]
        public void OnHandleSeoValues_TestOgImage_SetsOgImageOnly()
        {
            // Arrange
            var attribute = new SeoOgImageAttribute(TestData.OgImage);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.OgDescription);
            Assert.Null(seo.OgSiteName);
            Assert.Null(seo.OgTitle);
            Assert.Null(seo.OgType);
            Assert.Null(seo.OgUrl);
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}
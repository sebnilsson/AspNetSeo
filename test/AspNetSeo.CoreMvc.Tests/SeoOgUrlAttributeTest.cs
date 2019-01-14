using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoOgUrlAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestOgUrl_SetsOgUrl()
        {
            // Arrange
            var attribute = new SeoOgUrlAttribute(TestData.OgUrl);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.OgUrl, seo.OgUrl);
        }

        [Fact]
        public void OnHandleSeoValues_TestOgUrl_SetsOgUrlOnly()
        {
            // Arrange
            var attribute = new SeoOgUrlAttribute(TestData.OgUrl);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.OgDescription);
            Assert.Null(seo.OgImage);
            Assert.Null(seo.OgTitle);
            Assert.Null(seo.OgType);
            Assert.Null(seo.OgSiteName);
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}
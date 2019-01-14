using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoOgDescriptionAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestOgDescription_SetsOgDescription()
        {
            // Arrange
            var attribute = new SeoOgDescriptionAttribute(TestData.OgDescription);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.OgDescription, seo.OgDescription);
        }

        [Fact]
        public void OnHandleSeoValues_TestOgDescription_SetsOgDescriptionOnly()
        {
            // Arrange
            var attribute = new SeoOgDescriptionAttribute(TestData.OgDescription);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.OgImage);
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
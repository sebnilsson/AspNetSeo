using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoOgTypeNameAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestOgType_SetsOgType()
        {
            // Arrange
            var attribute = new SeoOgTypeAttribute(TestData.OgType);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.OgType, seo.OgType);
        }

        [Fact]
        public void OnHandleSeoValues_TestOgType_SetsOgTypeOnly()
        {
            // Arrange
            var attribute = new SeoOgTypeAttribute(TestData.OgType);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.OgDescription);
            Assert.Null(seo.OgImage);
            Assert.Null(seo.OgTitle);
            Assert.Null(seo.OgSiteName);
            Assert.Null(seo.OgUrl);
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}
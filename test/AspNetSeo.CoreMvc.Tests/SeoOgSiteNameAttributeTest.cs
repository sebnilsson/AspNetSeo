using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoOgSiteNameAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestOgSiteName_SetsOgSiteName()
        {
            // Arrange
            var attribute = new SeoOgSiteNameAttribute(TestData.OgSiteName);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.OgSiteName, seo.OgSiteName);
        }

        [Fact]
        public void OnHandleSeoValues_TestOgSiteName_SetsOgSiteNameOnly()
        {
            // Arrange
            var attribute = new SeoOgSiteNameAttribute(TestData.OgSiteName);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.OgDescription);
            Assert.Null(seo.OgImage);
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
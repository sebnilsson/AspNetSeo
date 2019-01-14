using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoOgTitleAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestOgTitle_SetsOgTitle()
        {
            // Arrange
            var attribute = new SeoOgTitleAttribute(TestData.OgTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.OgTitle, seo.OgTitle);
        }

        [Fact]
        public void OnHandleSeoValues_TestOgTitle_SetsOgTitleOnly()
        {
            // Arrange
            var attribute = new SeoOgTitleAttribute(TestData.OgTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.OgDescription);
            Assert.Null(seo.OgImage);
            Assert.Null(seo.OgSiteName);
            Assert.Null(seo.OgType);
            Assert.Null(seo.OgUrl);
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}
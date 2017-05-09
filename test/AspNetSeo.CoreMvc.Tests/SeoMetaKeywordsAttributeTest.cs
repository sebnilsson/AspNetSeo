using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoMetaKeywordsAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestMetaKeywords_SetsMetaKeywords()
        {
            // Arrange
            var attribute = new SeoMetaKeywordsAttribute(TestData.MetaKeywords);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.MetaKeywords, seo.MetaKeywords);
        }

        [Fact]
        public void OnHandleSeoValues_TestMetaKeywords_SetsMetaKeywordsOnly()
        {
            // Arrange
            var attribute = new SeoMetaKeywordsAttribute(TestData.MetaKeywords);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}
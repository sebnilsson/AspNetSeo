using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoMetaRobotsIndexAttributeTest
    {
        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow)]
        [InlineData(RobotsIndex.NoIndexFollow)]
        [InlineData(RobotsIndex.NoIndexNoFollow)]
        public void OnHandleSeoValues_NoIndexValue_SetsMetaRobotsIndex(RobotsIndex robotsIndex)
        {
            // Arrange
            var attribute = new SeoMetaRobotsIndexAttribute(robotsIndex);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(robotsIndex, seo.MetaRobotsIndex);
        }

        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow)]
        [InlineData(RobotsIndex.NoIndexFollow)]
        [InlineData(RobotsIndex.NoIndexNoFollow)]
        public void OnHandleSeoValues_NoIndexValue_MetaNoIndexOnly(RobotsIndex robotsIndex)
        {
            // Arrange
            var attribute = new SeoMetaRobotsIndexAttribute(robotsIndex);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_Empty_SetsMetaRobotsIndexToNull()
        {
            // Arrange
            var attribute = new SeoMetaRobotsIndexAttribute();

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.MetaRobotsIndex);
        }
    }
}
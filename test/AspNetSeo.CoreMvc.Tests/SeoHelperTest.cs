using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoHelperTest
    {
        [Fact]
        public void Title_Set_TitleEqualsPageTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.Title = TestData.Title;

            // Assert
            Assert.Equal(TestData.Title, seoHelper.Title);
        }
        
        [Fact]
        public void Title_BaseTitleEmpty_SetsTitleToPageTitleOnly()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.Title = TestData.Title;

            // Assert
            Assert.Equal(TestData.Title, seoHelper.Title);
        }
        
        [Fact]
        public void MetaRobotsNoIndex_SetTrue_MetaRobotsIndexEqualsDefaultRobotsNoIndex()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.MetaRobotsNoIndex = true;

            // Assert
            Assert.Equal(RobotsIndexManager.DefaultRobotsNoIndex, seoHelper.MetaRobotsIndex);
            Assert.True(seoHelper.MetaRobotsNoIndex);
        }

        [Fact]
        public void MetaRobotsNoIndex_SetFalse_MetaRobotsIndexIsNull()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.MetaRobotsNoIndex = false;

            // Assert
            Assert.Null(seoHelper.MetaRobotsIndex);
            Assert.False(seoHelper.MetaRobotsNoIndex);
        }
    }
}
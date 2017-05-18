using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoHelperTitleHelperTest
    {
        [Fact]
        public void GetFullTitle_TitleEmptyAndBaseTitleNotEmpty_ReturnsBaseTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();
            seoHelper.BaseTitle = TestData.BaseTitle;

            // Act
            var title = SeoHelperTitleHelper.GetFullTitle(seoHelper);

            // Assert
            Assert.Equal(TestData.BaseTitle, title);
        }

        [Fact]
        public void GetFullTitle_TitleNotEmptyAndBaseTitleEmpty_ReturnsTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();
            seoHelper.Title = TestData.Title;

            // Act
            var title = SeoHelperTitleHelper.GetFullTitle(seoHelper);

            // Assert
            Assert.Equal(TestData.Title, title);
        }

        [Fact]
        public void GetFullTitle_TitleAndBaseTitleNotEmpty_ReturnsTitleWithTitleAndBaseTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();
            seoHelper.BaseTitle = TestData.BaseTitle;
            seoHelper.Title = TestData.Title;

            // Act
            var title = SeoHelperTitleHelper.GetFullTitle(seoHelper);

            // Assert
            bool titleEndsWithSiteTitle = title.EndsWith(TestData.BaseTitle);
            bool titleStartsWithPageTitle = title.StartsWith(TestData.Title);

            Assert.True(titleEndsWithSiteTitle);
            Assert.True(titleStartsWithPageTitle);
        }
    }
}
using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.Mvc.Tests
{
    public class SeoHelperTitleHelperTest
    {
        [Fact]
        public void GetTitle_TitleEmptyAndBaseTitleNotEmpty_ReturnsBaseTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();
            seoHelper.BaseTitle = TestData.BaseTitle;

            // Act
            var title = SeoHelperTitleHelper.GetTitle(seoHelper);

            // Assert
            Assert.Equal(TestData.BaseTitle, title);
        }

        [Fact]
        public void GetTitle_TitleNotEmptyAndBaseTitleEmpty_ReturnsTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();
            seoHelper.Title = TestData.Title;

            // Act
            var title = SeoHelperTitleHelper.GetTitle(seoHelper);

            // Assert
            Assert.Equal(TestData.Title, title);
        }

        [Fact]
        public void GetTitle_TitleAndBaseTitleNotEmpty_ReturnsTitleWithTitleAndBaseTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();
            seoHelper.BaseTitle = TestData.BaseTitle;
            seoHelper.Title = TestData.Title;

            // Act
            var title = SeoHelperTitleHelper.GetTitle(seoHelper);

            // Assert
            bool titleEndsWithSiteTitle = title.EndsWith(TestData.BaseTitle);
            bool titleStartsWithPageTitle = title.StartsWith(TestData.Title);

            Assert.True(titleEndsWithSiteTitle);
            Assert.True(titleStartsWithPageTitle);
        }
    }
}
using Xunit;

namespace AspNetSeo.Tests
{
    public class SeoHelperTests
    {
        private readonly ISeoHelper _seoHelper;

        public SeoHelperTests()
        {
            _seoHelper = new SeoHelper();
        }

        [Fact]
        public void DocumentTitle_GetWithTitleSiteNameAndFormat_ReturnsAllValues()
        {
            // Arrange
            var pageTitle = "TEST_TITLE";
            var siteName = "TEST_SITE_NAME";
            var format = "TEST_FORMAT {1} / {0} END_TEST_FORMAT";

            // Act
            _seoHelper.PageTitle = pageTitle;
            _seoHelper.SiteName = siteName;
            _seoHelper.DocumentTitleFormat = format;

            // Assert
            Assert.Equal(
                "TEST_FORMAT TEST_SITE_NAME / TEST_TITLE END_TEST_FORMAT",
                _seoHelper.DocumentTitle);
        }

        [Theory]
        [InlineData(true, true, "INDEX, FOLLOW")]
        [InlineData(true, false, "INDEX, NOFOLLOW")]
        [InlineData(false, true, "NOINDEX, FOLLOW")]
        [InlineData(false, false, "NOINDEX, NOFOLLOW")]
        public void SetMetaRobots_IndexAndFollow_ReturnsRobotsString(
            bool index,
            bool follow,
            string expected)
        {
            // Act
            _seoHelper.SetMetaRobots(index: index, follow: follow);

            // Assert
            Assert.Equal(expected, _seoHelper.MetaRobots);
        }
    }
}
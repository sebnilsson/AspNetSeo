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
            var title = "TEST_TITLE";
            var siteName = "TEST_SITE_NAME";
            var format = "TEST_FORMAT {1} / {0}";

            // Act
            //_seoHelper.Title = title;
            //_seoHelper.SiteName = siteName;
            //_seoHelper.DocumentTitleFormat = format;

            // Assert
            Assert.Equal(
                "TEST_FORMAT TEST_SITE_NAME / TEST_TITLE",
                _seoHelper.DocumentTitle);
        }
    }
}
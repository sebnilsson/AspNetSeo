using AspNetSeo.Internal;
using Xunit;

namespace AspNetSeo.Tests;

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
    [InlineData(true, true, $"{MetaRobotsValue.Index}, {MetaRobotsValue.Follow}")]
    [InlineData(true, false, $"{MetaRobotsValue.Index}, {MetaRobotsValue.NoFollow}")]
    [InlineData(false, true, $"{MetaRobotsValue.NoIndex}, {MetaRobotsValue.Follow}")]
    [InlineData(false, false, $"{MetaRobotsValue.NoIndex}, {MetaRobotsValue.NoFollow}")]
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

    [Fact]
    public void SetCustomMeta_AddsNewItem_SetsValueAndAttribute()
    {
        // Arrange
        var key = "og:title";
        var value = "Hello";
        var attribute = CustomMetaAttributeKey.Property;

        // Act
        _seoHelper.SetCustomMeta(key, value, attribute);

        // Assert
        Assert.True(_seoHelper.CustomMetas.ContainsKey(key));
        var item = _seoHelper.CustomMetas[key];
        Assert.Equal(key, item.Key);
        Assert.Equal(value, item.Value);
        Assert.Equal(attribute, item.Attribute);
        Assert.Single(_seoHelper.CustomMetas);
    }

    [Fact]
    public void SetCustomMeta_UpdatesExisting_OverwritesValueAndAttribute()
    {
        // Arrange
        var key = "description";
        _seoHelper.SetCustomMeta(key, "old", CustomMetaAttributeKey.Name);

        // Act
        _seoHelper.SetCustomMeta(key, "new", CustomMetaAttributeKey.Property);

        // Assert
        Assert.True(_seoHelper.CustomMetas.ContainsKey(key));
        var item = _seoHelper.CustomMetas[key];
        Assert.Equal("new", item.Value);
        Assert.Equal(CustomMetaAttributeKey.Property, item.Attribute);
        Assert.Single(_seoHelper.CustomMetas);
    }

    [Fact]
    public void SetCustomMeta_Remove_WhenValueIsNull_RemovesEntry()
    {
        // Arrange
        var key = "keywords";
        _seoHelper.SetCustomMeta(key, "k1,k2", CustomMetaAttributeKey.Name);
        Assert.True(_seoHelper.CustomMetas.ContainsKey(key));

        // Act
        _seoHelper.SetCustomMeta(key, null);

        // Assert
        Assert.False(_seoHelper.CustomMetas.ContainsKey(key));
        Assert.Empty(_seoHelper.CustomMetas);
    }

    [Fact]
    public void SetCustomMeta_NullKey_Throws()
    {
        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => _seoHelper.SetCustomMeta(null!, "value"));
    }

    [Fact]
    public void SetCustomMeta_IsCaseInsensitive_UpdatesSameEntry()
    {
        // Arrange
        _seoHelper.SetCustomMeta("META:KEY", "A");

        // Act
        _seoHelper.SetCustomMeta("meta:key", "B");

        // Assert
        Assert.Single(_seoHelper.CustomMetas);
        Assert.Equal("B", _seoHelper.CustomMetas["META:KEY"].Value);
        Assert.Equal("B", _seoHelper.CustomMetas["meta:key"].Value);
    }
}

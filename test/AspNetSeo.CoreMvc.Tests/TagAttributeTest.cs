using AspNetSeo.Internal;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests;

public class TagAttributeTest
{
    [Theory]
    [MemberData(nameof(GetMemberData))]
    public void OnHandleSeoValues_TestData_ReturnsExpectedHtml(
        SeoAttributeBase attribute,
        Func<ISeoHelper, object> seoHelperResultFactory,
        object expected)
    {
        // Arrange
        var seoHelper = new SeoHelper();

        // Act
        attribute.OnHandleSeoValues(seoHelper);

        // Assert
        var result = seoHelperResultFactory.Invoke(seoHelper);

        Assert.Equal(expected, result);
    }

    public static TheoryData<SeoAttributeBase, Func<ISeoHelper, object?>, object> GetMemberData => new()
    {
        { new LinkCanonicalAttribute("TEST_LINK_CANONICAL"), seoHelper => seoHelper.LinkCanonical, "TEST_LINK_CANONICAL" },
        { new MetaDescriptionAttribute("TEST_META_DESCRIPTION"), seoHelper => seoHelper.MetaDescription, "TEST_META_DESCRIPTION" },
        { new MetaKeywordsAttribute("TEST_META_KEYWORDS"), seoHelper => seoHelper.MetaKeywords, "TEST_META_KEYWORDS" },
        { new MetaRobotsAttribute("TEST_META_ROBOTS"), seoHelper => seoHelper.MetaRobots, "TEST_META_ROBOTS" },
        { new MetaRobotsAttribute(index: true, follow: true), seoHelper => seoHelper.MetaRobots, $"{MetaRobotsValue.Index}, {MetaRobotsValue.Follow}" },
        { new MetaRobotsAttribute(index: false, follow: true), seoHelper => seoHelper.MetaRobots, $"{MetaRobotsValue.NoIndex}, {MetaRobotsValue.Follow}" },
        { new MetaRobotsAttribute(index: true, follow: false), seoHelper => seoHelper.MetaRobots, $"{MetaRobotsValue.Index}, {MetaRobotsValue.NoFollow}" },
        { new MetaRobotsAttribute(index: false, follow: false), seoHelper => seoHelper.MetaRobots, $"{MetaRobotsValue.NoIndex}, {MetaRobotsValue.NoFollow}" },
        { new OgAudioAttribute("TEST_OG_AUDIO"), seoHelper => seoHelper.OgAudio, "TEST_OG_AUDIO" },
        { new OgDescriptionAttribute("TEST_OG_DESCRIPTION"), seoHelper => seoHelper.OgDescription, "TEST_OG_DESCRIPTION" },
        { new OgDeterminerAttribute("TEST_OG_DETERMINER"), seoHelper => seoHelper.OgDeterminer, "TEST_OG_DETERMINER" },
        { new OgImageAttribute("TEST_OG_IMAGE"), seoHelper => seoHelper.OgImage, "TEST_OG_IMAGE" },
        { new OgLocaleAttribute("TEST_OG_LOCALE"), seoHelper => seoHelper.OgLocale, "TEST_OG_LOCALE" },
        { new OgLocaleAlternateAttribute("da_DK", "en_US"), seoHelper => seoHelper.OgLocaleAlternates, new[] { "da_DK", "en_US" } },
        { new OgSiteNameAttribute("TEST_OG_SITE_NAME"), seoHelper => seoHelper.OgSiteName, "TEST_OG_SITE_NAME" },
        { new OgTitleAttribute("TEST_OG_TITLE"), seoHelper => seoHelper.OgTitle, "TEST_OG_TITLE" },
        { new OgTypeAttribute("TEST_OG_TYPE"), seoHelper => seoHelper.OgType, "TEST_OG_TYPE" },
        { new OgUrlAttribute("TEST_OG_URL"), seoHelper => seoHelper.OgUrl, "TEST_OG_URL" },
        { new OgVideoAttribute("TEST_OG_VIDEO"), seoHelper => seoHelper.OgVideo, "TEST_OG_VIDEO" },
        { new PageTitleAttribute("TEST_PAGE_TITLE"), seoHelper => seoHelper.PageTitle, "TEST_PAGE_TITLE" },
        { new SiteNameAttribute("TEST_SITE_NAME"), seoHelper => seoHelper.SiteName, "TEST_SITE_NAME" },
        { new SiteUrlAttribute("TEST_SITE_URL"), seoHelper => seoHelper.SiteUrl, "TEST_SITE_URL" }
    };
}

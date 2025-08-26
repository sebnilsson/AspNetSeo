﻿using System.Collections.Generic;
using AspNetSeo.Internal;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests;

public class TagAttributeTest
{
    [Theory]
    [MemberData(nameof(GetMemberData))]
    public void OnHandleSeoValues_TestData_ReturnsExpectedHtml<TResult>(
        SeoAttributeBase attribute,
        Func<ISeoHelper, TResult> seoHelperResultFactory,
        TResult expected)
    {
        // Arrange
        var seoHelper = new SeoHelper();

        // Act
        attribute.OnHandleSeoValues(seoHelper);

        // Assert
        var result = seoHelperResultFactory.Invoke(seoHelper);

        Assert.Equal(expected, result);
    }
    public static IEnumerable<object[]> GetMemberData()
    {
        yield return new object[]
        {
            new LinkCanonicalAttribute("TEST_LINK_CANONICAL"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.LinkCanonical),
            "TEST_LINK_CANONICAL",
        };

        yield return new object[]
        {
            new MetaDescriptionAttribute("TEST_META_DESCRIPTION"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.MetaDescription),
            "TEST_META_DESCRIPTION",
        };

        yield return new object[]
        {
            new MetaKeywordsAttribute("TEST_META_KEYWORDS"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.MetaKeywords),
            "TEST_META_KEYWORDS",
        };

        yield return new object[]
        {
            new MetaRobotsAttribute("TEST_META_ROBOTS"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.MetaRobots),
            "TEST_META_ROBOTS",
        };

        yield return new object[]
        {
            new MetaRobotsAttribute(index: true, follow: true),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.MetaRobots),
            $"{MetaRobotsValue.Index}, {MetaRobotsValue.Follow}",
        };

        yield return new object[]
        {
            new MetaRobotsAttribute(index: false, follow: true),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.MetaRobots),
            $"{MetaRobotsValue.NoIndex}, {MetaRobotsValue.Follow}",
        };

        yield return new object[]
        {
            new MetaRobotsAttribute(index: true, follow: false),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.MetaRobots),
            $"{MetaRobotsValue.Index}, {MetaRobotsValue.NoFollow}",
        };

        yield return new object[]
        {
            new MetaRobotsAttribute(index: false, follow: false),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.MetaRobots),
            $"{MetaRobotsValue.NoIndex}, {MetaRobotsValue.NoFollow}"
        };

        yield return new object[]
        {
            new OgAudioAttribute("TEST_OG_AUDIO"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgAudio),
            "TEST_OG_AUDIO",
        };

        yield return new object[]
        {
            new OgDescriptionAttribute("TEST_OG_DESCRIPTION"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgDescription),
            "TEST_OG_DESCRIPTION",
        };

        yield return new object[]
        {
            new OgDeterminerAttribute("TEST_OG_DETERMINER"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgDeterminer),
            "TEST_OG_DETERMINER",
        };

        yield return new object[]
        {
            new OgImageAttribute("TEST_OG_IMAGE"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgImage),
            "TEST_OG_IMAGE",
        };

        yield return new object[]
        {
            new OgLocaleAttribute("TEST_OG_LOCALE"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgLocale),
            "TEST_OG_LOCALE",
        };

        yield return new object[]
        {
            new OgLocaleAlternateAttribute("da_DK", "en_US"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgLocaleAlternates),
            new List<string> { "da_DK", "en_US" }
        };

        yield return new object[]
        {
            new OgSiteNameAttribute("TEST_OG_SITE_NAME"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgSiteName),
            "TEST_OG_SITE_NAME",
        };

        yield return new object[]
        {
            new OgTitleAttribute("TEST_OG_TITLE"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgTitle),
            "TEST_OG_TITLE",
        };

        yield return new object[]
        {
            new OgTypeAttribute("TEST_OG_TYPE"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgType),
            "TEST_OG_TYPE",
        };

        yield return new object[]
        {
            new OgUrlAttribute("TEST_OG_URL"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgUrl),
            "TEST_OG_URL",
        };

        yield return new object[]
        {
            new OgVideoAttribute("TEST_OG_VIDEO"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.OgVideo),
            "TEST_OG_VIDEO",
        };

        yield return new object[]
        {
            new PageTitleAttribute("TEST_PAGE_TITLE"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.PageTitle),
            "TEST_PAGE_TITLE",
        };

        yield return new object[]
        {
            new SiteNameAttribute("TEST_SITE_NAME"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.SiteName),
            "TEST_SITE_NAME",
        };

        yield return new object[]
        {
            new SiteUrlAttribute("TEST_SITE_URL"),
            GetResultFactory(
                (ISeoHelper seoHelper) => seoHelper.SiteUrl),
            "TEST_SITE_URL",
        };
    }

    private static object GetResultFactory<TResult>(
        Func<ISeoHelper, TResult> factory)
    {
        return factory;
    }
}

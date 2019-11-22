using System.Collections.Generic;

using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers
{
    public class MetaTagHelperTest : TagHelperTestBase
    {
        [Theory]
        [MemberData(nameof(GetMemberData))]
        public void Process_TestData_ReturnsExpectedHtml(
            string expected,
            TagHelper tagHelper,
            string tagName)
        {
            // Act
            var html = tagHelper.GetHtml(tagName);

            // Assert
            Assert.Equal(expected, html);
        }

        public static IEnumerable<object[]> GetMemberData()
        {
            yield return new object[]
            {
                MetaTag(MetaName.Description, "TEST_DESCRIPTION"),
                TagHelperTestFactory.Create(
                    seo => new MetaDescriptionTagHelper(seo),
                    seo => seo.MetaDescription = "TEST_DESCRIPTION"),
                "meta-description"
            };

            yield return new object[]
            {
                MetaTag(MetaName.Keywords, "TEST_KEYWORDS"),
                TagHelperTestFactory.Create(
                    seo => new MetaKeywordsTagHelper(seo),
                    seo => seo.MetaKeywords = "TEST_KEYWORDS"),
                "meta-keywords"
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Description, "TEST_OG_DESCRIPTION"),
                TagHelperTestFactory.Create(
                    seo => new OgDescriptionTagHelper(seo),
                    seo => seo.OgDescription = "TEST_OG_DESCRIPTION"),
                "og-description"
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Description, "TEST_META_DESCRIPTION"),
                TagHelperTestFactory.Create(
                    seo => new OgDescriptionTagHelper(seo),
                    seo => seo.MetaDescription = "TEST_META_DESCRIPTION"),
                "og-description"
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Image, "TEST_OG_IMAGE"),
                TagHelperTestFactory.Create(
                    seo => new OgImageTagHelper(seo),
                    seo => seo.OgImage = "TEST_OG_IMAGE"),
                "og-image"
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.SiteName, "TEST_OG_SITENAME"),
                TagHelperTestFactory.Create(
                    seo => new OgSiteNameTagHelper(seo),
                    seo => seo.OgSiteName = "TEST_OG_SITENAME"),
                "og-description"
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.SiteName, "TEST_SITENAME"),
                TagHelperTestFactory.Create(
                    seo => new OgSiteNameTagHelper(seo),
                    seo => seo.SiteName = "TEST_SITENAME"),
                "og-description"
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Title, "TEST_OG_TITLE"),
                TagHelperTestFactory.Create(
                    seo => new OgTitleTagHelper(seo),
                    seo => seo.OgTitle = "TEST_OG_TITLE"),
                "og-title"
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Title, "TEST_PAGE_TITLE"),
                TagHelperTestFactory.Create(
                    seo => new OgTitleTagHelper(seo),
                    seo => seo.PageTitle = "TEST_PAGE_TITLE"),
                "og-title"
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Type, "TEST_OG_TYPE"),
                TagHelperTestFactory.Create(
                    seo => new OgTypeTagHelper(seo),
                    seo => seo.OgType = "TEST_OG_TYPE"),
                "og-type"
            };
        }
    }
}

using System;
using System.Collections.Generic;

using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers
{
    public class OgUrlTagHelperTest : TagHelperTestBase
    {
        [Theory]
        [MemberData(nameof(GetMemberData))]
        public void Process_TestData_ReturnsExpectedHtml(
            string expected,
            TagHelper tagHelper)
        {
            // Act
            var html = tagHelper.GetHtml("og-url");

            // Assert
            Assert.Equal(expected, html);
        }

        public static IEnumerable<object[]> GetMemberData()
        {
            var urlHelper = SeoUrlHelperTestFactory.Create(
                new Uri("http://urlhelper.co/helper/page.html?query=123"));

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Url, "https://t.com/t/test/TEST_OG_URL?q=1&amp;query=&#xF6;"),
                TagHelperTestFactory.Create(
                    seo => new OgUrlTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.com/t/";
                        seo.OgUrl = "test/TEST_OG_URL?q=1&query=ö";
                    })
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Url, "http://urlhelper.co/test/TEST_OG_URL?q=1&amp;query=&#xF6;"),
                TagHelperTestFactory.Create(
                    seo => new OgUrlTagHelper(seo, urlHelper),
                    seo => {
                        seo.OgUrl = "/test/TEST_OG_URL?q=1&query=ö";
                    })
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Url, "https://t.co/t/t/test/TEST_OG_URL?q=1&amp;query=&#xF6;"),
                TagHelperTestFactory.Create(
                    seo => new OgUrlTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.co/t/t/";
                        seo.OgUrl = "test/TEST_OG_URL?q=1&query=ö";
                    })
            };

            yield return new object[]
            {
                string.Empty,
                TagHelperTestFactory.Create(
                    seo => new OgUrlTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.com/test/";
                    })
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Url, "https://t.co/test/test.html"),
                TagHelperTestFactory.Create(
                    seo => new OgUrlTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.co/t/t/";
                        seo.OgUrl = "~/test/test.html";
                    })
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Url, "https://t.com/t/test/TEST_OG_URL?q=1&amp;query=&#xF6;"),
                TagHelperTestFactory.Create(
                    seo => new OgUrlTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.com/t/";
                        seo.LinkCanonical = "test/TEST_OG_URL?q=1&query=ö";
                    })
            };

            yield return new object[]
            {
                OpenGraphTag(OgMetaName.Url, "http://urlhelper.co/test/TEST_OG_URL?q=1&amp;query=&#xF6;"),
                TagHelperTestFactory.Create(
                    seo => new OgUrlTagHelper(seo, urlHelper),
                    seo => {
                        seo.LinkCanonical = "/test/TEST_OG_URL?q=1&query=ö";
                    })
            };
        }        
    }
}

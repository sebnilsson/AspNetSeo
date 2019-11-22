using System;
using System.Collections.Generic;

using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers
{
    public class LinkCanonicalTagHelperTest : TagHelperTestBase
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
                new Uri("http://url-helper.co/helper/page.html?query=123"));

            yield return new object[]
            {
                string.Empty,
                TagHelperTestFactory.Create(
                    seo => new LinkCanonicalTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.com/t/";
                        seo.OgUrl = null;
                    })
            };

            yield return new object[]
            {
                string.Empty,
                TagHelperTestFactory.Create(
                    seo => new LinkCanonicalTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.com/test/";
                    })
            };

            yield return new object[]
            {
                LinkCanonicalTag("https://t.com/t/test/TEST_OG_URL?q=1&amp;query=&#xF6;"),
                TagHelperTestFactory.Create(
                    seo => new LinkCanonicalTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.com/t/";
                        seo.LinkCanonical = "test/TEST_OG_URL?q=1&query=ö";
                    })
            };

            yield return new object[]
            {
                LinkCanonicalTag("http://url-helper.co/test/TEST_OG_URL?q=1&amp;query=&#xF6;"),
                TagHelperTestFactory.Create(
                    seo => new LinkCanonicalTagHelper(seo, urlHelper),
                    seo => {
                        seo.LinkCanonical = "/test/TEST_OG_URL?q=1&query=ö";
                    })
            };

            yield return new object[]
            {
                LinkCanonicalTag("https://t.co/t/t/test/TEST_OG_URL?q=1&amp;query=&#xF6;"),
                TagHelperTestFactory.Create(
                    seo => new LinkCanonicalTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.co/t/t/";
                        seo.LinkCanonical = "test/TEST_OG_URL?q=1&query=ö";
                    })
            };

            yield return new object[]
            {
                LinkCanonicalTag("https://t.co/test/test.html"),
                TagHelperTestFactory.Create(
                    seo => new LinkCanonicalTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = "https://t.co/t/t/";
                        seo.LinkCanonical = "~/test/test.html";
                    })
            };

            yield return new object[]
            {
                LinkCanonicalTag("http://url-helper.co/test/test.html"),
                TagHelperTestFactory.Create(
                    seo => new LinkCanonicalTagHelper(seo, urlHelper),
                    seo => {
                        seo.SiteUrl = null;
                        seo.LinkCanonical = "~/test/test.html";
                    })
            };
        }

        private static string LinkCanonicalTag(string href)
        {
            return $"<link rel=\"canonical\" href=\"{href}\" />";
        }
    }
}

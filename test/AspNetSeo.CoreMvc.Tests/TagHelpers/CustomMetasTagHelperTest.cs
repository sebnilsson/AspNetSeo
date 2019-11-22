using System;
using System.Collections.Generic;

using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers
{
    public class CustomMetasTagHelperTest : TagHelperTestBase
    {
        [Fact]
        public void Process_TestData_ReturnsExpectedHtml()
        {
            // Arrange
            var tagHelper = TagHelperTestFactory.Create(
                    seo => new CustomMetasTagHelper(seo),
                    seo =>
                    {
                        seo.SetCustomMeta("CUSTOM_KEY1", "CUSTOM_VALUE1");
                        seo.SetCustomMeta("CUSTOM_KEY2", "CUSTOM_VALUE1");
                        seo.SetCustomMeta("CUSTOM_KEY2", "CUSTOM_VALUE2");
                    });

            // Act
            var html = tagHelper.GetHtml("custom-metas");

            // Assert
            var expected =
                $"{MetaTagContentFirst("CUSTOM_KEY1", "CUSTOM_VALUE1")}" +
                $"{Environment.NewLine}" +
                $"{MetaTagContentFirst("CUSTOM_KEY2", "CUSTOM_VALUE2")}";

            Assert.Equal(expected, html);
        }

        public static IEnumerable<object[]> GetMemberData()
        {
            yield return new object[]
            {
                "<title>TEST_PAGE_TITLE</title>",
                TagHelperTestFactory.Create(
                    seo => new CustomMetasTagHelper(seo),
                    seo => seo.PageTitle = "TEST_PAGE_TITLE")
            };
        }
    }
}

using System.Collections.Generic;

using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers
{
    public class DocumentTitleTagHelperTest
    {
        [Theory]
        [MemberData(nameof(GetMemberData))]
        public void Process_TestData_ReturnsExpectedHtml(
            string expected,
            TagHelper tagHelper)
        {
            // Act
            var html = tagHelper.GetHtml("document-title");

            // Assert
            Assert.Equal(expected, html);
        }

        public static IEnumerable<object[]> GetMemberData()
        {
            yield return new object[]
            {
                "<title>TEST_PAGE_TITLE</title>",
                TagHelperTestFactory.Create(
                    seo => new DocumentTitleTagHelper(seo),
                    seo => seo.PageTitle = "TEST_PAGE_TITLE")
            };
        }
    }
}
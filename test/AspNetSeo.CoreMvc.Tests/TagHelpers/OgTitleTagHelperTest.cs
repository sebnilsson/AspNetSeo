using System.Collections.Generic;
using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers
{
    public class OgTitleTagHelperTest : TagHelperTestBase
    {
        [Theory]
        [MemberData(nameof(GetMemberData))]
        public void Process_TestData_ReturnsExpectedHtml(
            TagHelper tagHelper)
        {
            // Act
            var html = tagHelper.GetHtml(OgTitleTagHelper.Tag);

            // Assert
            Assert.Equal(string.Empty, html);
        }

        public static IEnumerable<object[]> GetMemberData()
        {
            yield return new object[]
            {
                //MetaTag(OgMetaName.Title, "TEST_SITE_NAME"),
                TagHelperTestFactory.Create(
                    seo => {
                        seo.SiteName = "TEST_SITE_NAME";

                        return new OgTitleTagHelper(seo);
                    })
            };
        }
    }
}

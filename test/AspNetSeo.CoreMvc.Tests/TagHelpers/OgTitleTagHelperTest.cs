using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

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

    public static TheoryData<TagHelper> GetMemberData => new()
    {
        {
            TagHelperTestFactory.Create(
                seo =>
                {
                    seo.SiteName = "TEST_SITE_NAME";

                    return new OgTitleTagHelper(seo);
                })
        }
    };
}

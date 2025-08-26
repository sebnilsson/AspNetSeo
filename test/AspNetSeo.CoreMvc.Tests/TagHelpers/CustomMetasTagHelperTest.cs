using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;
using AspNetSeo;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

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
            $"{MetaTag("CUSTOM_KEY1", "CUSTOM_VALUE1")}" +
            $"{Environment.NewLine}" +
            $"{MetaTag("CUSTOM_KEY2", "CUSTOM_VALUE2")}";

        Assert.Equal(expected, html);
    }

    [Fact]
    public void Process_KnownPrefixes_UsesPropertyAttribute()
    {
        // Arrange
        var tagHelper = TagHelperTestFactory.Create(
                seo => new CustomMetasTagHelper(seo),
                seo =>
                {
                    seo.SetCustomMeta("og:image:width", "100");
                    seo.SetCustomMeta("fb:app_id", "1");
                    seo.SetCustomMeta("custom", "c");
                });

        // Act
        var html = tagHelper.GetHtml("custom-metas");

        // Assert
        var expected =
            $"{OpenGraphTag("og:image:width", "100")}" +
            $"{Environment.NewLine}" +
            $"{OpenGraphTag("fb:app_id", "1")}" +
            $"{Environment.NewLine}" +
            $"{MetaTag("custom", "c")}";

        Assert.Equal(expected, html);
    }

    [Fact]
    public void Process_OverrideDetection_UsesExplicitChoice()
    {
        // Arrange
        var tagHelper = TagHelperTestFactory.Create(
                seo => new CustomMetasTagHelper(seo),
                seo =>
                {
                    seo.SetCustomMeta("og:title", "x", CustomMetaAttributeKey.Name);
                    seo.SetCustomMeta("plain", "y", CustomMetaAttributeKey.Property);
                });

        // Act
        var html = tagHelper.GetHtml("custom-metas");

        // Assert
        var expected =
            $"{MetaTag("og:title", "x")}" +
            $"{Environment.NewLine}" +
            $"{OpenGraphTag("plain", "y")}";

        Assert.Equal(expected, html);
    }

    public static TheoryData<string, TagHelper> GetMemberData => new()
    {
        {
            "<title>TEST_PAGE_TITLE</title>",
            TagHelperTestFactory.Create(
                seo => new CustomMetasTagHelper(seo),
                seo => seo.PageTitle = "TEST_PAGE_TITLE")
        }
    };
}

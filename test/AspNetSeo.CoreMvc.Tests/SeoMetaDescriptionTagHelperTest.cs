using System;

using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoMetaDescriptionTagHelperTest
    {
        [Fact]
        public void Process_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var tag = GetSeoMetaDescriptionTagHelper();

            // Act
            var output = tag.Process(SeoMetaDescriptionTagHelper.TagName);

            // Assert
            string html = output.GetContent();
            bool isHtmlNullOrWhiteSpace = string.IsNullOrWhiteSpace(html);

            Assert.True(isHtmlNullOrWhiteSpace);
        }

        [Fact]
        public void Process_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var tag = GetSeoMetaDescriptionTagHelper(seoHelper => seoHelper.MetaDescription = TestData.MetaDescription);

            // Act
            var output = tag.Process(SeoMetaDescriptionTagHelper.TagName);

            // Assert
            string html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.MetaDescription);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void Process_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var tag = GetSeoMetaDescriptionTagHelper();
            tag.Value = TestData.MetaDescription;

            var attributes = new[] { new TagHelperAttribute(nameof(tag.Value), TestData.MetaDescription) };

            // Act
            var output = tag.Process(SeoMetaDescriptionTagHelper.TagName, attributes);

            // Assert
            string html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.MetaDescription);

            Assert.True(htmlContainsValue);
        }

        private static SeoMetaDescriptionTagHelper GetSeoMetaDescriptionTagHelper(
            Action<SeoHelper> seoHelperConfig = null)
        {
            var seoHelper = SeoHelperTestFactory.Create();

            seoHelperConfig?.Invoke(seoHelper);

            var tag = new SeoMetaDescriptionTagHelper(seoHelper);
            return tag;
        }
    }
}
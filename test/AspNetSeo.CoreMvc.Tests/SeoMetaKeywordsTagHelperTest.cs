using System;

using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoMetaKeywordsTagHelperTest
    {
        [Fact]
        public void Process_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var tag = GetSeoMetaKeywordsTagHelper();

            // Act
            var output = tag.Process(SeoMetaKeywordsTagHelper.TagName);

            // Assert
            string html = output.GetContent();
            bool isHtmlNullOrWhiteSpace = string.IsNullOrWhiteSpace(html);

            Assert.True(isHtmlNullOrWhiteSpace);
        }

        [Fact]
        public void Process_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var tag = GetSeoMetaKeywordsTagHelper(seoHelper => seoHelper.MetaKeywords = TestData.MetaKeywords);

            // Act
            var output = tag.Process(SeoMetaKeywordsTagHelper.TagName);

            // Assert
            string html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.MetaKeywords);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void Process_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var tag = GetSeoMetaKeywordsTagHelper();
            tag.Value = TestData.MetaKeywords;

            var attributes = new[] { new TagHelperAttribute(nameof(tag.Value), TestData.MetaKeywords) };

            // Act
            var output = tag.Process(SeoMetaKeywordsTagHelper.TagName, attributes);

            // Assert
            string html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.MetaKeywords);

            Assert.True(htmlContainsValue);
        }

        private static SeoMetaKeywordsTagHelper GetSeoMetaKeywordsTagHelper(
            Action<SeoHelper> seoHelperConfig = null)
        {
            var seoHelper = SeoHelperTestFactory.Create();

            seoHelperConfig?.Invoke(seoHelper);

            var tag = new SeoMetaKeywordsTagHelper(seoHelper);
            return tag;
        }
    }
}
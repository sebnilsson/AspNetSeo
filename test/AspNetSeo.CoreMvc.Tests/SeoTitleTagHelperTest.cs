using System;

using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoTitleTagHelperTest
    {
        [Fact]
        public void SeoTitle_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var tag = GetSeoTitleTagHelper();

            // Act
            var output = tag.Process(SeoTitleTagHelper.TagName);

            // Assert
            var html = output.GetContent();
            bool htmlIsNullOrEmpty = string.IsNullOrWhiteSpace(html);

            Assert.True(htmlIsNullOrEmpty);
        }

        [Fact]
        public void SeoTitle_EmptyArgumentWithPageTitleInSeoHelper_ReturnsNotNull()
        {
            // Arrange
            var tag = GetSeoTitleTagHelper(seoHelper => seoHelper.Title = TestData.Title);

            // Act
            var output = tag.Process(SeoTitleTagHelper.TagName);

            // Assert
            var html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.Title);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoTitle_EmptyArgumentWithBaseTitleInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var tag = GetSeoTitleTagHelper(seoHelper => seoHelper.BaseTitle = TestData.BaseTitle);

            // Act
            var output = tag.Process(SeoTitleTagHelper.TagName);

            // Assert
            var html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.BaseTitle);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoTitle_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var tag = GetSeoTitleTagHelper();
            tag.Value = TestData.Title;

            var attributes = new[] { new TagHelperAttribute(nameof(tag.Value), TestData.Title) };

            // Act
            var output = tag.Process(SeoTitleTagHelper.TagName, attributes);

            // Assert
            var html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.Title);

            Assert.True(htmlContainsValue);
        }

        private static SeoTitleTagHelper GetSeoTitleTagHelper(Action<SeoHelper> seoHelperConfig = null)
        {
            var seoHelper = SeoHelperTestFactory.Create();

            seoHelperConfig?.Invoke(seoHelper);

            var tag = new SeoTitleTagHelper(seoHelper);
            return tag;
        }
    }
}
using System;

using AspNetSeo.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests
{
    public class SeoLinkCanonicalTagHelperTest
    {
        [Fact]
        public void Process_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var tag = GetSeoLinkCanonicalTagHelper();

            // Act
            var output = tag.Process(SeoLinkCanonicalTagHelper.TagName);

            // Assert
            var html = output.GetContent();
            bool htmlIsNullOrEmpty = string.IsNullOrWhiteSpace(html);

            Assert.True(htmlIsNullOrEmpty);
        }

        [Fact]
        public void Process_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var tag = GetSeoLinkCanonicalTagHelper(seoHelper => seoHelper.LinkCanonical = $"{TestData.LinkCanonical}");

            // Act
            var output = tag.Process(SeoLinkCanonicalTagHelper.TagName);

            // Assert
            var html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.LinkCanonical);
            bool htmlContainsValueAttribute = html.ToLowerInvariant().Contains("value=\"");
            bool htmlContainsLinkTag = html.ToLowerInvariant().Contains("<link ");

            Assert.Equal("link", output.TagName);
            Assert.True(htmlContainsValue);
            Assert.False(htmlContainsValueAttribute);
            Assert.True(htmlContainsLinkTag);
        }

        [Fact]
        public void Process_EmptyArgumentWithAppRelativeValueInSeoHelper_ReturnsHtmlContainingValueAndIsAbsolute()
        {
            // Arrange
            var tag =
                GetSeoLinkCanonicalTagHelper(seoHelper => seoHelper.LinkCanonical = TestData.AppRelativeLinkCanonical);

            // Act
            var output = tag.Process(SeoLinkCanonicalTagHelper.TagName);

            // Assert
            var html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.LinkCanonical);
            bool htmlContainsDomain = html.Contains(ViewContextTestFactory.Domain);
            bool htmlContainsAppRelativeCharacter = html.Contains("~");

            Assert.True(htmlContainsValue);
            Assert.True(htmlContainsDomain);
            Assert.False(htmlContainsAppRelativeCharacter);
        }

        [Fact]
        public void Process_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var tag = GetSeoLinkCanonicalTagHelper();
            tag.Value = TestData.AppRelativeLinkCanonical;

            var attributes = new[] { new TagHelperAttribute(nameof(tag.Value), TestData.LinkCanonical) };

            // Act
            var output = tag.Process(SeoLinkCanonicalTagHelper.TagName, attributes);

            // Assert
            var html = output.GetContent();
            bool htmlContainsValue = html.Contains(TestData.LinkCanonical);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void Process_WithValue_ReturnsHtmlContainingAbsoluteUrl()
        {
            // Arrange
            var tag = GetSeoLinkCanonicalTagHelper();
            tag.Value = TestData.AppRelativeLinkCanonical;

            var attributes = new[] { new TagHelperAttribute(nameof(tag.Value), TestData.LinkCanonical) };

            // Act
            var output = tag.Process(SeoLinkCanonicalTagHelper.TagName, attributes);

            // Assert
            var html = output.GetContent();
            bool htmlContainsAbsoluteUrl = html.Contains(ViewContextTestFactory.Domain);

            Assert.True(htmlContainsAbsoluteUrl);
        }

        [Fact]
        public void Process_WithLinkCanonicalBaseOnly_ReturnsEmptyHtml()
        {
            const string LinkCanonicalBase = "https://linkcanonical.co/base/";

            // Arrange
            var tag = GetSeoLinkCanonicalTagHelper();
            tag.Base = LinkCanonicalBase;

            var attributes = new[] { new TagHelperAttribute(nameof(tag.Base), LinkCanonicalBase) };

            // Act
            var output = tag.Process(SeoLinkCanonicalTagHelper.TagName, attributes);

            // Assert
            var html = output.GetContent();
            bool htmlIsEmpty = string.IsNullOrWhiteSpace(html);

            Assert.True(htmlIsEmpty);
        }

        [Fact]
        public void Process_WithLinkCanonicalBase_ReturnsHtmlContainingLinkCanonicalBase()
        {
            const string LinkCanonicalBase = "https://linkcanonical.co/base/";

            // Arrange
            var tag = GetSeoLinkCanonicalTagHelper();
            tag.Base = LinkCanonicalBase;
            tag.Value = TestData.LinkCanonical;

            var attributes = new[]
                                 {
                                     new TagHelperAttribute(nameof(tag.Base), LinkCanonicalBase),
                                     new TagHelperAttribute(nameof(tag.Value), TestData.LinkCanonical)
                                 };

            // Act
            var output = tag.Process(SeoLinkCanonicalTagHelper.TagName, attributes);

            // Assert
            var html = output.GetContent();
            bool htmlContainsLinkCanonicalBase = html.Contains(LinkCanonicalBase);

            Assert.True(htmlContainsLinkCanonicalBase);
        }

        [Fact]
        public void Process_WithAppRelativeLinkCanonicalAndLinkCanonicalBase_ReturnsHtmlNotContainingAppRelativeChar()
        {
            const string LinkCanonicalBase = "https://linkcanonical.co/base/";

            // Arrange
            var tag = GetSeoLinkCanonicalTagHelper();
            tag.Base = LinkCanonicalBase;
            tag.Value = TestData.AppRelativeLinkCanonical;

            var attributes = new[]
                                 {
                                     new TagHelperAttribute(nameof(tag.Base), LinkCanonicalBase),
                                     new TagHelperAttribute(nameof(tag.Value), TestData.AppRelativeLinkCanonical)
                                 };

            // Act
            var output = tag.Process(SeoLinkCanonicalTagHelper.TagName, attributes);

            // Assert
            var html = output.GetContent();
            bool htmlContainsAppRelativeChar = html.Contains("~");

            Assert.False(htmlContainsAppRelativeChar);
        }

        private static SeoLinkCanonicalTagHelper GetSeoLinkCanonicalTagHelper(Action<SeoHelper> seoHelperConfig = null)
        {
            var viewContext = ViewContextTestFactory.Create();
            var seoHelper = SeoHelperTestFactory.Create(viewContext);

            seoHelperConfig?.Invoke(seoHelper);

            var tag = new SeoLinkCanonicalTagHelper(seoHelper) { ViewContext = viewContext };
            return tag;
        }
    }
}
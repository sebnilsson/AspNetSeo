using AspNetSeo.CoreMvc.TagHelpers;
using AspNetSeo.Internal;
using AspNetSeo.Testing;
using Xunit;

namespace AspNetSeo.CoreMvc.Tests.TagHelpers;

public class SeoTagsTagHelperTest : TagHelperTestBase
{
    [Fact]
    public void Process_AllValues_RenderExpectedHtml()
    {
        // Arrange
        var tagHelper = TagHelperTestFactory.Create(
            seo => new SeoTagsTagHelper(seo, SeoUrlHelperTestFactory.Create()),
            seo =>
            {
                seo.PageTitle = "Test page";
                seo.SiteName = "Test site";
                seo.SiteUrl = "https://example.com/";
                seo.LinkCanonical = "~/test.html";
                seo.MetaDescription = "Desc";
                seo.MetaKeywords = "kw1,kw2";
                seo.SetMetaRobots(index: true, follow: false);
                seo.SetCustomMeta("x", "y");
                seo.OgAudio = "audio.mp3";
                seo.OgDeterminer = "the";
                seo.OgImage = "image.png";
                seo.OgLocale = "en_US";
                seo.OgLocaleAlternates = new[] { "da_DK", "de_DE" };
                seo.OgType = "website";
                seo.OgVideo = "video.mp4";
            });

        // Act
        var html = tagHelper.GetHtml("seo-tags");

        // Assert
        var expected =
            $"""
            <title>Test page - Test site</title>
            <link rel="canonical" href="https://example.com/test.html" />
            {MetaTag(MetaName.Description, "Desc", reverseAttributes: true)}
            {MetaTag(MetaName.Keywords, "kw1,kw2", reverseAttributes: true)}
            {MetaTag(MetaName.Robots, $"{MetaRobotsValue.Index}, {MetaRobotsValue.NoFollow}", reverseAttributes: true)}
            {MetaTag("x", "y")}
            {OpenGraphTag(OgMetaName.Audio, "audio.mp3")}
            {OpenGraphTag(OgMetaName.Description, "Desc")}
            {OpenGraphTag(OgMetaName.Determiner, "the")}
            {OpenGraphTag(OgMetaName.Image, "image.png")}
            {OpenGraphTag(OgMetaName.Locale, "en_US")}
            {OpenGraphTag(OgMetaName.LocaleAlternate, "da_DK", reverseAttributes: true)}
            {OpenGraphTag(OgMetaName.LocaleAlternate, "de_DE", reverseAttributes: true)}
            {OpenGraphTag(OgMetaName.SiteName, "Test site")}
            {OpenGraphTag(OgMetaName.Title, "Test page")}
            {OpenGraphTag(OgMetaName.Type, "website")}
            {OpenGraphTag(OgMetaName.Url, "https://example.com/test.html")}
            {OpenGraphTag(OgMetaName.Video, "video.mp4")}
            """.Trim();

        Assert.Equal(expected, html);
    }
}

namespace AspNetSeo;

/// <summary>
/// Provides properties for storing SEO related information used when rendering
/// HTML head tags.
/// </summary>
public interface ISeoHelper
{
    /// <summary>
    /// Gets a collection of additional meta tags to render.
    /// </summary>
    IDictionary<string, string?> CustomMetas { get; }

    /// <summary>
    /// Gets the combined document title for the page.
    /// </summary>
    string? DocumentTitle { get; }

    /// <summary>
    /// Gets or sets the format used to combine the page and site titles.
    /// The default value is "{0} - {1}".
    /// </summary>
    string? DocumentTitleFormat { get; set; }

    /// <summary>
    /// Gets or sets the canonical link for the page.
    /// </summary>
    string? LinkCanonical { get; set; }

    /// <summary>
    /// Gets or sets the meta description for the page.
    /// </summary>
    string? MetaDescription { get; set; }

    /// <summary>
    /// Gets or sets the meta keywords for the page.
    /// </summary>
    string? MetaKeywords { get; set; }

    /// <summary>
    /// Gets or sets the meta robots value for the page.
    /// </summary>
    string? MetaRobots { get; set; }

    /// <summary>
    /// Gets or sets the Open Graph audio URL for the page.
    /// </summary>
    string? OgAudio { get; set; }

    /// <summary>
    /// Gets or sets the Open Graph description for the page.
    /// </summary>
    string? OgDescription { get; set; }

    /// <summary>
    /// Gets or sets the Open Graph determiner for the page.
    /// </summary>
    string? OgDeterminer { get; set; }

    /// <summary>
    /// Gets or sets the Open Graph image URL for the page.
    /// </summary>
    string? OgImage { get; set; }

    /// <summary>
    /// Gets or sets the Open Graph locale for the page.
    /// </summary>
    string? OgLocale { get; set; }

    /// <summary>
    /// Gets the collection of alternate Open Graph locales for the page.
    /// </summary>
    IList<string> OgLocaleAlternates { get; }

    /// <summary>
    /// Gets or sets the Open Graph site name. Falls back to <see cref="SiteName"/>.
    /// </summary>
    string? OgSiteName { get; set; }

    /// <summary>
    /// Gets or sets the Open Graph title. Falls back to <see cref="PageTitle"/>.
    /// </summary>
    string? OgTitle { get; set; }

    /// <summary>
    /// Gets or sets the Open Graph type for the page.
    /// </summary>
    string? OgType { get; set; }

    /// <summary>
    /// Gets or sets the Open Graph URL. Falls back to <see cref="LinkCanonical"/>.
    /// </summary>
    string? OgUrl { get; set; }

    /// <summary>
    /// Gets or sets the Open Graph video URL for the page.
    /// </summary>
    string? OgVideo { get; set; }

    /// <summary>
    /// Gets or sets the page title.
    /// </summary>
    string? PageTitle { get; set; }

    /// <summary>
    /// Gets or sets the site name used when composing the document title.
    /// </summary>
    string? SiteName { get; set; }

    /// <summary>
    /// Gets or sets the base site URL used for resolving relative links.
    /// </summary>
    string? SiteUrl { get; set; }

    /// <summary>
    /// Adds or updates a custom meta tag.
    /// </summary>
    /// <param name="key">The name of the meta tag.</param>
    /// <param name="value">The value of the meta tag.</param>
    void SetCustomMeta(string key, string? value);

    /// <summary>
    /// Sets the meta robots value based on the supplied index and follow flags.
    /// </summary>
    /// <param name="index">Whether the page should be indexed.</param>
    /// <param name="follow">Whether links on the page should be followed.</param>
    /// <returns>The generated meta robots string.</returns>
    string SetMetaRobots(bool index, bool follow);
}


namespace AspNetSeo;

/// <summary>
/// Describes SEO-related values.
/// </summary>
public interface ISeoHelper
{
    /// <summary>Custom meta tags.</summary>
    IDictionary<string, string?> CustomMetas { get; }

    /// <summary>Computed document title.</summary>
    string? DocumentTitle { get; }

    /// <summary>Title format pattern.</summary>
    string? DocumentTitleFormat { get; set; }

    /// <summary>Canonical link.</summary>
    string? LinkCanonical { get; set; }

    /// <summary>Meta description.</summary>
    string? MetaDescription { get; set; }

    /// <summary>Meta keywords.</summary>
    string? MetaKeywords { get; set; }

    /// <summary>Meta robots value.</summary>
    string? MetaRobots { get; set; }

    /// <summary>Open Graph audio.</summary>
    string? OgAudio { get; set; }

    /// <summary>Open Graph description.</summary>
    string? OgDescription { get; set; }

    /// <summary>Open Graph determiner.</summary>
    string? OgDeterminer { get; set; }

    /// <summary>Open Graph image.</summary>
    string? OgImage { get; set; }

    /// <summary>Open Graph locale.</summary>
    string? OgLocale { get; set; }

    /// <summary>Alternate locales.</summary>
    IList<string> OgLocaleAlternates { get; }

    /// <summary>Open Graph site name.</summary>
    string? OgSiteName { get; set; }

    /// <summary>Open Graph title.</summary>
    string? OgTitle { get; set; }

    /// <summary>Open Graph type.</summary>
    string? OgType { get; set; }

    /// <summary>Open Graph URL.</summary>
    string? OgUrl { get; set; }

    /// <summary>Open Graph video.</summary>
    string? OgVideo { get; set; }

    /// <summary>Page title.</summary>
    string? PageTitle { get; set; }

    /// <summary>Site name.</summary>
    string? SiteName { get; set; }

    /// <summary>Site URL.</summary>
    string? SiteUrl { get; set; }

    /// <summary>Sets a custom meta tag.</summary>
    void SetCustomMeta(string key, string? value);

    /// <summary>Creates a robots value.</summary>
    /// <returns>The meta robots string.</returns>
    string SetMetaRobots(bool index, bool follow);
}


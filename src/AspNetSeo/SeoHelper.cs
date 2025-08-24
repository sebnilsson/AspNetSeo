using AspNetSeo.Internal;

namespace AspNetSeo;

/// <summary>
/// Concrete implementation of <see cref="ISeoHelper"/>.
/// </summary>
public class SeoHelper : ISeoHelper
{
    internal const string? DefaultDocumentTitleFormat = "{0} - {1}";

    /// <summary>Custom meta tags.</summary>
    public IDictionary<string, string?> CustomMetas { get; }
        = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);

    /// <summary>Calculated document title.</summary>
    public string? DocumentTitle => DocumentTitleValue.Get(this);

    /// <summary>Format pattern for the title.</summary>
    public string? DocumentTitleFormat { get; set; }
        = DefaultDocumentTitleFormat;

    /// <summary>Canonical link.</summary>
    public string? LinkCanonical { get; set; }

    /// <summary>Meta description.</summary>
    public string? MetaDescription { get; set; }

    /// <summary>Meta keywords.</summary>
    public string? MetaKeywords { get; set; }

    /// <summary>Meta robots value.</summary>
    public string? MetaRobots { get; set; }

    /// <summary>Open Graph audio.</summary>
    public string? OgAudio { get; set; }

    /// <summary>Open Graph description.</summary>
    public string? OgDescription { get; set; }

    /// <summary>Open Graph determiner.</summary>
    public string? OgDeterminer { get; set; }

    /// <summary>Open Graph image.</summary>
    public string? OgImage { get; set; }

    /// <summary>Open Graph locale.</summary>
    public string? OgLocale { get; set; }

    /// <summary>Alternate locales.</summary>
    public IList<string> OgLocaleAlternates { get; } = new List<string>();

    /// <summary>Open Graph site name.</summary>
    public string? OgSiteName { get; set; }

    /// <summary>Open Graph title.</summary>
    public string? OgTitle { get; set; }

    /// <summary>Open Graph type.</summary>
    public string? OgType { get; set; }

    /// <summary>Open Graph URL.</summary>
    public string? OgUrl { get; set; }

    /// <summary>Open Graph video.</summary>
    public string? OgVideo { get; set; }

    /// <summary>Page title.</summary>
    public string? PageTitle { get; set; }

    /// <summary>Site name.</summary>
    public string? SiteName { get; set; }

    /// <summary>Site URL.</summary>
    public string? SiteUrl { get; set; }

    /// <summary>Stores a custom meta tag.</summary>
    /// <param name="key">Meta name.</param>
    /// <param name="value">Meta value.</param>
    public void SetCustomMeta(string? key, string? value)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        CustomMetas[key] = value;
    }

    /// <summary>Sets the robots directive.</summary>
    /// <param name="index">Whether indexing is allowed.</param>
    /// <param name="follow">Whether following is allowed.</param>
    /// <returns>The robots string.</returns>
    public string SetMetaRobots(bool index, bool follow)
    {
        MetaRobots = MetaRobotsValue.Get(index, follow);

        return MetaRobots;
    }
}


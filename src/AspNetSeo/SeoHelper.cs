using AspNetSeo.Internal;
using System.Collections.Generic;

namespace AspNetSeo;

/// <summary>
/// Default implementation of <see cref="ISeoHelper"/> for storing SEO data.
/// </summary>
public class SeoHelper : ISeoHelper
{
    internal const string? DefaultDocumentTitleFormat = "{0} - {1}";

    /// <inheritdoc />
    public IDictionary<string, string?> CustomMetas { get; }
        = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);

    /// <inheritdoc />
    public string? DocumentTitle => DocumentTitleValue.Get(this);

    /// <inheritdoc />
    public string? DocumentTitleFormat { get; set; }
        = DefaultDocumentTitleFormat;

    /// <inheritdoc />
    public string? LinkCanonical { get; set; }

    /// <inheritdoc />
    public string? MetaDescription { get; set; }

    /// <inheritdoc />
    public string? MetaKeywords { get; set; }

    /// <inheritdoc />
    public string? MetaRobots { get; set; }

    /// <inheritdoc />
    public string? OgAudio { get; set; }

    /// <inheritdoc />
    public string? OgDescription { get; set; }

    /// <inheritdoc />
    public string? OgDeterminer { get; set; }

    /// <inheritdoc />
    public string? OgImage { get; set; }

    /// <inheritdoc />
    public string? OgLocale { get; set; }

    /// <inheritdoc />
    public IList<string> OgLocaleAlternates { get; } = new List<string>();

    /// <inheritdoc />
    public string? OgSiteName { get; set; }

    /// <inheritdoc />
    public string? OgTitle { get; set; }

    /// <inheritdoc />
    public string? OgType { get; set; }

    /// <inheritdoc />
    public string? OgUrl { get; set; }

    /// <inheritdoc />
    public string? OgVideo { get; set; }

    /// <inheritdoc />
    public string? PageTitle { get; set; }

    /// <inheritdoc />
    public string? SiteName { get; set; }

    /// <inheritdoc />
    public string? SiteUrl { get; set; }

    /// <inheritdoc />
    public void SetCustomMeta(string? key, string? value)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        CustomMetas[key] = value;
    }

    /// <inheritdoc />
    public string SetMetaRobots(bool index, bool follow)
    {
        MetaRobots = MetaRobotsValue.Get(index, follow);

        return MetaRobots;
    }
}


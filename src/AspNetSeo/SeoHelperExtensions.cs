namespace AspNetSeo;

/// <summary>
/// Helper extensions for SEO values.
/// </summary>
public static class SeoHelperExtensions
{
    private const string DefaultSeparator = ", ";

    /// <summary>Adds meta keywords.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    /// <param name="keywords">Keywords to add.</param>
    /// <returns>Combined keywords.</returns>
    public static string? AddMetaKeywords(
        this ISeoHelper seoHelper,
        params string[] keywords)
    {
        if (seoHelper == null)
            throw new ArgumentNullException(nameof(seoHelper));
        if (keywords == null)
            throw new ArgumentNullException(nameof(keywords));

        return seoHelper.AddMetaKeywordsWithSeparator(DefaultSeparator, keywords);
    }

    /// <summary>Adds meta keywords with a separator.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    /// <param name="separator">Separator string.</param>
    /// <param name="keywords">Keywords to add.</param>
    /// <returns>Combined keywords.</returns>
    public static string? AddMetaKeywordsWithSeparator(
        this ISeoHelper seoHelper,
        string separator,
        params string[] keywords)
    {
        if (seoHelper == null)
            throw new ArgumentNullException(nameof(seoHelper));
        if (separator == null)
            throw new ArgumentNullException(nameof(separator));
        if (keywords == null)
            throw new ArgumentNullException(nameof(keywords));

        foreach (var keyword in keywords)
        {
            var combinedMetaKeywords =
                CombineTexts(
                    separator,
                    seoHelper.MetaKeywords,
                    keyword);

            seoHelper.MetaKeywords = combinedMetaKeywords;
        }

        return seoHelper.MetaKeywords;
    }

    private static string? CombineTexts(
        string separator,
        params string?[] values)
    {
        var cleanedValues =
            values?
            .Select(x => x?.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();

        if (cleanedValues == null || !cleanedValues.Any())
        {
            return null;
        }

        return string.Join(separator, cleanedValues).Trim();
    }
}


namespace AspNetSeo.CoreMvc;

/// <summary>
/// Adds alternate Open Graph locales.
/// </summary>
/// <remarks>Initializes the attribute.</remarks>
/// <param name="values">Locale values.</param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class OgLocaleAlternateAttribute(params string[] values) : SeoAttributeBase
{
    private readonly string[] _values = values;

    /// <summary>Applies the locale alternates.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        var existing = seoHelper.OgLocaleAlternates ?? [];
        string[] combined = [.. existing, .. _values];
        seoHelper.OgLocaleAlternates = combined;
    }
}


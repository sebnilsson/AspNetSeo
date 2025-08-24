namespace AspNetSeo.CoreMvc;

/// <summary>
/// Adds alternate Open Graph locales.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class OgLocaleAlternateAttribute : SeoAttributeBase
{
    private readonly string[] _values;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="values">Locale values.</param>
    public OgLocaleAlternateAttribute(params string[] values)
    {
        _values = values;
    }

    /// <summary>Applies the locale alternates.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        foreach (var value in _values)
        {
            seoHelper.OgLocaleAlternates.Add(value);
        }
    }
}


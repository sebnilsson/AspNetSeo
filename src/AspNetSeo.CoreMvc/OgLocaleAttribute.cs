namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph locale.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgLocaleAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Locale value.</param>
    public OgLocaleAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the locale.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgLocale = _value;
    }
}


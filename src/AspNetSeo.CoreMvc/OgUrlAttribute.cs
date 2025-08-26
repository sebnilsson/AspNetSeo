namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph URL.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgUrlAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">URL value.</param>
    public OgUrlAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the URL.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgUrl = _value;
    }
}


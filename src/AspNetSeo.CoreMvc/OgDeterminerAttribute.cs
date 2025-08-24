namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph determiner.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgDeterminerAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Determiner value.</param>
    public OgDeterminerAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the determiner.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgDeterminer = _value;
    }
}


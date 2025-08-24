namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph image URL.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgImageAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Image URL.</param>
    public OgImageAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the image URL.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgImage = _value;
    }
}


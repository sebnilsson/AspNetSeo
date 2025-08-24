namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph type.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgTypeAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Type value.</param>
    public OgTypeAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the type.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgType = _value;
    }
}


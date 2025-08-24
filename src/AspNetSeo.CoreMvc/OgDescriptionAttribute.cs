namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph description.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgDescriptionAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Description text.</param>
    public OgDescriptionAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the description.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgDescription = _value;
    }
}


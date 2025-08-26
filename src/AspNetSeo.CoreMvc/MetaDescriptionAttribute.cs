namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the meta description.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class MetaDescriptionAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Meta description.</param>
    public MetaDescriptionAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the description.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.MetaDescription = _value;
    }
}


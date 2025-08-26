namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the canonical link.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class LinkCanonicalAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Canonical URL.</param>
    public LinkCanonicalAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the canonical link.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.LinkCanonical = _value;
    }
}


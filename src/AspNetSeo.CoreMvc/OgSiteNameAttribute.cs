namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph site name.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgSiteNameAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Site name.</param>
    public OgSiteNameAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the site name.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgSiteName = _value;
    }
}


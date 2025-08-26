namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the default site name.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class SiteNameAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Site name.</param>
    public SiteNameAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the site name.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.SiteName = _value;
    }
}


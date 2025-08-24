namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the default site URL.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class SiteUrlAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Site URL.</param>
    public SiteUrlAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the site URL.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.SiteUrl = _value;
    }
}


namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph title.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgTitleAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Title value.</param>
    public OgTitleAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the title.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgTitle = _value;
    }
}


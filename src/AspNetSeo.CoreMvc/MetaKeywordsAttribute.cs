namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the meta keywords.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class MetaKeywordsAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Meta keywords.</param>
    public MetaKeywordsAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the keywords.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.MetaKeywords = _value;
    }
}


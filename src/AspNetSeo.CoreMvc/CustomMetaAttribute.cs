namespace AspNetSeo.CoreMvc;

/// <summary>
/// Adds a custom meta tag.
/// </summary>
/// <param name="name">Meta name.</param>
/// <param name="content">Meta content.</param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class CustomMetaAttribute(string name, string content) : SeoAttributeBase
{
    private readonly string _name = name
            ?? throw new ArgumentNullException(nameof(name));

    private readonly string _content = content;

    /// <summary>Applies the custom meta.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.CustomMetas[_name] = _content;
    }
}


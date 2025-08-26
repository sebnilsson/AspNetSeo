namespace AspNetSeo.CoreMvc;

/// <summary>
/// Adds a custom meta tag.
/// </summary>
/// <param name="name">Meta name.</param>
/// <param name="content">Meta content.</param>
/// <param name="attribute">Explicit rendering attribute for the meta key.</param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class CustomMetaAttribute(string name, string content, CustomMetaAttributeKey? attribute = null)
    : SeoAttributeBase
{
    private readonly string _name = name
            ?? throw new ArgumentNullException(nameof(name));

    private readonly string _content = content;

    private readonly CustomMetaAttributeKey? _attribute = attribute;

    /// <summary>Applies the custom meta.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.SetCustomMeta(_name, _content, _attribute);
    }
}


namespace AspNetSeo;

/// <summary>
/// Represents a custom meta tag entry including its key, value and optional attribute selector.
/// </summary>
public class CustomMetaItem
{
    public CustomMetaItem(string key, string? value, CustomMetaAttributeKey? attribute = null)
    {
        Key = key ?? throw new ArgumentNullException(nameof(key));
        Value = value;
        Attribute = attribute;
    }

    /// <summary>The meta tag key.</summary>
    public string Key { get; }

    /// <summary>The meta tag value.</summary>
    public string? Value { get; set; }

    /// <summary>Explicit attribute to use when rendering the key. Null for auto detection.</summary>
    public CustomMetaAttributeKey? Attribute { get; set; }
}

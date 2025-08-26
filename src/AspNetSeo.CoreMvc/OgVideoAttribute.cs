namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph video URL.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgVideoAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Video URL.</param>
    public OgVideoAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the video URL.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgVideo = _value;
    }
}


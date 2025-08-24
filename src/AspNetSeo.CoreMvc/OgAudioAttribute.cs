namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the Open Graph audio URL.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgAudioAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute.</summary>
    /// <param name="value">Audio URL.</param>
    public OgAudioAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Applies the audio URL.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgAudio = _value;
    }
}


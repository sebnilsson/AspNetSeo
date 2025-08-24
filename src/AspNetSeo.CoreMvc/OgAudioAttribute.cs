namespace AspNetSeo.CoreMvc;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgAudioAttribute : SeoAttributeBase
{
    private readonly string _value;

    public OgAudioAttribute(string value)
    {
        _value = value;
    }

    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgAudio = _value;
    }
}

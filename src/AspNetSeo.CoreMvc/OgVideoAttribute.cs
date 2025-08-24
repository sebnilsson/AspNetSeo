namespace AspNetSeo.CoreMvc;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgVideoAttribute : SeoAttributeBase
{
    private readonly string _value;

    public OgVideoAttribute(string value)
    {
        _value = value;
    }

    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgVideo = _value;
    }
}

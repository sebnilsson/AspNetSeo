namespace AspNetSeo.CoreMvc;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgDeterminerAttribute : SeoAttributeBase
{
    private readonly string _value;

    public OgDeterminerAttribute(string value)
    {
        _value = value;
    }

    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgDeterminer = _value;
    }
}

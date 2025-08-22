namespace AspNetSeo.CoreMvc;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class OgLocaleAttribute : SeoAttributeBase
{
    private readonly string _value;

    public OgLocaleAttribute(string value)
    {
        _value = value;
    }

    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.OgLocale = _value;
    }
}

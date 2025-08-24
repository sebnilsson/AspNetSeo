namespace AspNetSeo.CoreMvc;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class OgLocaleAlternateAttribute : SeoAttributeBase
{
    private readonly string[] _values;

    public OgLocaleAlternateAttribute(params string[] values)
    {
        _values = values;
    }

    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        foreach (var value in _values)
        {
            seoHelper.OgLocaleAlternates.Add(value);
        }
    }
}

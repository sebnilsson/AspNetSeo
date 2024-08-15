namespace AspNetSeo.CoreMvc;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class CustomMetaAttribute(string name, string content) : SeoAttributeBase
{
    private readonly string _name = name
            ?? throw new ArgumentNullException(nameof(name));

    private readonly string _content = content;

    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.CustomMetas[_name] = _content;
    }
}

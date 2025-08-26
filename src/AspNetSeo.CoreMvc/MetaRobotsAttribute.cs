using AspNetSeo.Internal;

namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the meta robots value.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class MetaRobotsAttribute : SeoAttributeBase
{
    private readonly string _value;

    /// <summary>Initializes the attribute with a value.</summary>
    /// <param name="value">Robots value.</param>
    public MetaRobotsAttribute(string value)
    {
        _value = value;
    }

    /// <summary>Initializes the attribute with flags.</summary>
    /// <param name="index">Allow indexing.</param>
    /// <param name="follow">Allow following.</param>
    public MetaRobotsAttribute(bool index, bool follow)
    {
        _value = MetaRobotsValue.Get(index, follow);
    }

    /// <summary>Applies the robots value.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.MetaRobots = _value;
    }
}


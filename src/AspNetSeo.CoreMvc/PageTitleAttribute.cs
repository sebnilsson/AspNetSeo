namespace AspNetSeo.CoreMvc;

/// <summary>
/// Sets the page title.
/// </summary>
/// <param name="value">Page title.</param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class PageTitleAttribute(string value) : SeoAttributeBase
{
    private readonly string _value = value;

    /// <summary>Optional title format.</summary>
    public string? Format { get; set; }

    /// <summary>Whether to clear the site name.</summary>
    public bool OverrideSiteName { get; set; }

    /// <summary>Applies the page title.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    public override void OnHandleSeoValues(ISeoHelper seoHelper)
    {
        seoHelper.PageTitle = _value;

        if (Format != null)
        {
            seoHelper.DocumentTitleFormat = Format;
        }
        if (OverrideSiteName)
        {
            seoHelper.SiteName = null;
        }
    }
}


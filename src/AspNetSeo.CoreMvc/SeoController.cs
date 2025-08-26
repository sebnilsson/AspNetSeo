using Microsoft.AspNetCore.Mvc;

namespace AspNetSeo.CoreMvc;

/// <summary>
/// Base controller providing <see cref="ISeoHelper"/> access.
/// </summary>
public abstract class SeoController : Controller
{
    private readonly Lazy<ISeoHelper> seoLazy;

    /// <summary>Gets the SEO helper.</summary>
    public ISeoHelper Seo => seoLazy.Value;

    /// <summary>Initializes the controller.</summary>
    protected SeoController()
    {
        seoLazy = new Lazy<ISeoHelper>(this.GetSeoHelper);
    }
}


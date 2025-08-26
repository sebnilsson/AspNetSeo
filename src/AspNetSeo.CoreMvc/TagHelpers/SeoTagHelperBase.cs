using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSeo.CoreMvc.TagHelpers;

/// <summary>
/// Base tag helper with access to <see cref="ISeoHelper"/>.
/// </summary>
public abstract class SeoTagHelperBase : TagHelper
{
    /// <summary>The SEO helper instance.</summary>
    protected readonly ISeoHelper SeoHelper;

    /// <summary>Initializes the helper.</summary>
    /// <param name="seoHelper">The SEO helper.</param>
    protected SeoTagHelperBase(ISeoHelper seoHelper)
    {
        SeoHelper = seoHelper
            ?? throw new ArgumentNullException(nameof(seoHelper));
    }
}


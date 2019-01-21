# ASP.NET SEO

Helpers for handling the SEO-data for ASP.NET web-applications.

Provides a `SeoHelper`-class which is easily accessible in `Controllers`, `Views` and through `ActionFilterAttributes`.

## SeoHelper

### Properties

The `SeoHelper`-class exposes multiple properties to get or set multiple SEO-related data:

- `LinkCanonical`: Gets or sets the canonical link for web-page.
  - `SiteUrl`: Gets or sets the main URL for web-site. Used as base for the canonical link.
- `MetaDescription`: Gets or sets the meta-description for web-page.
- `MetaKeywords`: Gets or sets the meta-keywords for web-page.
- `MetaRobots`: Gets or sets meta-robots instructions web-page.
- `OgDescription`: Gets or sets the open graph description for web-page.
Falls back on value in `MetaDescription`.
- `OgImage`: Gets or sets the open graph image for web-page.
- `OgSiteName`: Gets or sets the open graph site-name for web-page.
Falls back on value in `SiteName`.
- `OgTitle`: Gets or sets the open graph title for web-page.
Falls back on value in `PageTitle`.
- `OgType`: Gets or sets the open graph type for web-page.
- `OgUrl`: Gets or sets the open graph URL for web-page.
Falls back on value in `LinkCanonical`.
- `PageTitle`: Gets or sets the title for a web-page.
  - `SiteName`: Gets or sets the name for the web-site. Used as base for `DocumentTitle`.

- `DocumentTitle`: Gets the document-title for a web-page. Combines `PageTitle` and `SiteName`.
  - `DocumentTitleFormat`: Gets or sets the format for the document-title. Default value is `{0} - {1}`,
where `{0}` is the value from `PageTitle` and `{1}` is the value from `SiteName`.

### Methods

- `SetCustomMeta(string key, string value)`: Add any custom meta-tag.
- `SetMetaRobots(bool index, bool follow)`: Specify the instructions for robots.
Updates the value for `MetaRobots`.

### Notes

`LinkCanonical` can be set as **absolute URL** (`https://example.com/section/page.html`), 
as a **relative URL** (`/section/page.html`) or using **ASP.NET's app-relative URL-format** (`~/section.page.html`).
**Relative URLs will automatically get converted to absolute URLs**, either from provided `SiteUrl`
or from the base of the requested URL.

## ActionFilterAttributes

The properties exposed by the `SeoHelper`-class all have corresponding
action-filter-attributes are available for Controllers and Controller-actions.

For example, `[PageTitle]` can be used for an action, if no logic is needed for the value,
while `[SiteName]` can be used for a controller. Using another `[SiteName]`-attribute on
an action will override the one used on the controller.

Examples of attribute-usage:

```
[SiteName("Website name")]
[SiteUrl("https://production-url.co/")]
public class InfoController : SeoController
{
    [PageTitle("Listing items")]
    [MetaDescription("List of the company's product-items")]
    public ActionResult List()
    {
        var list = GetList();
        
        if (list.Any())
        {
            Seo.PageTitle += $" (Total: {list.Count})";
            Seo.LinkCanonical = "~/pages/list.html";
        }
        else
        {
            Seo.SetMetaRobots(index: false, follow: true);
        }

        return View(model);
    }
}
```

## ASP.NET Core MVC

### Configuration

To register the SEO-helper as a service for Dependency Injection you just need to use the framework's provided extension-method
in the `ConfigureServices` method inside `Startup.cs`:

```
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddSeoHelper();
    }
}
```

### Accessing the `SeoHelper`-class

With the configured Dependency Injection you can access the `SeoHelper`-class through **constructor-injection** or
by accessing the [`RequestServices`-object](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection#request-services)
in the `HttpContext`.

The framework provides an extension-method for `IServiceProvider` for getting the `SeoHelper`-instance:

```
public IActionResult Edit()
{
    var seoHelper = HttpContext.RequestServices.GetSeoHelper();
    // ...
}
```

### Tag Helpers

Tag Helpers are available to render the values set through the `SeoHelper`-class.
They also expose **attributes to override or set the values on the fly** in the markup.

Examples: `<document-title />` renders the combined `PageTitle` and `SiteName`. 
`<link-canonical />` renders the canonical URL for the page.
`<og-url />` renders the set URL for the page and falls back to value used in `<link-canonical />`.

**Individual tags will not be rendered if there is no valid data provided for them**,
either through the `SeoHelper`-class or exposed attributes.

### Setting default values

To set the webb-application’s default base-title and default base canonical link, which can be overridden if needed,
the configuration during registering the service for Dependency Injection can be used:

```
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddSeoHelper(
        siteName: "Website name",
        siteUrl: "https://production-url.co/");
}

```

## ASP.NET MVC

**Support for classic ASP.NET MVC is deprecated.**
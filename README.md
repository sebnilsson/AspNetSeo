# ASP.NET SEO

Helpers for handling the SEO-data for ASP.NET web-applications.

Provides a `SeoHelper`-class which is easily accessible in `Controllers`, `Views` and through `ActionFilterAttributes`.

## SeoHelper

The `SeoHelper`-class exposes multiple properties to get or set multiple SEO-related data:

- `LinkCanonical`: Gets or sets the canonical link for a web-page.
  - `BaseLinkCanonical`: Gets or sets the base for the canonical link.
- `MetaDescription`: Gets or sets the meta-description for a web-page.
- `MetaKeywords`: Gets or sets the meta-keywords for a web-page.
- `MetaRobotsIndex`: Gets or sets how robots should index a web-page. The available settings are:
  - `IndexNoFollow`
  - `NoIndexFollow`
  - `NoIndexNoFollow`
- `MetaRobotsNoIndex`: Gets or sets that a web-page should not be indexed by robots.
- `Title`: Gets or sets the title for a web-page.
  - `BaseTitle`: Gets or sets the base for the title.
- `TitleFormat`: Gets or sets the format for the title. Default value is `{0} - {1}`,
where `{0}` is the value from `Title` and `{1}` is the value from `BaseTitle`.

`LinkCanonical` can be set as **absolute URL** (`https://example.com/section/page.html`), 
as a **relative URL** (`/section/page.html`) or using **ASP.NET's app-relative URL-format** (`~/section.page.html`).
**Relative URLs will automatically get converted to absolute URLs.**

## ActionFilterAttributes

The following action-filter-attributes are available for Controllers and Controller-actions to set value on the `SeoHelper`-class:

- `[SeoLinkCanonical]`: Sets the value for canonical link
  - `[SeoBaseLinkCanonical]`: Sets the base-value for canonical link
- `[SeoMetaDescription]`: Sets the meta-description
- `[SeoMetaKeywords]`: Sets the meta-keywords
- `[SeoMetaRobotsIndex]`: Sets the value for a meta-tag which tells Robots how to index
- `[SeoMetaRobotsNoIndex]`: Sets the value for a meta-tag which tells Robots not to index
- `[SeoTitle]`: Sets the page-title
  - `[SeoBaseTitle]`: Sets the base-title

Examples of attribute-usage:

```
[SeoBaseTitle("Website name")]
[SeoBaseLinkCanonical("https://production-url.co/")]
public class InfoController : SeoController
{
    [SeoTitle("Listing items")]
    [SeoMetaDescription("List of the company's product-items")]
    public ActionResult List()
    {
        var list = this.GetList();
        
        if (list.Any())
        {
            this.Seo.Title += $" (Total: {list.Count})";
            this.Seo.LinkCanonical = "~/pages/list.html";
        }
        else
        {
            this.Seo.MetaRobotsNoIndex = true;
        }

        return this.View(model);
    }
}
```

If the `SeoBaseTitle`-attribute is used in a controller the text from the `GlobalFilterCollection` or
in the Dependency Injection-configuration will be overridden.

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

With the configured Dependency Injection you can access the `SeoHelper`-class through constructor-injection or
by accessing the [`RequestServices`-object](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection#request-services)
in the `HttpContext`.

The framework provides an extension-method for `IServiceProvider` for getting the `SeoHelper`-instance:

```
public IActionResult Edit()
{
    var seoHelper = this.HttpContext.RequestServices.GetSeoHelper();
    // ...
}
```

### Tag Helpers

The following Tag Helpers are available to render HTML-tags containing SEO-data:

- `<seo-link-canonical />`: Renders the HTML-tag for canonical link,
combining the values from `LinkCanonical` and `BaseLinkCanonical`
- `<seo-meta-description />`: Renders the HTML-tag for the meta-description
- `<seo-meta-keywords />`: Renders the HTML-tag for the meta-keywords
- `<seo-meta-robots-index />`: Renders the HTML-tag for the meta-tag which tells Robots how to index
- `<seo-title />`: Renders the HTML-tag for the page-title,
combining the value from `Title` and `BaseTitle`, using the `TitleFormat` for structure

`<seo-title />`: If only `Title` or `BaseTitle` is set, only that text will be used, without the `TitleFormat`.

`<seo-link-canonical />`: If `LinkCanonical` is not set, no value will be output by HTML-helper.

**Individual tags will not be rendered if there is no valid data for them in the `SeoHelper`.**

### Setting default values

To set the webb-application’s default base-title and default base canonical link, which can be overridden if needed,
the configuration during registering the service for Dependency Injection can be used:

```
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddSeoHelper(
        baseTitle: "Website name",
        baseLinkCanonical: "https://production-url.co/");
}

```

## ASP.NET MVC

### Accessing the SeoHelper-class

The class can be accessed through **extension-methods** or **class-inheritence**.

#### Extension methods

The **extension-method** `GetSeoHelper` is exposed for `ControllerBase` and `WebViewPage`
(more exactly, for `IViewDataContainer`):

```
// Controller
public ActionResult Edit()
{
    var model = this.GetModel();

    var seoHelper = this.GetSeoHelper();
    
    seoHelper.Title = $"Edit {model.Name}";
    seoHelper.LinkCanonical =
        this.Url.Action("Action", "Controller", new { Id = model.Id });
    seoHelper.MetaRobotsNoIndex = model.IsPrivate;
    
    return this.View(model);
}
```

```
@* View *@
@using AspNetMvcSeo
@{
    var seoHelper = this.GetSeoHelper();

    seoHelper.MetaRobotsNoIndex = true;
}
```

#### Inheritence

If you make your `Controller` **inherit** from `SeoController` or make your views use `SeoWebViewPage` as `pageBaseType`,
you can access `SeoHelper` through a `Seo`-property:

```
// Controller
public ActionResult Edit()
{
    this.Seo.Title = "Current page title";
    // ...
}
```

```
@* View *@
@{
    this.Seo.MetaRobotsNoIndex = true;
    // ...
}
```

To configure Views to use `SeoWebViewPage` as `pageBaseType`, change the following in the `Web.config`-file
inside the `Views`-directory:

```
<configuration>
    <!-- ... -->
    <system.web.webPages.razor>
        <!-- ... -->
        <pages pageBaseType="AspNetMvcSeo.SeoWebViewPage">
    <!-- ... -->
```

### HtmlHelper-extensions

The following `HtmlHelper`-extensions are available to render HTML-tags containing SEO-data:

- `Html.SeoLinkCanonical()`: Renders the HTML-tag for canonical link,
combining the values from `LinkCanonical` and `BaseLinkCanonical`
- `Html.SeoMetaDescription()`: Renders the HTML-tag for the meta-description
- `Html.SeoMetaKeywords()`: Renders the HTML-tag for the meta-keywords
- `Html.SeoMetaRobotsIndex()`: Renders the HTML-tag for the meta-tag which tells Robots how to index
- `Html.SeoTitle()`: Renders the HTML-tag for the page-title,
combining the value from `Title` and `BaseTitle`, using the `TitleFormat` for structure

`Html.SeoTitle()`: If only `Title` or `BaseTitle` is set, only that text will be used, without the `TitleFormat`.

`Html.SeoLinkCanonical()`: If `LinkCanonical` is not set, no value will be output by HTML-helper.

**Individual tags will not be rendered if there is no valid data for them in the `SeoHelper`.**

```
@* View *@
<head>
    @Html.SeoTitle()
    
    @Html.SeoLinkCanonical()
    @Html.SeoMetaDescription()
    @Html.SeoMetaKeywords()
    @Html.SeoMetaRobotsIndex()
</head>
```

### Global filters for defaults

To set the webb-application's **default base-title** and **default base canonical link**, which can be overridden if needed,
the use of `GlobalFilterCollection` can be used together with the corresponding attribute:

```
public static class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new SeoBaseTitleAttribute("Website name"));
        filters.Add(new SeoBaseLinkCanonicalAttribute("https://examplewebsite.co"));
    }
}
```

If any of the attributes are used in a controller, these values will be overridden.

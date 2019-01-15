using System.Collections.Generic;

namespace AspNetSeo
{
    public interface ISeoHelper
    {
        string DocumentTitle { get; }

        string DocumentTitleFormat { get; set; }

        string LinkCanonical { get; set; }

        string MetaDescription { get; set; }

        string MetaKeywords { get; set; }

        string MetaRobots { get; set; }

        IDictionary<string, string> Metas { get; }

        string OgDescription { get; set; }

        string OgImage { get; set; }

        string OgSiteName { get; set; }

        string OgTitle { get; set; }

        string OgType { get; set; }

        string OgUrl { get; set; }

        string PageTitle { get; set; }

        string SiteName { get; set; }

        string SiteUrl { get; set; }

        string SetMetaRobots(bool index, bool follow);
    }
}
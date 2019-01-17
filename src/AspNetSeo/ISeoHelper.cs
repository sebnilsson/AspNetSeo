using System.Collections.Generic;

namespace AspNetSeo
{
    public interface ISeoHelper
    {
        IDictionary<string, string> CustomMetas { get; }

        string DocumentTitle { get; }

        string DocumentTitleFormat { get; set; }

        string LinkCanonical { get; set; }

        string MetaDescription { get; set; }

        string MetaKeywords { get; set; }

        string MetaRobots { get; set; }

        string OgDescription { get; set; }

        string OgImage { get; set; }

        string OgSiteName { get; set; }

        string OgTitle { get; set; }

        string OgType { get; set; }

        string OgUrl { get; set; }

        string PageTitle { get; set; }

        string SiteName { get; set; }

        string SiteUrl { get; set; }

        void SetCustomMeta(string key, string value);

        string SetMetaRobots(bool index, bool follow);
    }
}
using System;
using System.Collections.Generic;

using AspNetSeo.Internal;

namespace AspNetSeo
{
    public class SeoHelper : ISeoHelper
    {
        internal const string DefaultDocumentTitleFormat = "{0} - {1}";

        public IDictionary<string, string> CustomMetas { get; }
            = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public string DocumentTitle => DocumentTitleValue.Get(this);

        public string DocumentTitleFormat { get; set; }
            = DefaultDocumentTitleFormat;

        public string LinkCanonical { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaRobots { get; set; }

        public string OgDescription { get; set; }

        public string OgImage { get; set; }

        public string OgSiteName { get; set; }

        public string OgTitle { get; set; }

        public string OgType { get; set; }

        public string OgUrl { get; set; }

        public string PageTitle { get; set; }

        public string SiteName { get; set; }

        public string SiteUrl { get; set; }

        public void SetCustomMeta(string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            CustomMetas[key] = value;
        }

        public string SetMetaRobots(bool index, bool follow)
        {
            MetaRobots = MetaRobotsValue.Get(index, follow);

            return MetaRobots;
        }
    }
}
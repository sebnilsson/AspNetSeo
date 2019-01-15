using System;
using System.Collections.Generic;

using AspNetSeo.Internal;

namespace AspNetSeo
{
    public class SeoHelper : ISeoHelper
    {
        internal const string DefaultDocumentTitleFormat = "{0} - {1}";

        private bool _metaRobotsFollow = true;
        private bool _metaRobotsIndex = true;

        public string DocumentTitle => DocumentTitleValue.Get(this);

        public string DocumentTitleFormat { get; set; }
            = DefaultDocumentTitleFormat;

        public string LinkCanonical { get; set; }

        public string MetaDescription
        {
            get => GetMeta(MetaName.Description);
            set => SetMeta(MetaName.Description, value);
        }

        public string MetaKeywords
        {
            get => GetMeta(MetaName.Keywords);
            set => SetMeta(MetaName.Keywords, value);
        }

        public string MetaRobots
        {
            get => GetMeta(MetaName.Robots);
            set => SetMeta(MetaName.Robots, value);
        }

        public IDictionary<string, string> Metas { get; }
            = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public string OgDescription
        {
            get => GetMeta(OgMetaName.Description);
            set => SetMeta(OgMetaName.Description, value);
        }

        public string OgImage
        {
            get => GetMeta(OgMetaName.Image);
            set => SetMeta(OgMetaName.Image, value);
        }

        public string OgSiteName
        {
            get => GetMeta(OgMetaName.SiteName);
            set => SetMeta(OgMetaName.SiteName, value);
        }

        public string OgTitle
        {
            get => GetMeta(OgMetaName.Title);
            set => SetMeta(OgMetaName.Title, value);
        }

        public string OgType
        {
            get => GetMeta(OgMetaName.Type);
            set => SetMeta(OgMetaName.Type, value);
        }

        public string OgUrl
        {
            get => GetMeta(OgMetaName.Url);
            set => SetMeta(OgMetaName.Url, value);
        }

        public string PageTitle { get; set; }

        public string SiteName { get; set; }

        public string SiteUrl { get; set; }

        public string SetMetaRobots(bool index, bool follow)
        {
            MetaRobots = MetaRobotsValue.Get(index, follow);

            return MetaRobots;
        }

        private string GetMeta(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return Metas.ContainsKey(key) ? Metas[key] : null;
        }

        private void SetMeta(string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Metas[key] = value;
        }
    }
}
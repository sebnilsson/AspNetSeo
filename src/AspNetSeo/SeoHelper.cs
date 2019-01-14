using System;
using System.Linq;

namespace AspNetSeo
{
    public class SeoHelper
    {
        internal const string DefaultTitleFormat = "{0} - {1}";

        public string BaseLinkCanonical { get; set; }

        public string BaseTitle { get; set; }

        public string LinkCanonical { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public RobotsIndex? MetaRobotsIndex { get; set; }

        public bool MetaRobotsNoIndex
        {
            get
            {
                return (MetaRobotsIndex == RobotsIndexManager.DefaultRobotsNoIndex);
            }
            set
            {
                var metaRobotsIndex = value ? RobotsIndexManager.DefaultRobotsNoIndex : (RobotsIndex?)null;

                MetaRobotsIndex = metaRobotsIndex;
            }
        }

        public string OgDescription { get; set; }

        public string OgImage { get; set; }

        public string OgSiteName { get; set; }

        public string OgTitle { get; set; }

        public string OgType { get; set; }

        public string OgUrl { get; set; }

        public string Title { get; set; }

        public string TitleFormat { get; set; } = DefaultTitleFormat;

        public string AddMetaKeyword(string addedKeyword)
        {
            if (addedKeyword == null)
            {
                throw new ArgumentNullException(nameof(addedKeyword));
            }

            string combinedMetaKeywords = CombineTexts(" ", MetaKeywords, addedKeyword);

            MetaKeywords = combinedMetaKeywords;

            return combinedMetaKeywords;
        }

        private static string CombineTexts(
            string separator,
            params string[] values)
        {
            var cleanedValues =
                values?
                .Select(x => x?.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if (cleanedValues == null || !cleanedValues.Any())
            {
                return null;
            }

            return string.Join(separator, cleanedValues).Trim();
        }
    }
}
namespace AspNetSeo.Internal
{
    internal static class MetaRobotsValue
    {
        public static string Get(bool index, bool follow)
        {
            var indexValue = index ? "INDEX" : "NOINDEX";
            var followValue = follow ? "FOLLOW" : "NOFOLLOW";

            return $"{indexValue}, {followValue}";
        }
    }
}
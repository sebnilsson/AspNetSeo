using System;

namespace AspNetSeo
{
    public static class RobotsIndexManager
    {
        public const RobotsIndex DefaultRobotsNoIndex = RobotsIndex.NoIndexFollow;

        public const string IndexNoFollowMetaContent = "INDEX, NOFOLLOW";

        public const string NoIndexFollowMetaContent = "NOINDEX, FOLLOW";

        public const string NoIndexNoFollowMetaContent = "NOINDEX, NOFOLLOW";

        public static string GetMetaContent(RobotsIndex robotsIndex)
        {
            switch (robotsIndex)
            {
                case RobotsIndex.IndexNoFollow:
                    return IndexNoFollowMetaContent;
                case RobotsIndex.NoIndexFollow:
                    return NoIndexFollowMetaContent;
                case RobotsIndex.NoIndexNoFollow:
                    return NoIndexNoFollowMetaContent;
                default:
                    string message = $"No mapping found for {nameof(RobotsIndex)} value '{robotsIndex}'.";
                    throw new ArgumentOutOfRangeException(nameof(robotsIndex), message);
            }
        }
    }
}
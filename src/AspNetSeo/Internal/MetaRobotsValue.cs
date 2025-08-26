namespace AspNetSeo.Internal;

internal static class MetaRobotsValue
{
    public const string Follow = "follow";

    public const string Index = "index";

    public const string NoFollow = "nofollow";

    public const string NoIndex = "noindex";

    public static string Get(bool index, bool follow)
    {
        var indexValue = index ? Index : NoIndex;
        var followValue = follow ? Follow : NoFollow;

        return $"{indexValue}, {followValue}";
    }
}

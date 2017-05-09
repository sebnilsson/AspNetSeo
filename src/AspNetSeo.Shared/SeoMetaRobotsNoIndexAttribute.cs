using System;

#if NETSTANDARD
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaRobotsNoIndexAttribute : SeoMetaRobotsIndexAttribute
    {
        public SeoMetaRobotsNoIndexAttribute()
            : base(RobotsIndexManager.DefaultRobotsNoIndex)
        {
        }
    }
}
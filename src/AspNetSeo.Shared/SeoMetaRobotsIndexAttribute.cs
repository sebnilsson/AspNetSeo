using System;

#if COREMVC
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaRobotsIndexAttribute : SeoAttributeBase
    {
        private readonly RobotsIndex? _robotsIndex;

        public SeoMetaRobotsIndexAttribute(RobotsIndex robotsIndex)
        {
            _robotsIndex = robotsIndex;
        }

        public SeoMetaRobotsIndexAttribute()
        {
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.MetaRobotsIndex = _robotsIndex;
        }
    }
}
using System;

#if NETSTANDARD
namespace AspNetSeo.CoreMvc
#else
namespace AspNetSeo.Mvc
#endif
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaRobotsIndexAttribute : SeoAttributeBase
    {
        private readonly RobotsIndex? robotsIndex;

        public SeoMetaRobotsIndexAttribute(RobotsIndex robotsIndex)
        {
            this.robotsIndex = robotsIndex;
        }

        public SeoMetaRobotsIndexAttribute()
        {
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.MetaRobotsIndex = this.robotsIndex;
        }
    }
}
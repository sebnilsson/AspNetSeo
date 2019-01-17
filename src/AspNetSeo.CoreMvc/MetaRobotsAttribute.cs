using System;

using AspNetSeo.Internal;

namespace AspNetSeo.CoreMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MetaRobotsAttribute : SeoAttributeBase
    {
        private readonly string _value;

        public MetaRobotsAttribute(string value)
        {
            _value = value;
        }

        public MetaRobotsAttribute(bool index, bool follow)
        {
            _value = MetaRobotsValue.Get(index, follow);
        }

        public override void OnHandleSeoValues(ISeoHelper seoHelper)
        {
            seoHelper.MetaRobots = _value;
        }
    }
}
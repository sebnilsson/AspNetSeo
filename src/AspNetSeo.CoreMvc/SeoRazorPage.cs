using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AspNetSeo.CoreMvc
{
    public class SeoRazorPage : RazorPage
    {
        [RazorInject]
        public ISeoHelper Seo { get; private set; }

        public override Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}
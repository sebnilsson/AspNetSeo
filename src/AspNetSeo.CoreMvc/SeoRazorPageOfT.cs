using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AspNetSeo.CoreMvc
{
    public class SeoRazorPage<T> : RazorPage<T>
    {
        [RazorInject]
        public ISeoHelper Seo { get; set; }

        public override Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}
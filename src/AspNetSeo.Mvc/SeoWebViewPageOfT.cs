using System.Web.Mvc;

namespace AspNetSeo.Mvc
{
    public class SeoWebViewPage<TModel> : WebViewPage<TModel>
    {
        public SeoHelper Seo { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();

            Seo = this.GetSeoHelper();
        }

        public override void Execute()
        {
        }
    }
}
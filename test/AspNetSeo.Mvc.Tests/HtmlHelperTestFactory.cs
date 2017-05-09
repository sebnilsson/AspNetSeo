using System.Web.Mvc;

using Moq;

namespace AspNetSeo.Mvc.Tests
{
    public static class HtmlHelperTestFactory
    {
        public static HtmlHelper Create(ViewContext viewContext = null)
        {
            viewContext = viewContext ?? ViewContextTestFactory.Create();

            var viewDataContainer = new Mock<IViewDataContainer>();
            viewDataContainer.Setup(x => x.ViewData).Returns(viewContext.ViewData);

            var htmlHelper = new HtmlHelper(viewContext, viewDataContainer.Object);
            return htmlHelper;
        }
    }
}
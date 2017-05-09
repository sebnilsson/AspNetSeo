using System.IO;
using System.Web.Mvc;
using System.Web.Routing;

using Moq;

namespace AspNetSeo.Mvc.Tests
{
    public static class ViewContextTestFactory
    {
        public static ViewContext Create()
        {
            var requestContext = RequestContextTestFactory.Create();

            var controller = new Mock<ControllerBase>();
            var textWriter = new Mock<TextWriter>();

            var routeData = new RouteData();
            var tempData = new TempDataDictionary();
            var controllerContext = new ControllerContext(requestContext.HttpContext, routeData, controller.Object);

            var view = new Mock<IView>();
            var viewData = new ViewDataDictionary();

            var viewContext = new Mock<ViewContext>(
                controllerContext,
                view.Object,
                viewData,
                tempData,
                textWriter.Object);

            viewContext.Setup(x => x.HttpContext).Returns(requestContext.HttpContext);
            viewContext.Setup(x => x.ViewData).Returns(viewData);

            return viewContext.Object;
        }
    }
}
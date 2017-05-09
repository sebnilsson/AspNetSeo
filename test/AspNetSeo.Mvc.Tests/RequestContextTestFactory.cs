using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

using Moq;

namespace AspNetSeo.Mvc.Tests
{
    public static class RequestContextTestFactory
    {
        public const string Domain = "https://testdomain.co/";

        private static readonly Uri DomainUri = new Uri($"{Domain}testing/test.html?test1=123&test2=ABC");

        public static RequestContext Create()
        {
            var items = new Dictionary<object, object>();
            var request = new Mock<HttpRequestBase>();
            request.Setup(x => x.Url).Returns(DomainUri);
            request.Setup(x => x.ApplicationPath).Returns("/");

            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(x => x.Items).Returns(items);
            httpContext.Setup(x => x.Request).Returns(request.Object);

            var routeData = new RouteData();

            var requestContext = new RequestContext(httpContext.Object, routeData);
            return requestContext;
        }
    }
}
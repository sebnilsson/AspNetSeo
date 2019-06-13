using System;
using System.Collections.Generic;

using AspNetSeo.CoreMvc;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetSeo.Testing
{
    public static class ServiceProviderTestFactory
    {
        public static IServiceProvider Create()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSeoHelper();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        private class ServiceCollection
            : List<ServiceDescriptor>, IServiceCollection
        {
        }
    }
}
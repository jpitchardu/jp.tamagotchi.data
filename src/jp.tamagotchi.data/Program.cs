using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;
using jp.tamagotchi.data.Registry;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jp.tamagotchi.data
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();

            var container = new ContainerBuilder()
                .RegisterConfiguration()
                .RegisterDataAccess()
                .RegisterServer()
                .Build();

            var serviceProvider = new AutofacServiceProvider(container);

            var server = container.Resolve<Server>();

            server.Start();

            server.Stop().Wait();

            Console.ReadLine();

        }
    }
}
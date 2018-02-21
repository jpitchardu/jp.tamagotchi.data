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

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", true, true)
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();

            var container = new ContainerBuilder()
                .RegisterDataAccess(configuration)
                .Build();

            var serviceProvider = new AutofacServiceProvider(container);

            var server = new Server(configuration);

            server.Start();

            server.Stop().Wait();

            Console.ReadLine();

        }
    }
}
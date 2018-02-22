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

            var container = new ContainerBuilder()
                .PopulateServices(
                    services => services.AddLogging()
                )
                .RegisterConfiguration()
                .RegisterDataAccess()
                .RegisterServer()
                .Build();

            using(var scope = container.BeginLifetimeScope("root"))
            {

                var server = scope.Resolve<Server>();

                server.Start();

                server.Stop().Wait();
                
            }

            Console.ReadLine();

        }
    }
}
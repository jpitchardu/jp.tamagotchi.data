using System;

using Microsoft.Extensions.Configuration;

namespace jp.tamagotchi.data
{
    class Program
    {
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", true, true)
                .Build();

            var server = new Server(configuration);

            server.Start();

            server.Stop().Wait();

        }
    }
}
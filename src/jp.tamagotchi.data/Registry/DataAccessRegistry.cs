using Autofac;

using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace jp.tamagotchi.data.Registry
{
    public static class RegistryExtensions
    {

        public static ContainerBuilder RegisterConfiguration(this ContainerBuilder builder)
        {

            builder.Register(c => new ConfigurationBuilder()
                    .AddJsonFile("appSettings.json", true, true)
                    .Build()
                )
                .As<IConfiguration>();

            return builder;

        }

        public static ContainerBuilder RegisterDataAccess(this ContainerBuilder builder)
        {

            builder.Register(c =>
                {
                    var configuration = c.Resolve<IConfiguration>();

                    var connectionString = configuration.GetConnectionString("mysql");

                    var options = new DbContextOptionsBuilder<MySQLContext>().UseMySql(connectionString).Options;

                    return new MySQLContext(options);
                })
                .As<MySQLContext>();

            builder.Register(c =>
                {
                    var configuration = c.Resolve<IConfiguration>();

                    var connectionString = configuration.GetConnectionString("mongodb");

                    var options = new MongoDBDataConnectionOpts { ConnectionString = connectionString, Database = "jp-tamagotchi" };

                    return new MongoDBContext(options);
                })
                .As<MongoDBContext>();

            return builder;

        }

        public static ContainerBuilder RegisterServer(this ContainerBuilder builder)
        {

            builder.RegisterType<Server>().AsSelf();

            return builder;

        }

    }
}
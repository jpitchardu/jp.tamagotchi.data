using Autofac;

using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace jp.tamagotchi.data.Registry
{
    public static class DataAccessRegistry
    {

        public static ContainerBuilder RegisterDataAccess(this ContainerBuilder builder, IConfiguration configuration)
        {

            builder.Register(c => new MySQLContext(
                    new DbContextOptionsBuilder<MySQLContext>()
                    .UseMySql(configuration.GetConnectionString("mysql"))
                    .Options
                ))
                .As<MySQLContext>();

            builder.Register(c => new MongoDBContext(new MongoDBDataConnectionOpts
                {
                    ConnectionString = configuration.GetConnectionString("mysql"),
                        Database = "jp-tamagotchi"
                }))
                .As<MongoDBContext>();

            return builder;

        }
    }
}
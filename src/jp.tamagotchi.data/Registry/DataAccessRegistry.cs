using Autofac;

using jp.tamagotchi.data.DataAccess;
using jp.tamagotchi.data.Entities;

namespace jp.tamagotchi.data.Registry
{
    public static class DataAccessRegistry
    {

        public static void RegisterDataAccess(this ContainerBuilder builder)
        {

            builder.RegisterType<MySQLContext>().AsSelf();
            builder.RegisterType<MongoDBContext>().AsSelf();

            builder.Register(c => DataCollectionAdapterFactory.AdapterFromDbSet(c.Resolve<MySQLContext>().Developer))
                .As<IDataCollectionAdapter<Developer>>();
            builder.Register(c => DataCollectionAdapterFactory.AdapterFromDbSet(c.Resolve<MySQLContext>().User))
                .As<IDataCollectionAdapter<User>>();
            builder.Register(c => DataCollectionAdapterFactory.AdapterFromDbSet(c.Resolve<MySQLContext>().Pet))
                .As<IDataCollectionAdapter<Pet>>();

        }
    }
}
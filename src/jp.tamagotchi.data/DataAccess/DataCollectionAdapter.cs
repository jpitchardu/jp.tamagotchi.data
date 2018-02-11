using System;

using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;
using MongoDB.Driver.Linq;

using System.Linq;

namespace jp.tamagotchi.data.DataAccess
{
    public interface IReadableDataCollectionAdapter<T>
    {
        IQueryable<T> GetAll();

        T GetSingle(Func<T, bool> predicate);

    }
    public interface IWritableDataCollectionAdapter<T>
    {
        T Add(T t);

        T Update(T t, Func<T, bool> predicate);

        void Delete(Func<T, bool> predicate);

    }

    public interface IDataCollectionAdapter<T> : IReadableDataCollectionAdapter<T>, IWritableDataCollectionAdapter<T> { }

    public class DataCollectionAdapterFactory
    {

        public static IDataCollectionAdapter<T> AdapterFromDbSet<T>(DbSet<T> dbSet) where T : class => new DbSetDataAdapter<T>(dbSet);

        public static IDataCollectionAdapter<T> AdapterFromMongoCollection<T>(IMongoCollection<T> collection) => new MongoCollectionDataAdapter<T>(collection);

    }
}
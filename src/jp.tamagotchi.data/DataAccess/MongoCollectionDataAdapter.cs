using System;

using MongoDB.Driver;

using System.Linq;

namespace jp.tamagotchi.data.DataAccess
{
    public class MongoCollectionDataAdapter<T> : IDataCollectionAdapter<T>
    {

        private IMongoCollection<T> _collection;

        public MongoCollectionDataAdapter(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public IQueryable<T> GetAll() => _collection.AsQueryable();

        public T GetSingle(Func<T, bool> predicate) => _collection.Find(
            new FilterDefinitionBuilder<T>().Where(x => predicate.Invoke(x))
        )
        .FirstOrDefault();

        public T Add(T t)
        {
            _collection.InsertOne(t);
            return t;
        }

        public T Update(T t, Func<T, bool> predicate)
        {
            _collection.ReplaceOne(new FilterDefinitionBuilder<T>().Where(x => predicate.Invoke(x)), t);
            return t;
        }

        public void Delete(Func<T, bool> predicate) => _collection.DeleteOne(
            new FilterDefinitionBuilder<T>().Where(x => predicate.Invoke(x))
        );

    }
}
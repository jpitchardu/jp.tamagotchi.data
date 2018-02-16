using MongoDB.Bson.Serialization;
using MongoDB.Driver;

using System.Collections.Generic;

namespace jp.tamagotchi.data.DataAccess
{

    public class MongoDBContext
    {

        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDBContext(IMongoDBDataConnectionOpts opts)
        {

            _client = new MongoClient(opts.ConnectionString);
            _database = _client.GetDatabase(opts.Database);

        }

    }

    public interface IMongoDBDataConnectionOpts
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
    }

}
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

using System.Collections.Generic;

namespace jp.tamagotchi.data.DataAccess
{

    public class MongoDBContext
    {

        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDBContext(MongoDBDataConnectionOpts opts)
        {

            _client = new MongoClient(opts.ConnectionString);
            _database = _client.GetDatabase(opts.Database);

        }

    }

    public class MongoDBDataConnectionOpts
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }

}
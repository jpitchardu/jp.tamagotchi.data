 using System.Collections.Generic;

 using MongoDB.Driver;

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

         public IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName) => _database.GetCollection<TDocument>(collectionName);

     }

     public class MongoDBDataConnectionOpts
     {
         public string ConnectionString { get; set; }
         public string Database { get; set; }
     }

 }
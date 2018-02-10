using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Collections.Generic;

namespace jp.tamagotchi.data.Entities {
    public class Transaction {

        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("userId")]
        public int UserId { get; set; }

        [BsonElement("petId")]
        public int PetId { get; set; }

        [BsonElement("transactionDetails")]
        public List<TransactionDetail> TransactionDetails { get; set; }

    }
}
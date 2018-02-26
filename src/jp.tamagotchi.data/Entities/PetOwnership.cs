using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace jp.tamagotchi.data.Entities
{
    public class PetOwnership
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonElement("userId")]
        public int UserId { get; set; }

        [BsonElement("petId")]
        public int PetId { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        [BsonElement("actions")]
        public List<ActionLog> Actions { get; set; }

        [BsonElement("dateCreated")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateCreated { get; set; }

        [BsonElement("dateCancelled")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateCancelled { get; set; }
    }
}
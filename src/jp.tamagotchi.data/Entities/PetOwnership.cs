using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

using System.Collections.Generic;

namespace jp.tamagotchi.data.Entities
{
    public class PetOwnership
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        public int UserId { get; set; }
        public int PetId { get; set; }
        public List<ActionLog> Actions { get; set; }
    }
}
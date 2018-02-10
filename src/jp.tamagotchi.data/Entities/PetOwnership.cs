using System.Collections.Generic;
using MongoDB.Bson;

namespace jp.tamagotchi.data.Entities
{
    public class PetOwnership
    {
        public ObjectId ObjectId { get; set; }

        public int UserId { get; set; }
        public int PetId { get; set; }       
        public List<ActionLog> Actions { get; set; }
    }
}
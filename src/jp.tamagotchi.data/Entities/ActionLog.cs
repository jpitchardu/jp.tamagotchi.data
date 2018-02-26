using System;
using System.Collections.Generic;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace jp.tamagotchi.data.Entities
{
    public class ActionLog
    {

        [BsonElement("dateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateTime { get; set; }

        [BsonDictionaryOptions(DictionaryRepresentation.Document)]
        public Dictionary<string, object> Details { get; set; }

    }
}
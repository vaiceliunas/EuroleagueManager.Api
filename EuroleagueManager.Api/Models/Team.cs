using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EuroleagueManager.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Team
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("country")]
        public string Country { get; set; }
        [BsonElement("players")]
        public List<Player> Players { get; set; }
        [BsonElement("coaches")]
        public List<Coach> Coaches { get; set; }
    }
}

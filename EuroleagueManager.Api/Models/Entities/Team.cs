using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models.Projections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EuroleagueManager.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Team
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("city")]
        public string City { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("country")]
        public string Country { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("players")]
        public List<PlayerInsideTeamProjection> Players { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("coaches")]
        public List<CoachInsideTeamProjection> Coaches { get; set; }
    }
}

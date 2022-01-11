using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EuroleagueManager.Api.Models.Projections
{
    public class PlayerInsideTeamProjection
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("surname")]
        public string Surname { get; set; }
    }
}

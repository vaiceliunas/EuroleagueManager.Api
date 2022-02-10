using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EuroleagueManager.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Coach
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string TeamId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("surname")]
        public string Surname { get; set; }
        [BsonElement("birthDate")]
        public DateTime? BirthDate { get; set; }
        [BsonElement("coachingRole")]
        public string CoachingRole { get; set; }
        [BsonElement("roleLevel")]
        public string roleLevel { get; set; }
    }
}

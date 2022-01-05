using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EuroleagueManager.Api.Models
{
    [BsonIgnoreExtraElements]
    public class Player
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("surname")]
        public string Surname { get; set; }
        [BsonElement("heightInCm")]
        public int HeightInCm { get; set; }
        [BsonElement("weightInKg")]
        public int WeightInKg { get; set; }
        [BsonElement("birthDate")]
        public DateTime? BirthDate { get; set; }
        [BsonElement("nickname")]
        public string Nickname { get; set; }
        [BsonElement("playingPosition")]
        public string PlayingPosition { get; set; }
        [BsonElement("positionLevel")]
        public string positionLevel { get; set; }
    }
}

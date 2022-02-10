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
        [BsonIgnoreIfNull]
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("surname")]
        public string Surname { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("heightInCm")]
        public int HeightInCm { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("weightInKg")]
        public int WeightInKg { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("birthDate")]
        public DateTime? BirthDate { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("nickname")]
        public string Nickname { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("playingPosition")]
        public string PlayingPosition { get; set; }
        [BsonIgnoreIfNull]
        [BsonElement("positionLevel")]
        public int positionLevel { get; set; }
    }
}

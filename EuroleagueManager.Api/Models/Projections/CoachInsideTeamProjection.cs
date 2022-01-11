﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EuroleagueManager.Api.Models.Projections
{
    public class CoachInsideTeamProjection
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string TeamId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("surname")]
        public string Surname { get; set; }
    }
}

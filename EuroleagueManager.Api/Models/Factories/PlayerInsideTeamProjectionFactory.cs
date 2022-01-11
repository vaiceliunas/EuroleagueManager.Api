using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models.Projections;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Models.Factories
{
    public class PlayerInsideTeamProjectionFactory
    {
        public static PlayerInsideTeamProjection
            CreateObject(ObjectId id, string name, string surname)
        {
            return new PlayerInsideTeamProjection()
            {
                Id = id,
                Name = name,
                Surname = surname
            };
        }
    }
}

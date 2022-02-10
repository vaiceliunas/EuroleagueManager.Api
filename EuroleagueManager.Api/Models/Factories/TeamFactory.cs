using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Models.Factories
{
    public class TeamFactory
    {
        public static Team GenerateTeam()
        {
            return new Team()
            {
                Id = ObjectId.GenerateNewId(),
                Name = "RandomName",
                City = "RandomCity",
                Country = "RandomCountry"
            };
        }
    }
}

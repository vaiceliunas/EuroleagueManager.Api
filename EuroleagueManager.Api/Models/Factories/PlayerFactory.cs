using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models.Projections;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Models.Factories
{
    public class PlayerFactory
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

        public static Player GeneratePlayer()
        {
            return new Player()
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Some name",
                Surname = "Some surname",
                Nickname = "The poison",
                HeightInCm = 199,
                WeightInKg = 92,
                BirthDate = new DateTime(1994, 11, 11),
                PlayingPosition = "pg/sg",
                positionLevel = 1
            };
        }

        public static Player InitializePlayer(ObjectId id, DateTime? birthDate, string name, string surname, int heightInCm, int WeightInKg)
        {
            return new Player()
            {
                Id = id,
                BirthDate = birthDate,
                Name = name,
                Surname = surname,
                HeightInCm = heightInCm,
                WeightInKg = WeightInKg
            };
        }
    }
}

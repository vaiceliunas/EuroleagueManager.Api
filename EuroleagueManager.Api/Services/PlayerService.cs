using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Repositories.Interfaces;
using EuroleagueManager.Api.Services.Interfaces;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Services
{
    public class PlayerService : IPlayerService
    {
        public readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public Player GeneratePlayer()
        {
            var newPlayer = new Player()
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

            var res = _playerRepository.AddPlayer(newPlayer);

            return res;
        }

        public Player GetPlayer(string id)
        {
            var result = _playerRepository.GetPlayer(new ObjectId(id));

            return result;
        }

        public List<Player> GetPlayers()
        {
            var result = _playerRepository.GetPlayers();

            return result;
        }
    }
}

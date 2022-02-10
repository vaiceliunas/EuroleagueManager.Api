using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Models.Factories;
using EuroleagueManager.Api.Models.Projections;
using EuroleagueManager.Api.Repositories.Interfaces;
using EuroleagueManager.Api.Services.Interfaces;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Services
{
    public class PlayerService : IPlayerService
    {
        public readonly IPlayerRepository _playerRepository;
        public readonly ITeamRepository _teamRepository;

        public PlayerService(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }
        public Player GeneratePlayer()
        {
            var newPlayer = PlayerFactory.GeneratePlayer();

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

        public Player UpdatePlayerFields(string playerId, Player playerFields)
        {
            var playerObjId = new ObjectId(playerId);
            var playerProjection = PlayerFactory.CreateObject(playerObjId, playerFields.Name, playerFields.Surname);
            UpdatePlayerFieldsInTeams(playerObjId, playerProjection);

            var result = _playerRepository.UpdatePlayer(playerObjId, playerFields);

            return result;
        }

        private void UpdatePlayerFieldsInTeams(ObjectId playerId, PlayerInsideTeamProjection playerProjection)
        {
            _teamRepository.UpdatePlayerFieldsInsideTeam(playerId, playerProjection);
        }
    }
}

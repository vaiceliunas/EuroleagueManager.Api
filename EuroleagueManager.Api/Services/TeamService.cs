using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Models.Factories;
using EuroleagueManager.Api.Repositories.Interfaces;
using EuroleagueManager.Api.Services.Interfaces;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;

        public TeamService(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;

        }
        public Team GenerateTeam()
        {
            var team = new Team()
            {
                Id = ObjectId.GenerateNewId(),
                Name = "RandomName",
                City = "RandomCity",
                Country = "RandomCountry"
            };

            var res = _teamRepository.InsertTeam(team);

            return res;
        }

        public Team AddPlayerToTeam(string teamId, string playerId)
        {

            var playerObjId = new ObjectId(playerId);
            var teamObjId = new ObjectId(teamId);
            var player = _playerRepository.GetPlayer(playerObjId);
            var playerProjection = PlayerInsideTeamProjectionFactory.CreateObject(player.Id, player.Name, player.Surname);

            var result = _teamRepository.AddPlayerToTeam(teamObjId, playerProjection);
            return result;
        }

        public Team RemovePlayerFromTeam(string teamId, string playerId)
        {
            var playerObjId = new ObjectId(playerId);
            var teamObjId = new ObjectId(teamId);

            var result = _teamRepository.RemovePlayerFromTeam(teamObjId, playerObjId);

            return result;
        }
    }
}

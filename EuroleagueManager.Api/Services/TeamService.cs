using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Repositories.Interfaces;
using EuroleagueManager.Api.Services.Interfaces;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
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
    }
}

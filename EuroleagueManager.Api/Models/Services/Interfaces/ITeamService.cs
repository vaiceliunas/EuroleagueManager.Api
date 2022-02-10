using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Services.Interfaces
{
    public interface ITeamService
    {
        public Team GenerateTeam();
        public Team GetTeam(string teamId);
        public List<Team> GetTeams();
        public Team AddPlayerToTeam(string teamId, string playerId);
        public Team RemovePlayerFromTeam(string teamId, string playerId);

        public Team UpdateTeamFields(string teamId, Team teamFields);
    }
}

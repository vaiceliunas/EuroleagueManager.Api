using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Models.Projections;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        public Team InsertTeam(Team team);
        public Team AddPlayerToTeam(ObjectId teamId, PlayerInsideTeamProjection player);
        public Team RemovePlayerFromTeam(ObjectId teamId, ObjectId playerId);
        public List<Team> GetTeams();
        public Team GetTeam(ObjectId teamId);

        public Team UpdateTeamFields(ObjectId teamId, Team teamFields);
        public void UpdatePlayerFieldsInsideTeam(ObjectId playerId, PlayerInsideTeamProjection player);
    }
}

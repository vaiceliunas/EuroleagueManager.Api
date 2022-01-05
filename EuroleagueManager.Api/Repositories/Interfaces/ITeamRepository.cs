using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        public Team InsertTeam(Team team);
        public Team AddPlayerToTeam(ObjectId teamId, Player player);
        public Team RemovePlayerFromTeam(ObjectId teamId, ObjectId playerId);
        public List<Team> GetAllTeams();
    }
}

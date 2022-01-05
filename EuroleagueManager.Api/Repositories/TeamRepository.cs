using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EuroleagueManager.Api.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IMongoCollection<Team> _teamCollection;
        public TeamRepository(IOptions<EuroleagueMongoDbSettings> euroleagueMongoDbSettings)
        {
            var mongoClient = new MongoClient(euroleagueMongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(euroleagueMongoDbSettings.Value.DatabaseName);
            _teamCollection = mongoDatabase.GetCollection<Team>(euroleagueMongoDbSettings.Value.TeamsCollection);
        }
        public Team InsertTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public Team AddPlayerToTeam(ObjectId teamId, Player player)
        {
            //_teamCollection.Find(t => t.Id == teamId).
            throw new NotImplementedException();
        }

        public Team RemovePlayerFromTeam(ObjectId teamId, ObjectId playerId)
        {
            throw new NotImplementedException();
        }

        public List<Team> GetAllTeams()
        {
            return _teamCollection.AsQueryable().ToList();
        }
    }
}

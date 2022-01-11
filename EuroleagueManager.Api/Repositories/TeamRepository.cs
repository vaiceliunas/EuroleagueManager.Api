using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Models.Projections;
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
            _teamCollection.InsertOne(team);
            return team;
        }

        public Team AddPlayerToTeam(ObjectId teamId,  PlayerInsideTeamProjection player)
        {
            var update = Builders<Team>.Update.Push(t => t.Players, player);

            var result = _teamCollection.UpdateOne(t => t.Id == teamId, update);
            return _teamCollection.Find(t => t.Id == teamId).FirstOrDefault();
        }

        public Team RemovePlayerFromTeam(ObjectId teamId, ObjectId playerId)
        {
            var filter = Builders<Team>.Filter.Where(t => t.Id == teamId);
            var pull = Builders<Team>.Update.PullFilter(p => p.Players,
                Builders<PlayerInsideTeamProjection>.Filter.Where(tp => tp.Id == playerId));

            _teamCollection.UpdateOne(filter, pull);

            return _teamCollection.Find(t => t.Id == teamId).FirstOrDefault();
        }

        public List<Team> GetTeams()
        {
            return _teamCollection.AsQueryable().ToList();
        }
    }
}

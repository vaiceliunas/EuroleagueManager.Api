using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Models.Projections;
using EuroleagueManager.Api.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
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
            var filter = Builders<Team>.Filter.Where(t => t.Id == teamId);
            var update = Builders<Team>.Update.Push(t => t.Players, player);

            var result = _teamCollection.FindOneAndUpdate(filter, update, new FindOneAndUpdateOptions<Team, Team>(){ReturnDocument = ReturnDocument.After});
            return result;
        }

        public Team RemovePlayerFromTeam(ObjectId teamId, ObjectId playerId)
        {
            var filter = Builders<Team>.Filter.Where(t => t.Id == teamId);
            var pull = Builders<Team>.Update.PullFilter(p => p.Players,
                Builders<PlayerInsideTeamProjection>.Filter.Where(tp => tp.Id == playerId));

            var result = _teamCollection.FindOneAndUpdate(filter, pull, new FindOneAndUpdateOptions<Team, Team>() { ReturnDocument = ReturnDocument.After });

            return result;
        }

        public List<Team> GetTeams()
        {
            return _teamCollection.AsQueryable().ToList();
        }

        public Team GetTeam(ObjectId teamId)
        {
            return _teamCollection.Find(t => t.Id == teamId).FirstOrDefault();
        }

        public Team UpdateTeamFields(ObjectId teamId, Team teamFields)
        {
            var filter = Builders<Team>.Filter.Where(t => t.Id == teamId);
            var update = Builders<Team>.Update
                .Set(t => t.Name, teamFields.Name)
                .Set(t => t.City, teamFields.City)
                .Set(t => t.Country, teamFields.Country);

            var result = _teamCollection.FindOneAndUpdate(filter, update, new FindOneAndUpdateOptions<Team, Team>(){ReturnDocument = ReturnDocument.After});

            return result;
        }

        public void UpdatePlayerFieldsInsideTeam(ObjectId playerId, PlayerInsideTeamProjection player)
        {

            var updateFilter = Builders<Team>.Filter.Where(t => t.Players.Any(j => j.Id == playerId));
            var update = Builders<Team>.Update
                .Set(t => t.Players[-1].Name, player.Name)
                .Set(t => t.Players[-1].Surname, player.Surname);

            var result = _teamCollection.UpdateMany(updateFilter, update);
        }
    }
}

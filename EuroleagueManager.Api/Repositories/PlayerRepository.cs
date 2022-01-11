using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EuroleagueManager.Api.Repositories.Interfaces
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IMongoCollection<Player> _playerCollection;
        public PlayerRepository(IOptions<EuroleagueMongoDbSettings> euroleagueMongoDbSettings)
        {
            var mongoClient = new MongoClient(euroleagueMongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(euroleagueMongoDbSettings.Value.DatabaseName);
            _playerCollection = mongoDatabase.GetCollection<Player>(euroleagueMongoDbSettings.Value.PlayersCollection);
        }
        public Player AddPlayer(Player player)
        {
            _playerCollection.InsertOne(player);

            return player;
        }

        public Player UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public Player DeletePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(ObjectId objectId)
        {
            var result = _playerCollection.Find<Player>(t => t.Id == objectId).FirstOrDefault();

            return result;
        }

        public List<Player> GetPlayers()
        {
            var result = _playerCollection.Find(_ => true).ToList();

            return result;
        }
    }
}

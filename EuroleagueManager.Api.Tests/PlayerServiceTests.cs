using EuroleagueManager.Api.Models;
using System;
using EuroleagueManager.Api.Repositories;
using EuroleagueManager.Api.Repositories.Interfaces;
using EuroleagueManager.Api.Services;
using EuroleagueManager.Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using Xunit;
using Xunit.Sdk;

namespace EuroleagueManager.Api.Tests
{
    public class PlayerServiceTests
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerService _playerService;

        public PlayerServiceTests()
        {
            _playerRepository = new PlayerRepository(TestAppSettings._mongoDbSettings);
            _teamRepository = new TeamRepository(TestAppSettings._mongoDbSettings);
            _playerService = new PlayerService(_playerRepository, _teamRepository);
        }

        [Fact]
        public void GeneratePlayer_PlayerCountIncreases()
        {
            var players = _playerService.GetPlayers().Count;
            var generatedPlayer = _playerService.GeneratePlayer();
            var playersAfterGeneratingOne = _playerService.GetPlayers().Count;

            Assert.Equal(players + 1, playersAfterGeneratingOne);

        }

        [Fact]
        public void GeneratePlayer_GetPlayer_ReturnsExactPlayer()
        {
            var player = _playerService.GeneratePlayer();
            var getPlayer = _playerService.GetPlayer(player.Id.ToString());

            Assert.Equal(player.Name, getPlayer.Name);
            Assert.Equal(player.Id, getPlayer.Id);
        }

        [Fact]
        public void GeneratePlayer_UpdatePlayer_GetPlayer_ReturnsUpdatedPlayer()
        {
            var newName = "Some new name";
            var newSurname = "new Surname";
            var newHeightInCm = 200;
            var newWeightInKg = 100;

            var player = _playerService.GeneratePlayer();
            var updatePlayer = new Player()
            {
                Id = player.Id,
                BirthDate = player.BirthDate,
                Name = newName,
                Surname = newSurname,
                HeightInCm = newHeightInCm,
                WeightInKg = newWeightInKg
            };

            var updatedPlayer = _playerService.UpdatePlayerFields(player.Id.ToString(), updatePlayer);
            var getUpdatedPlayer = _playerService.GetPlayer(player.Id.ToString());

            Assert.Equal(newName, getUpdatedPlayer.Name);
            Assert.Equal(newSurname, getUpdatedPlayer.Surname);
            Assert.Equal(newWeightInKg, getUpdatedPlayer.WeightInKg);
            Assert.Equal(newHeightInCm, getUpdatedPlayer.HeightInCm);
        }
    }
}

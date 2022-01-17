using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Common.Helpers;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Services.Interfaces;
using MongoDB.Bson;

namespace EuroleagueManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playersService)
        {
            _playerService = playersService;
        }

        [Authorize]
        [HttpGet("{playerId}")]
        public IActionResult GetPlayer(string playerId)
        {
            var result = _playerService.GetPlayer(playerId);

            return Ok(result);
        }

        //[Authorize]
        [HttpPut("{playerId}")]
        public IActionResult PutPlayer(string playerId, Player player)
        {
            var result = _playerService.UpdatePlayerFields(playerId, player);

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetPlayers()
        {
            var result = _playerService.GetPlayers();

            return Ok(result);
        }

        [Authorize]
        [HttpPost("generatePlayer")]
        public IActionResult Generate()
        {
            var result = _playerService.GeneratePlayer();

            return Ok(result);
        }
    }
}

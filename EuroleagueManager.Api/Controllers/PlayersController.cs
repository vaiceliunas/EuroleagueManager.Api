using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("{playerId}")]
        public IActionResult GetPlayer(string playerId)
        {
            var result = _playerService.GetPlayer(playerId);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetPlayers()
        {
            var result = _playerService.GetPlayers();

            return Ok(result);
        }

        [HttpPost("generatePlayer")]
        public IActionResult Generate()
        {
            var result = _playerService.GeneratePlayer();

            return Ok(result);
        }
    }
}

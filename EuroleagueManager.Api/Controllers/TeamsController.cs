using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Services.Interfaces;

namespace EuroleagueManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamsService;

        public TeamsController(ITeamService teamsService)
        {
            _teamsService = teamsService;
        }

        [HttpGet("{teamId}")]
        public IActionResult Get(string teamId)
        {
            //var res = _teamsService().;

            return Ok();
        }

        [HttpPost("{teamId}/addPlayer/{playerId}")]
        public IActionResult AddPlayer(string teamId, string playerId)
        {
            var result = _teamsService.AddPlayerToTeam(teamId, playerId);


            return Ok(result);
        }

        [HttpPost("{teamId}/removePlayer/{playerId}")]
        public IActionResult RemovePlayer(string teamId, string playerId)
        {
            var result = _teamsService.RemovePlayerFromTeam(teamId, playerId);


            return Ok(result);
        }

        [HttpPost("generateTeam")]
        public IActionResult GenerateTeam()
        {
            var result = _teamsService.GenerateTeam();

            return Ok(result);
        }
    }
}

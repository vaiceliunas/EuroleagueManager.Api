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

        [HttpPost]
        public IActionResult Get()
        {
            var res = _teamsService.GenerateTeam();

            return Ok(res);
        }
    }
}

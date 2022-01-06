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
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playersService)
        {
            _playerService = playersService;
        }

        [HttpPost]
        public IActionResult Generate()
        {
            var result = _playerService.GeneratePlayer();

            return Ok(result);
        }
    }
}

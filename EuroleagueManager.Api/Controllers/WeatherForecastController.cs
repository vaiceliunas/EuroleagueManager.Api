using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;
using EuroleagueManager.Api.Repositories.Interfaces;

namespace EuroleagueManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public readonly ITeamRepository _teamRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITeamRepository teamRepository)
        {
            _logger = logger;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public IEnumerable<Team> Get()
        {
            var rng = new Random();

            var data =  _teamRepository.GetAllTeams();

            return data;
        }
    }
}

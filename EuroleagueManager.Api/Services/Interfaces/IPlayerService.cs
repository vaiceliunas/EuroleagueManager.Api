using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;

namespace EuroleagueManager.Api.Services.Interfaces
{
    public interface IPlayerService
    {
        public Player GeneratePlayer();
        public Player GetPlayer(string id);
        public List<Player> GetPlayers();
    }
}

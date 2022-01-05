using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroleagueManager.Api.Models;

namespace EuroleagueManager.Api.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        public Player AddPlayer(Player player);
        public Player UpdatePlayer(Player player);
        public Player DeletePlayer(Player player);
    }
}

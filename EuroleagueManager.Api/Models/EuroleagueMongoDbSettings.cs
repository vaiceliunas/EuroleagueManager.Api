using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroleagueManager.Api.Models
{
    public class EuroleagueMongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string Collection { get; set; } = null!;
    }
}

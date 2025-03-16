using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions.Abstractions;
using Game.Domain.ValueObjects;

namespace Game.Domain.Models
{
    public class Game : Aggregate<GameId>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
